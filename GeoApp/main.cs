using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoApp
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        public static class AppMode
        {
            public enum Work_Mode
            {
                AUTOMATIC,
                MANUAL
            }
        }

        public static string WorkMode;

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            //Check if Internet access is available if yes then proceed to next page
            try
            {
                
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                {
                    WorkModeBox workMode = new WorkModeBox();
                    DialogResult result = workMode.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        WorkMode = AppMode.Work_Mode.AUTOMATIC.ToString();
                    }
                    else
                    {
                        WorkMode = AppMode.Work_Mode.MANUAL.ToString();
                    }
                    frmLocation location = new frmLocation();
                    this.Hide();
                    workMode.Hide();
                   location.ShowDialog();
                    this.Close();
                    workMode.Close();
                }
                    

            }
            catch(Exception ex)
            {
                MessageBox.Show("Unable to Connect to Internet. Please try again later.");
                WorkMode = null;
            }
        }
    }
}
