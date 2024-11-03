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
        private SerialPort activePort;
        private SerialPort usbPort = new("COM3", 9600);
        private SerialPort bluetoothPort = new("COM4", 9600);

        private RichTextBox[] dataFields;

        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string logHeader = "X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)";

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
            /*portnames = GetPorts();
            usbDevices.Clear();
            foreach (string port in portnames)
            {
                usbDevices.AppendText(port + "\r\n");
            }*/


            activePort = usbPort;
            try
            {
                activePort.Open();
                errorLabel.Visible = false;
            }
            catch
            {
                // TODO: consider opening a thread for bluetooth search
                // causes other elements to not load until process is done
                activePort = bluetoothPort;
                try
                {
                    activePort.Open();
                    errorLabel.Visible = false;
                    bluetoothPicture.Visible = true;
                }
                catch
                {
                    errorLabel.Visible = true;
                }
                //MessageBox.Show("no device found");
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
            dataFields = [accelXData, accelYData, accelZData, gyroXData, gyroYData, gyroZData, magXData, magYData, magZData];
        }

        private void DataPanel_VisibleChanged(object sender, EventArgs e)
        {
            deviceTimer.Enabled = this.Visible;
            if (this.Visible) InitializeUSB();
            else if (activePort != null) activePort.Close();
            //if (this.Visible) Temp();
        }

        private void deviceTimer_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (!activePort.IsOpen)
            {
                errorLabel.Visible = true;
                return;
            }

            errorLabel.Visible = false;
            HandleData();

        }

        private void HandleData()
        {
            // check for expected serial data format
            string data;
            while (true)
            {
                data = activePort.ReadLine();
                if (!string.IsNullOrEmpty(data)) break;
            }

            //usbDevices.AppendText(data);

            string[] fields = data.Split(',');
            if (fields.Length < 9) return;
            if (dataFields.Length < 9) return;

            // display data in fields
            for (int i = 0; i < 9; i++)
                dataFields[i].Text = fields[i];

            //TODO verify this output file is the same as the one on the SD card
            // write to log file
            string toWrite = File.Exists(Path.Combine(filePath, "log.csv")) ? data : logHeader;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "log.csv"), true))
            {
                outputFile.WriteLine(toWrite);
            }
        }
    }
}
