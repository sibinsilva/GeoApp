using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace GeoApp
{
    public partial class frmLocation : Form
    {
        public static string selectedstop;
        public static string TransportType = "";
        public frmLocation()
        {
            InitializeComponent();
            if (main.WorkMode == "AUTOMATIC")
            {
                this.lblManualTxt.Visible = false;
                this.txtLocation.ReadOnly = true;
            }
            else
            {
                this.lblLocationTxt.Visible = false;
                this.btnLocation.Visible = false;
            }
        }
        private static string latitude = "";
        private static string longitude = "";
        public static string GetUserLocationByIp(string ip)
        {
            clsIPInfo ipInfo = new clsIPInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip + "?token=" + Settings.Default.Token);
                ipInfo = JsonConvert.DeserializeObject<clsIPInfo>(info);
                string cord = ipInfo.Loc;
                string[] cords = cord.Split(',');
                latitude = cords[0];
                longitude = cords[1];
                return ReverseGeoLoc(cords[1], cords[0]);


            }
            catch (Exception)
            {
                ipInfo.Loc = null;
            }

            return ipInfo.Loc;
        }

        public string GetUserIP()
        {
            string strIP = String.Empty;
            try
            {
                WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
                using (WebResponse response = request.GetResponse())
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    strIP = sr.ReadToEnd();
                }

                int i1 = strIP.IndexOf("Address: ") + 9;
                int i2 = strIP.LastIndexOf("</body>");
                strIP = strIP.Substring(i1, i2 - i1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return strIP;
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            //Try geo Location from device first if it fails use AGPS
            txtLocation.Text = GetGeoLocation();
            lblLocationTxt.ForeColor = Color.MediumBlue;
            if (txtLocation.Text == null || txtLocation.Text == "")
            {
                txtLocation.Text = GetUserLocationByIp(GetUserIP());
                lblLocationTxt.Text = "IP Location Acquired";
            }
        }

        private string GetGeoLocation()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            Thread.Sleep(2000);
            watcher.TryStart(false, TimeSpan.FromMilliseconds(5000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                latitude = coord.Latitude.ToString();
                longitude = coord.Longitude.ToString();
                lblLocationTxt.Text = "Device Location Acquired";
                return ReverseGeoLoc(coord.Longitude.ToString(), coord.Latitude.ToString());
            }
            else
            {
                MessageBox.Show("Unknown latitude and longitude.");
                return null;
            }
        }

        private static string ReverseGeoLoc(string longitude, string latitude)
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load("https://maps.googleapis.com/maps/api/geocode/xml?key=" + Settings.Default.MapAPI + "&latlng=" + latitude + "," + longitude + "&sensor=false");
                XmlNode element = doc.SelectSingleNode("//GeocodeResponse/status");
                if (element.InnerText == "ZERO_RESULTS")
                {
                    return ("No data available for the specified location");
                }
                else
                {

                    element = doc.SelectSingleNode("//GeocodeResponse/result/formatted_address");
                    return (element.InnerText);
                }

            }
            catch (Exception ex)
            {
                return ("(Address lookup failed: ) " + ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (main.WorkMode == "MANUAL")
            {
                result = GetManualCords(this.txtLocation.Text);
                if(!result)
                {
                    goto NoDATA;
                }
            }
            this.lstStations.Visible = true;
            this.lblConnected.ForeColor = Color.Green;
            this.lblConnected.Text = "Finding nearby stations....";
            if (this.rbtnBus.Checked)
            {
                GetNearbyStations("Bus");
            }
            else if (rbtnTrain.Checked)
            {
                GetNearbyStations("Train");
            }
            else if (rbtnTram.Checked)
            {
                GetNearbyStations("Tram");
            }
            else
            {
                GetNearbyStations("Subway");
            }
            NoDATA:
            if(main.WorkMode=="MANUAL" && result==false)
            {
                this.lblConnected.ForeColor = Color.Red;
                this.lblConnected.Text = "No Data Available";
            }
            
        }


        private bool GetManualCords(string address)
        {
            bool retVal = false;
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false", Uri.EscapeDataString(address), Settings.Default.MapAPI);

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());
            XElement status = xdoc.Element("GeocodeResponse").Element("status");
            if (status.Value.ToString() == "OK")
            {
                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");
                longitude = locationElement.Element("lng").Value;
                latitude = locationElement.Element("lat").Value;
                retVal = true;
            }
            else
            {
               
            }
            return retVal;
        }

        private void GetNearbyStations(string transport)
        {
            XmlDocument doc = new XmlDocument();
            
            switch (transport)
            {
                case "Bus":
                    TransportType = "bus_station";
                    break;
                case "Train":
                    TransportType = "train_station";
                    break;
                case "Tram":
                    TransportType = "light_rail_station";
                    break;
                case "Subway":
                    TransportType = "subway_station";
                    break;
                default:
                    break;
            }

            try
            {
                this.lstStations.Items.Clear();
                doc.Load("https://maps.googleapis.com/maps/api/place/nearbysearch/xml?location=" + latitude + "," + longitude + "&rankby=distance&type=" + TransportType + "&key=" + Settings.Default.MapAPI);
                XmlNode status = doc.SelectSingleNode("//PlaceSearchResponse/status");

                if (status.InnerText == "ZERO_RESULTS")
                {
                    this.lblConnected.Text = "No data available for the specified location";
                    this.lstStations.Visible = false;
                }
                else
                {
                    XmlNodeList elements = doc.SelectNodes("//PlaceSearchResponse/result");
                    foreach (XmlNode element in elements)
                    {
                        XmlNode Singleelement = element.ChildNodes.Item(0);
                        this.lstStations.Items.Add(Singleelement.InnerText);
                        this.lblConnected.Text = "Success";
                        this.btnRealTime.Visible = true;
                    }
                }

            }
            catch (Exception ex)
            {
                this.lblConnected.ForeColor = Color.Red;
                this.lstStations.Visible = false;
                this.lblConnected.Text = "Station lookup failed:  " + ex.Message;
            }
        }



        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            string var = txtLocation.Text;
            if (var.Length < 3)
            {

            }
            else
            {
                string url = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + var + "&types=geocode&key=" + Settings.Default.MapAPI;
                string content = fileGetContents(url);
                JObject o = JObject.Parse(content);
                List<string> add = new List<string>();
                try
                {
                    JObject jObj = (JObject)JsonConvert.DeserializeObject(content);
                    int count = jObj.Count;
                    for (int i = 0; i < count; i++)
                    {

                        add.Add((string)o.SelectToken("predictions[" + i + "].description"));
                    }

                    var collection = new AutoCompleteStringCollection();
                    collection.AddRange(add.ToArray());
                    txtLocation.AutoCompleteCustomSource = collection;
                    txtLocation.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        protected string fileGetContents(string fileName)
        {
            string sContents = string.Empty;
            System.IO.StreamReader sr;
            string me = string.Empty;
            try
            {
                if (fileName.ToLower().IndexOf("https:") > -1)
                {
                    System.Net.WebClient wc = new System.Net.WebClient();
                    byte[] response = wc.DownloadData(fileName);
                    sContents = System.Text.Encoding.ASCII.GetString(response);

                }
                else
                {
                    sr = new System.IO.StreamReader(fileName);
                    sContents = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception)
            {
                sContents = "unable to connect to server";
            }

            return sContents;
        }

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            if(lstStations.SelectedIndex > -1)
            {
                selectedstop = lstStations.SelectedItem.ToString();
                if(selectedstop != null || selectedstop != "")
                {
                    frmMap map = new frmMap();
                    this.Hide();
                    map.ShowDialog();
                    this.Close();
                }
            }
        } 
    }
}
