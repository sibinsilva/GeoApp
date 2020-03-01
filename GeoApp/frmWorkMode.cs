using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoApp
{
    public partial class WorkModeBox : Form
    {
        public WorkModeBox()
        {
            InitializeComponent();
        }
        public readonly MessageBoxButtons _buttons;
        public WorkModeBox(string message, string title, MessageBoxButtons buttons)
        {
            InitializeComponent();

            Text = title;
            lblMessage.Text = message;

            _buttons = buttons;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void frmCustomMessageBoxLoad(object sender, EventArgs e)
        {
            lblMessage.Left = (ClientSize.Width - lblMessage.Width) / 2;
            lblMessage.Text = "How would you like the App to work?";
            btnLeft.Text = @"Automatic";
            btnLeft.DialogResult = DialogResult.Yes;
            btnRight.Text = @"Manual";
            btnRight.DialogResult = DialogResult.No;
            AcceptButton = btnLeft;
        }
    }
}
