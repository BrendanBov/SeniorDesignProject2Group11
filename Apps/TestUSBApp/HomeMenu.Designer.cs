namespace TestUSBApp
{
    partial class HomeMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataPanel = new DataPanel();
            homePanel1 = new HomePanel();
            SuspendLayout();
            // 
            // dataPanel
            // 
            dataPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            dataPanel.Location = new Point(-1, -1);
            dataPanel.Name = "dataPanel";
            dataPanel.Size = new Size(853, 531);
            dataPanel.TabIndex = 0;
            dataPanel.Visible = false;
            // 
            // homePanel1
            // 
            homePanel1.Location = new Point(-1, -1);
            homePanel1.Name = "homePanel1";
            homePanel1.Size = new Size(853, 531);
            homePanel1.TabIndex = 1;
            // 
            // HomeMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(851, 527);
            Controls.Add(homePanel1);
            Controls.Add(dataPanel);
            Name = "HomeMenu";
            Text = "Localization Device Application";
            ResumeLayout(false);
        }

        #endregion
        public HomePanel homePanel1;
        public DataPanel dataPanel;
    }
}
