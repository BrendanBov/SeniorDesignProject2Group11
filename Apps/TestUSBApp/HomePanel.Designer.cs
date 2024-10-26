namespace TestUSBApp
{
    partial class HomePanel
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
            startButton = new Button();
            quitButton = new Button();
            titleLabel = new Label();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(63, 273);
            startButton.Name = "startButton";
            startButton.Size = new Size(152, 36);
            startButton.TabIndex = 2;
            startButton.Text = "Show Measurements";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // quitButton
            // 
            quitButton.Location = new Point(375, 273);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(125, 37);
            quitButton.TabIndex = 3;
            quitButton.Text = "Quit Program";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 25F);
            titleLabel.Location = new Point(189, 45);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(219, 46);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Test USB App";
            // 
            // HomePanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLabel);
            Controls.Add(quitButton);
            Controls.Add(startButton);
            Name = "HomePanel";
            Size = new Size(607, 446);
            Load += HomePanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button quitButton;
        private Label titleLabel;
    }
}
