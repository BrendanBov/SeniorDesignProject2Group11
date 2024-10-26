namespace TestUSBApp
{
    public partial class HomeMenu : Form
    {
        public static HomeMenu? singleton;

        public HomeMenu()
        {
            InitializeComponent();
            singleton = this;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
