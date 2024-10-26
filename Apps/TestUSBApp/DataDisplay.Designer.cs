namespace TestUSBApp
{
    partial class DataDisplay
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
            measurmentLabel = new Label();
            backButton = new Button();
            SuspendLayout();
            // 
            // measurmentLabel
            // 
            measurmentLabel.AutoSize = true;
            measurmentLabel.Font = new Font("Segoe UI", 25F);
            measurmentLabel.Location = new Point(280, 21);
            measurmentLabel.Name = "measurmentLabel";
            measurmentLabel.Size = new Size(223, 46);
            measurmentLabel.TabIndex = 0;
            measurmentLabel.Text = "Measurments";
            // 
            // backButton
            // 
            backButton.Location = new Point(349, 373);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 45);
            backButton.TabIndex = 1;
            backButton.Text = "Back to Home";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // DataDisplay
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backButton);
            Controls.Add(measurmentLabel);
            Name = "DataDisplay";
            Text = "DataDisplay";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label measurmentLabel;
        private Button backButton;
    }
}