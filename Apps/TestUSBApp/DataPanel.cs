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
        const int baudrate = 115200; //19200; //9600; 
        private SerialPort activePort;
        private SerialPort usbPort = new("COM6", baudrate);
        private SerialPort bluetoothPort = new("COM5", baudrate);

        private RichTextBox[] dataFields;

        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        const string logHeader = "Date,Time,Latiude,Longitude,Satellites,Elevation (m),X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)";

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
            /*
            portnames = GetPorts();
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
                bluetoothPicture.Visible = false;
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
            dataFields = [dateData, timeData, latitudeData, longitudeData, satellitesData, elevationData, accelXData, accelYData, accelZData, gyroXData, gyroYData, gyroZData, magXData, magYData, magZData];
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
            string data = "";
            // TODO: consider opening a thread for serial polling
            // causes elements to not be interactive 

            /*while (true)
            {
                data = activePort.ReadLine();
                //usbDevices.AppendText(data);
                if (!string.IsNullOrEmpty(data)) break;
            }*/


            if (activePort.BytesToRead <= 0) return;
            data = activePort.ReadLine();
            if (string.IsNullOrEmpty(data)) return;

            //susbDevices.AppendText(data);
            

            /*while(activePort.BytesToRead > 0)
            {
                data += activePort.ReadChar();
            }
            usbDevices.AppendText(data);*/

            string[] fields = data.Split(',');
            if (fields.Length < 15) return;
            if (dataFields.Length < 15) return;

            // display data in fields
            for (int i = 0; i < 15; i++)
                dataFields[i].Text = fields[i];

            // lat (2), lon (3)
            char[] lat = dataFields[2].Text.ToCharArray();
            char[] lon = dataFields[3].Text.ToCharArray();

            // change ascii degree symbol to unicode
            if (lat.Length >= 3) lat[2] = '°';
            if (lon.Length >= 4) lon[3] = '°';

            dataFields[2].Text = new(lat);
            dataFields[3].Text = new(lon);

            // Creates log file if it doesnt exists in documents, append data to file
            string toWrite = File.Exists(Path.Combine(filePath, "log.csv")) ? data : logHeader;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(filePath, "log.csv"), true))
            {
                outputFile.WriteLine(toWrite);
            }
        }
    }
}
