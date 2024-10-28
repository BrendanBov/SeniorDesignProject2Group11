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
            backButton.Location = new Point(405, 426);
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
            accelXData.Location = new Point(16, 291);
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
            accelXHeader.Location = new Point(7, 273);
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
            accelYHeader.Location = new Point(105, 273);
            accelYHeader.Name = "accelYHeader";
            accelYHeader.Size = new Size(95, 15);
            accelYHeader.TabIndex = 7;
            accelYHeader.Text = "Accel X (m/s^2)";
            accelYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelYData
            // 
            accelYData.Location = new Point(114, 291);
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
            accelZHeader.Location = new Point(205, 273);
            accelZHeader.Name = "accelZHeader";
            accelZHeader.Size = new Size(94, 15);
            accelZHeader.TabIndex = 9;
            accelZHeader.Text = "Accel Z (m/s^2)";
            accelZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // accelZData
            // 
            accelZData.Location = new Point(214, 291);
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
            gyroXHeader.Location = new Point(304, 273);
            gyroXHeader.Name = "gyroXHeader";
            gyroXHeader.Size = new Size(84, 15);
            gyroXHeader.TabIndex = 11;
            gyroXHeader.Text = "Gyro X (rad/s)";
            gyroXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroXData
            // 
            gyroXData.Location = new Point(307, 291);
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
            gyroYHeader.Location = new Point(394, 273);
            gyroYHeader.Name = "gyroYHeader";
            gyroYHeader.Size = new Size(83, 15);
            gyroYHeader.TabIndex = 13;
            gyroYHeader.Text = "Gyro Y (rad/s)";
            gyroYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroYData
            // 
            gyroYData.Location = new Point(397, 291);
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
            gyroZHeader.Location = new Point(485, 273);
            gyroZHeader.Name = "gyroZHeader";
            gyroZHeader.Size = new Size(83, 15);
            gyroZHeader.TabIndex = 15;
            gyroZHeader.Text = "Gyro Z (rad/s)";
            gyroZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gyroZData
            // 
            gyroZData.Location = new Point(488, 291);
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
            magXHeader.Location = new Point(585, 273);
            magXHeader.Name = "magXHeader";
            magXHeader.Size = new Size(67, 15);
            magXHeader.TabIndex = 17;
            magXHeader.Text = "Mag X (uT)";
            magXHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magXData
            // 
            magXData.Location = new Point(581, 291);
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
            magYHeader.Location = new Point(677, 273);
            magYHeader.Name = "magYHeader";
            magYHeader.Size = new Size(66, 15);
            magYHeader.TabIndex = 19;
            magYHeader.Text = "Mag Y (uT)";
            magYHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magYData
            // 
            magYData.Location = new Point(673, 291);
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
            magZHeader.Location = new Point(770, 273);
            magZHeader.Name = "magZHeader";
            magZHeader.Size = new Size(66, 15);
            magZHeader.TabIndex = 21;
            magZHeader.Text = "Mag Z (uT)";
            magZHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // magZData
            // 
            magZData.Location = new Point(766, 291);
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
            errorLabel.Location = new Point(332, 201);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(219, 32);
            errorLabel.TabIndex = 22;
            errorLabel.Text = "Device Not Found";
            errorLabel.Visible = false;
            // 
            // DataPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
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
    }
}
