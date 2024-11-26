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
            measurmentLabel.Location = new Point(375, 75);
            measurmentLabel.Name = "measurmentLabel";
            measurmentLabel.Size = new Size(277, 57);
            measurmentLabel.TabIndex = 1;
            measurmentLabel.Text = "Measurments";
            // 
            // backButton
            // 
            backButton.Location = new Point(443, 575);
            backButton.Margin = new Padding(3, 4, 3, 4);
            backButton.Name = "backButton";
            backButton.Size = new Size(107, 60);
            backButton.TabIndex = 2;
            backButton.Text = "Back to Home";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // usbDevices
            // 
            usbDevices.Location = new Point(3, 4);
            usbDevices.Margin = new Padding(3, 4, 3, 4);
            usbDevices.Multiline = true;
            usbDevices.Name = "usbDevices";
            usbDevices.ReadOnly = true;
            usbDevices.Size = new Size(225, 187);
            usbDevices.TabIndex = 3;
            usbDevices.Visible = false;
            // 
            // deviceTimer
            // 
            deviceTimer.Tick += deviceTimer_Tick;
            // 
            // accelXData
            // 
            accelXData.Location = new Point(11, 491);
            accelXData.Margin = new Padding(3, 4, 3, 4);
            accelXData.Name = "accelXData";
            accelXData.ReadOnly = true;
            accelXData.Size = new Size(86, 37);
            accelXData.TabIndex = 4;
            accelXData.Text = "";
            // 
            // accelXHeader
            // 
            accelXHeader.AutoSize = true;
            accelXHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accelXHeader.Location = new Point(1, 467);
            accelXHeader.Name = "accelXHeader";
            accelXHeader.Size = new Size(124, 20);
            accelXHeader.TabIndex = 5;
            accelXHeader.Text = "Accel X (m/s^2)";
            accelXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelYHeader
            // 
            accelYHeader.AutoSize = true;
            accelYHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accelYHeader.Location = new Point(113, 467);
            accelYHeader.Name = "accelYHeader";
            accelYHeader.Size = new Size(124, 20);
            accelYHeader.TabIndex = 7;
            accelYHeader.Text = "Accel X (m/s^2)";
            accelYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelYData
            // 
            accelYData.Location = new Point(123, 491);
            accelYData.Margin = new Padding(3, 4, 3, 4);
            accelYData.Name = "accelYData";
            accelYData.ReadOnly = true;
            accelYData.Size = new Size(86, 37);
            accelYData.TabIndex = 6;
            accelYData.Text = "";
            // 
            // accelZHeader
            // 
            accelZHeader.AutoSize = true;
            accelZHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accelZHeader.Location = new Point(227, 467);
            accelZHeader.Name = "accelZHeader";
            accelZHeader.Size = new Size(123, 20);
            accelZHeader.TabIndex = 9;
            accelZHeader.Text = "Accel Z (m/s^2)";
            accelZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelZData
            // 
            accelZData.Location = new Point(238, 491);
            accelZData.Margin = new Padding(3, 4, 3, 4);
            accelZData.Name = "accelZData";
            accelZData.ReadOnly = true;
            accelZData.Size = new Size(86, 37);
            accelZData.TabIndex = 8;
            accelZData.Text = "";
            // 
            // gyroXHeader
            // 
            gyroXHeader.AutoSize = true;
            gyroXHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gyroXHeader.Location = new Point(341, 467);
            gyroXHeader.Name = "gyroXHeader";
            gyroXHeader.Size = new Size(110, 20);
            gyroXHeader.TabIndex = 11;
            gyroXHeader.Text = "Gyro X (rad/s)";
            gyroXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroXData
            // 
            gyroXData.Location = new Point(344, 491);
            gyroXData.Margin = new Padding(3, 4, 3, 4);
            gyroXData.Name = "gyroXData";
            gyroXData.ReadOnly = true;
            gyroXData.Size = new Size(86, 37);
            gyroXData.TabIndex = 10;
            gyroXData.Text = "";
            // 
            // gyroYHeader
            // 
            gyroYHeader.AutoSize = true;
            gyroYHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gyroYHeader.Location = new Point(443, 467);
            gyroYHeader.Name = "gyroYHeader";
            gyroYHeader.Size = new Size(109, 20);
            gyroYHeader.TabIndex = 13;
            gyroYHeader.Text = "Gyro Y (rad/s)";
            gyroYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroYData
            // 
            gyroYData.Location = new Point(447, 491);
            gyroYData.Margin = new Padding(3, 4, 3, 4);
            gyroYData.Name = "gyroYData";
            gyroYData.ReadOnly = true;
            gyroYData.Size = new Size(86, 37);
            gyroYData.TabIndex = 12;
            gyroYData.Text = "";
            // 
            // gyroZHeader
            // 
            gyroZHeader.AutoSize = true;
            gyroZHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gyroZHeader.Location = new Point(547, 467);
            gyroZHeader.Name = "gyroZHeader";
            gyroZHeader.Size = new Size(109, 20);
            gyroZHeader.TabIndex = 15;
            gyroZHeader.Text = "Gyro Z (rad/s)";
            gyroZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroZData
            // 
            gyroZData.Location = new Point(551, 491);
            gyroZData.Margin = new Padding(3, 4, 3, 4);
            gyroZData.Name = "gyroZData";
            gyroZData.ReadOnly = true;
            gyroZData.Size = new Size(86, 37);
            gyroZData.TabIndex = 14;
            gyroZData.Text = "";
            // 
            // magXHeader
            // 
            magXHeader.AutoSize = true;
            magXHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            magXHeader.Location = new Point(662, 467);
            magXHeader.Name = "magXHeader";
            magXHeader.Size = new Size(88, 20);
            magXHeader.TabIndex = 17;
            magXHeader.Text = "Mag X (uT)";
            magXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magXData
            // 
            magXData.Location = new Point(657, 491);
            magXData.Margin = new Padding(3, 4, 3, 4);
            magXData.Name = "magXData";
            magXData.ReadOnly = true;
            magXData.Size = new Size(86, 37);
            magXData.TabIndex = 16;
            magXData.Text = "";
            // 
            // magYHeader
            // 
            magYHeader.AutoSize = true;
            magYHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            magYHeader.Location = new Point(767, 467);
            magYHeader.Name = "magYHeader";
            magYHeader.Size = new Size(87, 20);
            magYHeader.TabIndex = 19;
            magYHeader.Text = "Mag Y (uT)";
            magYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magYData
            // 
            magYData.Location = new Point(762, 491);
            magYData.Margin = new Padding(3, 4, 3, 4);
            magYData.Name = "magYData";
            magYData.ReadOnly = true;
            magYData.Size = new Size(86, 37);
            magYData.TabIndex = 18;
            magYData.Text = "";
            // 
            // magZHeader
            // 
            magZHeader.AutoSize = true;
            magZHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            magZHeader.Location = new Point(873, 467);
            magZHeader.Name = "magZHeader";
            magZHeader.Size = new Size(87, 20);
            magZHeader.TabIndex = 21;
            magZHeader.Text = "Mag Z (uT)";
            magZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magZData
            // 
            magZData.Location = new Point(869, 491);
            magZData.Margin = new Padding(3, 4, 3, 4);
            magZData.Name = "magZData";
            magZData.ReadOnly = true;
            magZData.Size = new Size(86, 37);
            magZData.TabIndex = 20;
            magZData.Text = "";
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.BackColor = Color.Red;
            errorLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            errorLabel.ForeColor = SystemColors.Control;
            errorLabel.Location = new Point(379, 149);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(270, 41);
            errorLabel.TabIndex = 22;
            errorLabel.Text = "Device Not Found";
            errorLabel.Visible = false;
            // 
            // bluetoothPicture
            // 
            bluetoothPicture.Image = Resource1.bluetooth_icon_low_respng;
            bluetoothPicture.Location = new Point(238, 89);
            bluetoothPicture.Name = "bluetoothPicture";
            bluetoothPicture.Size = new Size(43, 43);
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
            imuLabel.Location = new Point(443, 404);
            imuLabel.Name = "imuLabel";
            imuLabel.Size = new Size(83, 46);
            imuLabel.TabIndex = 24;
            imuLabel.Text = "IMU";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(447, 241);
            label1.Name = "label1";
            label1.Size = new Size(80, 46);
            label1.TabIndex = 37;
            label1.Text = "GPS";
            // 
            // elevationLabel
            // 
            elevationLabel.AutoSize = true;
            elevationLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            elevationLabel.Location = new Point(741, 309);
            elevationLabel.Name = "elevationLabel";
            elevationLabel.Size = new Size(73, 20);
            elevationLabel.TabIndex = 36;
            elevationLabel.Text = "Elevation";
            elevationLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // elevationData
            // 
            elevationData.Location = new Point(713, 333);
            elevationData.Margin = new Padding(3, 4, 3, 4);
            elevationData.Name = "elevationData";
            elevationData.ReadOnly = true;
            elevationData.Size = new Size(116, 37);
            elevationData.TabIndex = 35;
            elevationData.Text = "";
            // 
            // longitudeLabel
            // 
            longitudeLabel.AutoSize = true;
            longitudeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            longitudeLabel.Location = new Point(453, 309);
            longitudeLabel.Name = "longitudeLabel";
            longitudeLabel.Size = new Size(80, 20);
            longitudeLabel.TabIndex = 34;
            longitudeLabel.Text = "Longitude";
            longitudeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // longitudeData
            // 
            longitudeData.Location = new Point(441, 333);
            longitudeData.Margin = new Padding(3, 4, 3, 4);
            longitudeData.Name = "longitudeData";
            longitudeData.ReadOnly = true;
            longitudeData.Size = new Size(116, 37);
            longitudeData.TabIndex = 33;
            longitudeData.Text = "";
            // 
            // latitudeLabel
            // 
            latitudeLabel.AutoSize = true;
            latitudeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            latitudeLabel.Location = new Point(344, 309);
            latitudeLabel.Name = "latitudeLabel";
            latitudeLabel.Size = new Size(67, 20);
            latitudeLabel.TabIndex = 32;
            latitudeLabel.Text = "Latitude";
            latitudeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // latitudeData
            // 
            latitudeData.Location = new Point(314, 333);
            latitudeData.Margin = new Padding(3, 4, 3, 4);
            latitudeData.Name = "latitudeData";
            latitudeData.ReadOnly = true;
            latitudeData.Size = new Size(116, 37);
            latitudeData.TabIndex = 31;
            latitudeData.Text = "";
            // 
            // satellitesLabel
            // 
            satellitesLabel.AutoSize = true;
            satellitesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            satellitesLabel.Location = new Point(595, 309);
            satellitesLabel.Name = "satellitesLabel";
            satellitesLabel.Size = new Size(72, 20);
            satellitesLabel.TabIndex = 30;
            satellitesLabel.Text = "Satellites";
            satellitesLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // satellitesData
            // 
            satellitesData.Location = new Point(575, 333);
            satellitesData.Margin = new Padding(3, 4, 3, 4);
            satellitesData.Name = "satellitesData";
            satellitesData.ReadOnly = true;
            satellitesData.Size = new Size(116, 37);
            satellitesData.TabIndex = 29;
            satellitesData.Text = "";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeLabel.Location = new Point(227, 309);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(44, 20);
            timeLabel.TabIndex = 28;
            timeLabel.Text = "Time";
            timeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timeData
            // 
            timeData.Location = new Point(185, 333);
            timeData.Margin = new Padding(3, 4, 3, 4);
            timeData.Name = "timeData";
            timeData.ReadOnly = true;
            timeData.Size = new Size(116, 37);
            timeData.TabIndex = 27;
            timeData.Text = "";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateLabel.Location = new Point(83, 309);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(42, 20);
            dateLabel.TabIndex = 26;
            dateLabel.Text = "Date";
            dateLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateData
            // 
            dateData.Location = new Point(50, 333);
            dateData.Margin = new Padding(3, 4, 3, 4);
            dateData.Name = "dateData";
            dateData.ReadOnly = true;
            dateData.Size = new Size(116, 37);
            dateData.TabIndex = 25;
            dateData.Text = "";
            // 
            // DataPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "DataPanel";
            Size = new Size(982, 700);
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
