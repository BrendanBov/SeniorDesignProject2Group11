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
            measurmentLabel = new Label();
            backButton = new Button();
            usbDevices = new TextBox();
            SuspendLayout();
            // 
            // measurmentLabel
            // 
            measurmentLabel.Anchor = AnchorStyles.Top;
            measurmentLabel.AutoSize = true;
            measurmentLabel.Font = new Font("Segoe UI", 25F);
            measurmentLabel.Location = new Point(254, 56);
            measurmentLabel.Name = "measurmentLabel";
            measurmentLabel.Size = new Size(223, 46);
            measurmentLabel.TabIndex = 1;
            measurmentLabel.Text = "Measurments";
            // 
            // backButton
            // 
            backButton.Location = new Point(320, 379);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 45);
            backButton.TabIndex = 2;
            backButton.Text = "Back to Home";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // usbDevices
            // 
            usbDevices.Location = new Point(171, 131);
            usbDevices.Multiline = true;
            usbDevices.Name = "usbDevices";
            usbDevices.Size = new Size(388, 203);
            usbDevices.TabIndex = 3;
            // 
            // DataPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(usbDevices);
            Controls.Add(backButton);
            Controls.Add(measurmentLabel);
            Name = "DataPanel";
            Size = new Size(711, 459);
            Load += DataPanel_Load;
            VisibleChanged += DataPanel_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label measurmentLabel;
        private Button backButton;
        private TextBox usbDevices;
    }
}
