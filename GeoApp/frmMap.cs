using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoApp
{
    public partial class frmMap : Form
    {
        public frmMap()
        {
            InitializeComponent();
            OpenMapBrowser(frmLocation.selectedstop,frmLocation.TransportType);
        }
        public ChromiumWebBrowser browser;
        public string URL;
        public void InitBrowser(string URL)
        {
            Cef.Initialize(new CefSettings());
            browser = new ChromiumWebBrowser(URL);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }

        public void OpenMapBrowser(string stop,string Transitmode)
        {
            string Transitstop = stop;
            StringBuilder queryaddress = new StringBuilder();
            try
            {
                queryaddress.Append("http://maps.google.com/maps/place?q=");
                if (Transitstop != string.Empty)
                {
                    queryaddress.Append(Transitstop);
                }
                if(!queryaddress.ToString().Contains("station"))
                {
                    queryaddress.Append(","+ Transitmode);
                }
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
            InitBrowser(queryaddress.ToString());
        }
    }
}
