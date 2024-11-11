namespace TestUSBApp
{
    partial class DataPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            measurmentLabel = new Label();
            backButton = new Button();
            usbDevices = new TextBox();
            deviceTimer = new System.Windows.Forms.Timer(components);
            accelXData = new RichTextBox();
            accelXHeader = new Label();
            accelYHeader = new Label();
            accelYData = new RichTextBox();
            accelZHeader = new Label();
            accelZData = new RichTextBox();
            gyroXHeader = new Label();
            gyroXData = new RichTextBox();
            gyroYHeader = new Label();
            gyroYData = new RichTextBox();
            gyroZHeader = new Label();
            gyroZData = new RichTextBox();
            magXHeader = new Label();
            magXData = new RichTextBox();
            magYHeader = new Label();
            magYData = new RichTextBox();
            magZHeader = new Label();
            magZData = new RichTextBox();
            errorLabel = new Label();
            bluetoothPicture = new PictureBox();
            imuLabel = new Label();
            label1 = new Label();
            elevationLabel = new Label();
            elevationData = new RichTextBox();
            longitudeLabel = new Label();
            longitudeData = new RichTextBox();
            latitudeLabel = new Label();
            latitudeData = new RichTextBox();
            satellitesLabel = new Label();
            satellitesData = new RichTextBox();
            timeLabel = new Label();
            timeData = new RichTextBox();
            dateLabel = new Label();
            dateData = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)bluetoothPicture).BeginInit();
            SuspendLayout();
            // 
            // measurmentLabel
            // 
            measurmentLabel.Anchor = AnchorStyles.Top;
            measurmentLabel.AutoSize = true;
            measurmentLabel.Font = new Font("Segoe UI", 25F);
            measurmentLabel.Location = new Point(328, 56);
            measurmentLabel.Name = "measurmentLabel";
            measurmentLabel.Size = new Size(223, 46);
            measurmentLabel.TabIndex = 1;
            measurmentLabel.Text = "Measurments";
            // 
            // backButton
            // 
            backButton.Location = new Point(388, 431);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 45);
            backButton.TabIndex = 2;
            backButton.Text = "Back to Home";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // usbDevices
            // 
            usbDevices.Location = new Point(3, 3);
            usbDevices.Multiline = true;
            usbDevices.Name = "usbDevices";
            usbDevices.ReadOnly = true;
            usbDevices.Size = new Size(197, 141);
            usbDevices.TabIndex = 3;
            usbDevices.Visible = false;
            // 
            // deviceTimer
            // 
            deviceTimer.Tick += deviceTimer_Tick;
            // 
            // accelXData
            // 
            accelXData.Location = new Point(10, 368);
            accelXData.Name = "accelXData";
            accelXData.ReadOnly = true;
            accelXData.Size = new Size(76, 29);
            accelXData.TabIndex = 4;
            accelXData.Text = "";
            // 
            // accelXHeader
            // 
            accelXHeader.AutoSize = true;
            accelXHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accelXHeader.Location = new Point(1, 350);
            accelXHeader.Name = "accelXHeader";
            accelXHeader.Size = new Size(95, 15);
            accelXHeader.TabIndex = 5;
            accelXHeader.Text = "Accel X (m/s^2)";
            accelXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelYHeader
            // 
            accelYHeader.AutoSize = true;
            accelYHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accelYHeader.Location = new Point(99, 350);
            accelYHeader.Name = "accelYHeader";
            accelYHeader.Size = new Size(95, 15);
            accelYHeader.TabIndex = 7;
            accelYHeader.Text = "Accel X (m/s^2)";
            accelYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelYData
            // 
            accelYData.Location = new Point(108, 368);
            accelYData.Name = "accelYData";
            accelYData.ReadOnly = true;
            accelYData.Size = new Size(76, 29);
            accelYData.TabIndex = 6;
            accelYData.Text = "";
            // 
            // accelZHeader
            // 
            accelZHeader.AutoSize = true;
            accelZHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accelZHeader.Location = new Point(199, 350);
            accelZHeader.Name = "accelZHeader";
            accelZHeader.Size = new Size(94, 15);
            accelZHeader.TabIndex = 9;
            accelZHeader.Text = "Accel Z (m/s^2)";
            accelZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelZData
            // 
            accelZData.Location = new Point(208, 368);
            accelZData.Name = "accelZData";
            accelZData.ReadOnly = true;
            accelZData.Size = new Size(76, 29);
            accelZData.TabIndex = 8;
            accelZData.Text = "";
            // 
            // gyroXHeader
            // 
            gyroXHeader.AutoSize = true;
            gyroXHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gyroXHeader.Location = new Point(298, 350);
            gyroXHeader.Name = "gyroXHeader";
            gyroXHeader.Size = new Size(84, 15);
            gyroXHeader.TabIndex = 11;
            gyroXHeader.Text = "Gyro X (rad/s)";
            gyroXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroXData
            // 
            gyroXData.Location = new Point(301, 368);
            gyroXData.Name = "gyroXData";
            gyroXData.ReadOnly = true;
            gyroXData.Size = new Size(76, 29);
            gyroXData.TabIndex = 10;
            gyroXData.Text = "";
            // 
            // gyroYHeader
            // 
            gyroYHeader.AutoSize = true;
            gyroYHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gyroYHeader.Location = new Point(388, 350);
            gyroYHeader.Name = "gyroYHeader";
            gyroYHeader.Size = new Size(83, 15);
            gyroYHeader.TabIndex = 13;
            gyroYHeader.Text = "Gyro Y (rad/s)";
            gyroYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroYData
            // 
            gyroYData.Location = new Point(391, 368);
            gyroYData.Name = "gyroYData";
            gyroYData.ReadOnly = true;
            gyroYData.Size = new Size(76, 29);
            gyroYData.TabIndex = 12;
            gyroYData.Text = "";
            // 
            // gyroZHeader
            // 
            gyroZHeader.AutoSize = true;
            gyroZHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gyroZHeader.Location = new Point(479, 350);
            gyroZHeader.Name = "gyroZHeader";
            gyroZHeader.Size = new Size(83, 15);
            gyroZHeader.TabIndex = 15;
            gyroZHeader.Text = "Gyro Z (rad/s)";
            gyroZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroZData
            // 
            gyroZData.Location = new Point(482, 368);
            gyroZData.Name = "gyroZData";
            gyroZData.ReadOnly = true;
            gyroZData.Size = new Size(76, 29);
            gyroZData.TabIndex = 14;
            gyroZData.Text = "";
            // 
            // magXHeader
            // 
            magXHeader.AutoSize = true;
            magXHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            magXHeader.Location = new Point(579, 350);
            magXHeader.Name = "magXHeader";
            magXHeader.Size = new Size(67, 15);
            magXHeader.TabIndex = 17;
            magXHeader.Text = "Mag X (uT)";
            magXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magXData
            // 
            magXData.Location = new Point(575, 368);
            magXData.Name = "magXData";
            magXData.ReadOnly = true;
            magXData.Size = new Size(76, 29);
            magXData.TabIndex = 16;
            magXData.Text = "";
            // 
            // magYHeader
            // 
            magYHeader.AutoSize = true;
            magYHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            magYHeader.Location = new Point(671, 350);
            magYHeader.Name = "magYHeader";
            magYHeader.Size = new Size(66, 15);
            magYHeader.TabIndex = 19;
            magYHeader.Text = "Mag Y (uT)";
            magYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magYData
            // 
            magYData.Location = new Point(667, 368);
            magYData.Name = "magYData";
            magYData.ReadOnly = true;
            magYData.Size = new Size(76, 29);
            magYData.TabIndex = 18;
            magYData.Text = "";
            // 
            // magZHeader
            // 
            magZHeader.AutoSize = true;
            magZHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            magZHeader.Location = new Point(764, 350);
            magZHeader.Name = "magZHeader";
            magZHeader.Size = new Size(66, 15);
            magZHeader.TabIndex = 21;
            magZHeader.Text = "Mag Z (uT)";
            magZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magZData
            // 
            magZData.Location = new Point(760, 368);
            magZData.Name = "magZData";
            magZData.ReadOnly = true;
            magZData.Size = new Size(76, 29);
            magZData.TabIndex = 20;
            magZData.Text = "";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.BackColor = Color.Red;
            errorLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            errorLabel.ForeColor = SystemColors.Control;
            errorLabel.Location = new Point(332, 112);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(219, 32);
            errorLabel.TabIndex = 22;
            errorLabel.Text = "Device Not Found";
            errorLabel.Visible = false;
            // 
            // bluetoothPicture
            // 
            bluetoothPicture.Image = Resource1.bluetooth_icon_low_respng;
            bluetoothPicture.Location = new Point(289, 70);
            bluetoothPicture.Margin = new Padding(3, 2, 3, 2);
            bluetoothPicture.Name = "bluetoothPicture";
            bluetoothPicture.Size = new Size(38, 32);
            bluetoothPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            bluetoothPicture.TabIndex = 23;
            bluetoothPicture.TabStop = false;
            bluetoothPicture.Visible = false;
            // 
            // imuLabel
            // 
            imuLabel.Anchor = AnchorStyles.Top;
            imuLabel.AutoSize = true;
            imuLabel.Font = new Font("Segoe UI", 20F);
            imuLabel.Location = new Point(388, 303);
            imuLabel.Name = "imuLabel";
            imuLabel.Size = new Size(67, 37);
            imuLabel.TabIndex = 24;
            imuLabel.Text = "IMU";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(391, 181);
            label1.Name = "label1";
            label1.Size = new Size(65, 37);
            label1.TabIndex = 37;
            label1.Text = "GPS";
            // 
            // elevationLabel
            // 
            elevationLabel.AutoSize = true;
            elevationLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            elevationLabel.Location = new Point(624, 232);
            elevationLabel.Name = "elevationLabel";
            elevationLabel.Size = new Size(58, 15);
            elevationLabel.TabIndex = 36;
            elevationLabel.Text = "Elevation";
            elevationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // elevationData
            // 
            elevationData.Location = new Point(615, 250);
            elevationData.Name = "elevationData";
            elevationData.ReadOnly = true;
            elevationData.Size = new Size(76, 29);
            elevationData.TabIndex = 35;
            elevationData.Text = "";
            // 
            // longitudeLabel
            // 
            longitudeLabel.AutoSize = true;
            longitudeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            longitudeLabel.Location = new Point(533, 232);
            longitudeLabel.Name = "longitudeLabel";
            longitudeLabel.Size = new Size(63, 15);
            longitudeLabel.TabIndex = 34;
            longitudeLabel.Text = "Longitude";
            longitudeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // longitudeData
            // 
            longitudeData.Location = new Point(524, 250);
            longitudeData.Name = "longitudeData";
            longitudeData.ReadOnly = true;
            longitudeData.Size = new Size(76, 29);
            longitudeData.TabIndex = 33;
            longitudeData.Text = "";
            // 
            // latitudeLabel
            // 
            latitudeLabel.AutoSize = true;
            latitudeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            latitudeLabel.Location = new Point(443, 232);
            latitudeLabel.Name = "latitudeLabel";
            latitudeLabel.Size = new Size(53, 15);
            latitudeLabel.TabIndex = 32;
            latitudeLabel.Text = "Latitude";
            latitudeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // latitudeData
            // 
            latitudeData.Location = new Point(434, 250);
            latitudeData.Name = "latitudeData";
            latitudeData.ReadOnly = true;
            latitudeData.Size = new Size(76, 29);
            latitudeData.TabIndex = 31;
            latitudeData.Text = "";
            // 
            // satellitesLabel
            // 
            satellitesLabel.AutoSize = true;
            satellitesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            satellitesLabel.Location = new Point(350, 232);
            satellitesLabel.Name = "satellitesLabel";
            satellitesLabel.Size = new Size(58, 15);
            satellitesLabel.TabIndex = 30;
            satellitesLabel.Text = "Satellites";
            satellitesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // satellitesData
            // 
            satellitesData.Location = new Point(341, 250);
            satellitesData.Name = "satellitesData";
            satellitesData.ReadOnly = true;
            satellitesData.Size = new Size(76, 29);
            satellitesData.TabIndex = 29;
            satellitesData.Text = "";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeLabel.Location = new Point(258, 232);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(35, 15);
            timeLabel.TabIndex = 28;
            timeLabel.Text = "Time";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeData
            // 
            timeData.Location = new Point(241, 250);
            timeData.Name = "timeData";
            timeData.ReadOnly = true;
            timeData.Size = new Size(76, 29);
            timeData.TabIndex = 27;
            timeData.Text = "";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateLabel.Location = new Point(160, 232);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(34, 15);
            dateLabel.TabIndex = 26;
            dateLabel.Text = "Date";
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateData
            // 
            dateData.Location = new Point(143, 250);
            dateData.Name = "dateData";
            dateData.ReadOnly = true;
            dateData.Size = new Size(76, 29);
            dateData.TabIndex = 25;
            dateData.Text = "";
            // 
            // DataPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(elevationLabel);
            Controls.Add(elevationData);
            Controls.Add(longitudeLabel);
            Controls.Add(longitudeData);
            Controls.Add(latitudeLabel);
            Controls.Add(latitudeData);
            Controls.Add(satellitesLabel);
            Controls.Add(satellitesData);
            Controls.Add(timeLabel);
            Controls.Add(timeData);
            Controls.Add(dateLabel);
            Controls.Add(dateData);
            Controls.Add(imuLabel);
            Controls.Add(bluetoothPicture);
            Controls.Add(errorLabel);
            Controls.Add(magZHeader);
            Controls.Add(magZData);
            Controls.Add(magYHeader);
            Controls.Add(magYData);
            Controls.Add(magXHeader);
            Controls.Add(magXData);
            Controls.Add(gyroZHeader);
            Controls.Add(gyroZData);
            Controls.Add(gyroYHeader);
            Controls.Add(gyroYData);
            Controls.Add(gyroXHeader);
            Controls.Add(gyroXData);
            Controls.Add(accelZHeader);
            Controls.Add(accelZData);
            Controls.Add(accelYHeader);
            Controls.Add(accelYData);
            Controls.Add(accelXHeader);
            Controls.Add(accelXData);
            Controls.Add(usbDevices);
            Controls.Add(backButton);
            Controls.Add(measurmentLabel);
            Name = "DataPanel";
            Size = new Size(859, 525);
            Load += DataPanel_Load;
            VisibleChanged += DataPanel_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)bluetoothPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label measurmentLabel;
        private Button backButton;
        private TextBox usbDevices;
        private System.Windows.Forms.Timer deviceTimer;
        private RichTextBox accelXData;
        private Label accelXHeader;
        private Label accelYHeader;
        private RichTextBox accelYData;
        private Label accelZHeader;
        private RichTextBox accelZData;
        private Label gyroXHeader;
        private RichTextBox gyroXData;
        private Label gyroYHeader;
        private RichTextBox gyroYData;
        private Label gyroZHeader;
        private RichTextBox gyroZData;
        private Label magXHeader;
        private RichTextBox magXData;
        private Label magYHeader;
        private RichTextBox magYData;
        private Label magZHeader;
        private RichTextBox magZData;
        private Label errorLabel;
        private PictureBox bluetoothPicture;
        private Label imuLabel;
        private Label label1;
        private Label elevationLabel;
        private RichTextBox elevationData;
        private Label longitudeLabel;
        private RichTextBox longitudeData;
        private Label latitudeLabel;
        private RichTextBox latitudeData;
        private Label satellitesLabel;
        private RichTextBox satellitesData;
        private Label timeLabel;
        private RichTextBox timeData;
        private Label dateLabel;
        private RichTextBox dateData;
    }
}
