using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUSBApp
{
    public partial class DataPanel : UserControl
    {
        public DataPanel()
        {
            InitializeComponent();
        }

        /*void Temp()
        {
            String[] ports = SerialPort.GetPortNames();
            usbDevices.Clear();
            MessageBox.Show(ports.Length.ToString());
            foreach (string port in ports)
                usbDevices.AppendText(port + "\r\n");
            if(ports.Length > 0) MessageBox.Show(ports.First());
        }*/

        //https://www.youtube.com/watch?v=3SQayMiapKQ

        List<string> portnames = new();

        private void InitializeUSB()
        {
            portnames = GetPorts();
            usbDevices.Clear();
            foreach (string port in portnames)
            {
                usbDevices.AppendText(port + "\r\n");
            }

            //MessageBox.Show(portnames.Count.ToString());
        }

        private List<string> GetPorts()
        {
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM " +
                "Win32_PnPEntity WHERE Caption like '%(COM%'"))
            {
                string[] portnames = SerialPort.GetPortNames();
                var ports = searcher.Get().Cast<ManagementBaseObject>().ToList().Select(p => p["Caption"].ToString());
                List<string> portList = portnames.Select(n => n + " - " + ports.FirstOrDefault(s => s.Contains(n))).ToList();

                return portList;
            }
        }
        

        private void backButton_Click(object sender, EventArgs e)
        {
            HomeMenu.singleton.dataPanel.Hide();
            HomeMenu.singleton.homePanel1.Show();
        }

        private void DataPanel_Load(object sender, EventArgs e)
        {

        }

        private void DataPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) InitializeUSB();
            //if (this.Visible) Temp();
        }
    }
}
