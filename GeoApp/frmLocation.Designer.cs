namespace GeoApp
{
    partial class frmLocation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLocation = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblConnected = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.rbtnTrain = new System.Windows.Forms.RadioButton();
            this.rbtnBus = new System.Windows.Forms.RadioButton();
            this.rbtnTram = new System.Windows.Forms.RadioButton();
            this.lblLocationTxt = new System.Windows.Forms.Label();
            this.rbtnSubway = new System.Windows.Forms.RadioButton();
            this.lblManualTxt = new System.Windows.Forms.Label();
            this.btnRealTime = new System.Windows.Forms.Button();
            this.lstStations = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(462, 70);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(122, 23);
            this.btnLocation.TabIndex = 0;
            this.btnLocation.Text = "Get Current Location";
            this.btnLocation.UseVisualStyleBackColor = true;
            this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(215, 73);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(241, 20);
            this.txtLocation.TabIndex = 1;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(212, 100);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(0, 13);
            this.lblConnected.TabIndex = 2;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(215, 217);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // rbtnTrain
            // 
            this.rbtnTrain.AutoSize = true;
            this.rbtnTrain.Location = new System.Drawing.Point(215, 116);
            this.rbtnTrain.Name = "rbtnTrain";
            this.rbtnTrain.Size = new System.Drawing.Size(147, 17);
            this.rbtnTrain.TabIndex = 4;
            this.rbtnTrain.TabStop = true;
            this.rbtnTrain.Text = "See nearby Train Stations";
            this.rbtnTrain.UseVisualStyleBackColor = true;
            // 
            // rbtnBus
            // 
            this.rbtnBus.AutoSize = true;
            this.rbtnBus.Location = new System.Drawing.Point(215, 139);
            this.rbtnBus.Name = "rbtnBus";
            this.rbtnBus.Size = new System.Drawing.Size(141, 17);
            this.rbtnBus.TabIndex = 5;
            this.rbtnBus.TabStop = true;
            this.rbtnBus.Text = "See nearby Bus Stations";
            this.rbtnBus.UseVisualStyleBackColor = true;
            // 
            // rbtnTram
            // 
            this.rbtnTram.AutoSize = true;
            this.rbtnTram.Location = new System.Drawing.Point(215, 162);
            this.rbtnTram.Name = "rbtnTram";
            this.rbtnTram.Size = new System.Drawing.Size(142, 17);
            this.rbtnTram.TabIndex = 6;
            this.rbtnTram.TabStop = true;
            this.rbtnTram.Text = "See nearby Tram Station";
            this.rbtnTram.UseVisualStyleBackColor = true;
            // 
            // lblLocationTxt
            // 
            this.lblLocationTxt.AutoSize = true;
            this.lblLocationTxt.Location = new System.Drawing.Point(604, 76);
            this.lblLocationTxt.Name = "lblLocationTxt";
            this.lblLocationTxt.Size = new System.Drawing.Size(0, 13);
            this.lblLocationTxt.TabIndex = 8;
            // 
            // rbtnSubway
            // 
            this.rbtnSubway.AutoSize = true;
            this.rbtnSubway.Location = new System.Drawing.Point(215, 185);
            this.rbtnSubway.Name = "rbtnSubway";
            this.rbtnSubway.Size = new System.Drawing.Size(156, 17);
            this.rbtnSubway.TabIndex = 9;
            this.rbtnSubway.TabStop = true;
            this.rbtnSubway.Text = "See nearby Subway Station";
            this.rbtnSubway.UseVisualStyleBackColor = true;
            // 
            // lblManualTxt
            // 
            this.lblManualTxt.AutoSize = true;
            this.lblManualTxt.Location = new System.Drawing.Point(212, 48);
            this.lblManualTxt.Name = "lblManualTxt";
            this.lblManualTxt.Size = new System.Drawing.Size(137, 13);
            this.lblManualTxt.TabIndex = 10;
            this.lblManualTxt.Text = "Enter the location to search";
            // 
            // btnRealTime
            // 
            this.btnRealTime.Location = new System.Drawing.Point(215, 372);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(134, 23);
            this.btnRealTime.TabIndex = 12;
            this.btnRealTime.Text = "Show Realtime Data";
            this.btnRealTime.UseVisualStyleBackColor = true;
            this.btnRealTime.Visible = false;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // lstStations
            // 
            this.lstStations.FormattingEnabled = true;
            this.lstStations.Location = new System.Drawing.Point(215, 260);
            this.lstStations.Name = "lstStations";
            this.lstStations.Size = new System.Drawing.Size(241, 95);
            this.lstStations.TabIndex = 13;
            // 
            // frmLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstStations);
            this.Controls.Add(this.btnRealTime);
            this.Controls.Add(this.lblManualTxt);
            this.Controls.Add(this.rbtnSubway);
            this.Controls.Add(this.lblLocationTxt);
            this.Controls.Add(this.rbtnTram);
            this.Controls.Add(this.rbtnBus);
            this.Controls.Add(this.rbtnTrain);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnLocation);
            this.Name = "frmLocation";
            this.Text = "Location";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblConnected;
        public System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.RadioButton rbtnTrain;
        private System.Windows.Forms.RadioButton rbtnBus;
        private System.Windows.Forms.RadioButton rbtnTram;
        private System.Windows.Forms.Label lblLocationTxt;
        private System.Windows.Forms.RadioButton rbtnSubway;
        private System.Windows.Forms.Label lblManualTxt;
        private System.Windows.Forms.Button btnRealTime;
        private System.Windows.Forms.ListBox lstStations;
    }
}