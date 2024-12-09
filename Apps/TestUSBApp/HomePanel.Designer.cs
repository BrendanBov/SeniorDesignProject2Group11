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
            startButton.Anchor = AnchorStyles.Top;
            startButton.Location = new Point(250, 383);
            startButton.Margin = new Padding(3, 4, 3, 4);
            startButton.Name = "startButton";
            startButton.Size = new Size(246, 81);
            startButton.TabIndex = 2;
            startButton.Text = "Show Measurements";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // quitButton
            // 
            quitButton.Anchor = AnchorStyles.Top;
            quitButton.Location = new Point(692, 381);
            quitButton.Margin = new Padding(3, 4, 3, 4);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(230, 83);
            quitButton.TabIndex = 3;
            quitButton.Text = "Quit Program";
            quitButton.UseVisualStyleBackColor = true;
            quitButton.Click += quitButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.Anchor = AnchorStyles.Top;
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 25F);
            titleLabel.Location = new Point(336, 95);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(599, 57);
            titleLabel.TabIndex = 4;
            titleLabel.Text = "Localization Device Application";
            // 
            // HomePanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(titleLabel);
            Controls.Add(quitButton);
            Controls.Add(startButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HomePanel";
            Size = new Size(1208, 724);
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
