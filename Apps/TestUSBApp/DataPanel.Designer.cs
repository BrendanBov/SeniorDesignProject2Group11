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
            backButton.Location = new Point(463, 568);
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
            accelXData.Location = new Point(18, 388);
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
            accelXHeader.Location = new Point(8, 364);
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
            accelYHeader.Location = new Point(120, 364);
            accelYHeader.Name = "accelYHeader";
            accelYHeader.Size = new Size(124, 20);
            accelYHeader.TabIndex = 7;
            accelYHeader.Text = "Accel X (m/s^2)";
            accelYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelYData
            // 
            accelYData.Location = new Point(130, 388);
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
            accelZHeader.Location = new Point(234, 364);
            accelZHeader.Name = "accelZHeader";
            accelZHeader.Size = new Size(123, 20);
            accelZHeader.TabIndex = 9;
            accelZHeader.Text = "Accel Z (m/s^2)";
            accelZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelZData
            // 
            accelZData.Location = new Point(245, 388);
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
            gyroXHeader.Location = new Point(347, 364);
            gyroXHeader.Name = "gyroXHeader";
            gyroXHeader.Size = new Size(110, 20);
            gyroXHeader.TabIndex = 11;
            gyroXHeader.Text = "Gyro X (rad/s)";
            gyroXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroXData
            // 
            gyroXData.Location = new Point(351, 388);
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
            gyroYHeader.Location = new Point(450, 364);
            gyroYHeader.Name = "gyroYHeader";
            gyroYHeader.Size = new Size(109, 20);
            gyroYHeader.TabIndex = 13;
            gyroYHeader.Text = "Gyro Y (rad/s)";
            gyroYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroYData
            // 
            gyroYData.Location = new Point(454, 388);
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
            gyroZHeader.Location = new Point(554, 364);
            gyroZHeader.Name = "gyroZHeader";
            gyroZHeader.Size = new Size(109, 20);
            gyroZHeader.TabIndex = 15;
            gyroZHeader.Text = "Gyro Z (rad/s)";
            gyroZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroZData
            // 
            gyroZData.Location = new Point(558, 388);
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
            magXHeader.Location = new Point(669, 364);
            magXHeader.Name = "magXHeader";
            magXHeader.Size = new Size(88, 20);
            magXHeader.TabIndex = 17;
            magXHeader.Text = "Mag X (uT)";
            magXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magXData
            // 
            magXData.Location = new Point(664, 388);
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
            magYHeader.Location = new Point(774, 364);
            magYHeader.Name = "magYHeader";
            magYHeader.Size = new Size(87, 20);
            magYHeader.TabIndex = 19;
            magYHeader.Text = "Mag Y (uT)";
            magYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magYData
            // 
            magYData.Location = new Point(769, 388);
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
            magZHeader.Location = new Point(880, 364);
            magZHeader.Name = "magZHeader";
            magZHeader.Size = new Size(87, 20);
            magZHeader.TabIndex = 21;
            magZHeader.Text = "Mag Z (uT)";
            magZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magZData
            // 
            magZData.Location = new Point(875, 388);
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
            errorLabel.Location = new Point(379, 268);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(270, 41);
            errorLabel.TabIndex = 22;
            errorLabel.Text = "Device Not Found";
            errorLabel.Visible = false;
            // 
            // bluetoothPicture
            // 
            bluetoothPicture.Image = Resource1.bluetooth_icon_low_respng;
            bluetoothPicture.Location = new Point(330, 266);
            bluetoothPicture.Name = "bluetoothPicture";
            bluetoothPicture.Size = new Size(43, 43);
            bluetoothPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            bluetoothPicture.TabIndex = 23;
            bluetoothPicture.TabStop = false;
            bluetoothPicture.Visible = false;
            // 
            // DataPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
