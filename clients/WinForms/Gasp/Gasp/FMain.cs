// This application receives temperature and humidity measures from an Arduino board, connected to a USB port,
// and sends these data to the web service, together with latitude and longitude.
//
// By Everlyn Chiang and Adail Retamal
// 23-24/Apr/2016 NASA Space Apps Challenge Sydney

using System;
using System.Windows.Forms;
using System.Device.Location;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net;
using Newtonsoft.Json;

namespace Gasp
{
    public partial class FMain : Form
    {
        private string webServiceURL = "http://nasapi.herokuapp.com/";
        
        private GeoCoordinateWatcher Watcher = null;
        private double temperature, humidity;
        private string latitude, longitude;
        
        public delegate void UpdateLabelsDelegate();
        private UpdateLabelsDelegate updateLabelsDelegate;

        public delegate void UpdateLogDelegate(string msg);
        private UpdateLogDelegate updateLogDelegate;

        public FMain()
        {
            InitializeComponent();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Log("Gasp! Monitoring Station started");

            this.updateLabelsDelegate = new UpdateLabelsDelegate(UpdateLabels);

            this.updateLogDelegate = new UpdateLogDelegate(UpdateLog);

            //get location and show latitude and longitude
            GetLocationProperty();

            try
            {
                serialPortSensor.Open();
                Log("Using serial port " + serialPortSensor.PortName);

            }
            catch (Exception error)
            {
                Log(error.Message);
            }
        }


        //get location
        private void GetLocationProperty()
        {          
            // Create the watcher.
            Watcher = new GeoCoordinateWatcher();
            
            // Catch the StatusChanged event.
            Watcher.StatusChanged += Watcher_StatusChanged;

            // Start the watcher.
            Watcher.Start();
        }

        // The watcher's status has changed. See if it is ready.
        private void Watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
                // Display the latitude and longitude.
                if (Watcher.Position.Location.IsUnknown)
                {
                    Log("Cannot find location data");
                }
                else
                {
                    latitude = Watcher.Position.Location.Latitude.ToString();
                    longitude = Watcher.Position.Location.Longitude.ToString();
                    lblLatitude.Text = (latitude == null ? "Unknown" : latitude);
                    lblLongitude.Text = (longitude == null ? "Unknown" : longitude);
                }
            }
        }

        //retrieve temperature and humidity data from Arduino
        private void DecodeSensorData(string dataFromSensor, out double temp, out double hum)
        {
            //separete temperature and humidity and save in array
            String[] dataHumTemp = dataFromSensor.Split(',');

            //get temperature and humidity
            hum = Convert.ToDouble(dataHumTemp[0]);
            temp = Convert.ToDouble(dataHumTemp[1]);
        }

        //post sensor data to URL
        private bool SendSensorDataToServer(double temp, double hum)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var data = new { 
                    tempC = temp,
                    humidity = hum,
                    latitude = latitude,
                    longitude = longitude
                };

                try
                {
                    string response = client.UploadString(webServiceURL + "sensors", "POST", JsonConvert.SerializeObject(data));
                    string msg = "Sensor data sent: T: " + temp.ToString() + " - H: " + hum.ToString();
                    txtHistory.Invoke(updateLogDelegate, new object[] { msg });
                    return true;
                }
                catch (Exception ex)
                {
                    string msg = "Error sending sensor data: " + ex.Message;
                    txtHistory.Invoke(updateLogDelegate, new object[] { msg });
                    return false;
                }
            }
        }


        public void UpdateLabels()
        {
            lblTemperature.Text = temperature.ToString() + "°C";
            lblHumidity.Text = humidity.ToString() + "%";
            gauTemperature.Value = Convert.ToInt32(temperature);
        }


        public void UpdateLog(string msg)
        {
            Log(msg);
        }


        private void serialPortSensor_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //read data from serialport arduino
            string sensorData = serialPortSensor.ReadLine().ToString();
            if (sensorData.StartsWith("Error"))
            {
                Log(sensorData);
            }
            else
            {
                DecodeSensorData(sensorData, out temperature, out humidity);

                // Update labels
                lblTemperature.Invoke(this.updateLabelsDelegate);

                SendSensorDataToServer(temperature, humidity);
            }
        }

        
        private void Log(string msg)
        {
            txtHistory.AppendText(DateTime.Now.ToString("dd/MMM/yy hh:mm:ss") + "> " + msg + "\n");
            txtHistory.ScrollToCaret();
        }

        private RadioButton GetSelectedRadioButton(Control container) 
        {
            foreach (Control c in container.Controls)
            {
                if (c is RadioButton)
                {
                    if (((RadioButton)c).Checked)
                        return (RadioButton)c;
                }
            }
            return null;
        }


        private bool ReportSymptomToServer(string symptom, string severity)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                var data = new
                {
                    @event = symptom,
                    rating = severity,
                    latitude = (latitude == null ? "0" : latitude),
                    longitude = (longitude == null ? "0" : longitude)
                };

                try
                {
                    string response = client.UploadString(webServiceURL + "events", "POST", JsonConvert.SerializeObject(data));
                    return true;
                }
                catch(Exception ex)
                {
                    Log("Error reporting symptom: " + ex.Message);
                    return false;
                }
            }
        }


        private void btnReportSymptom_Click(object sender, EventArgs e)
        {
            RadioButton symptom = GetSelectedRadioButton(gbxSymptom);
            RadioButton severity = GetSelectedRadioButton(pnlSeverity);

            if (symptom == null || severity == null)
            {
                MessageBox.Show("Please, select a " + (symptom == null ? "symptom" : "") +
                    (symptom == null && severity == null ? " and a " : "") +
                    (severity == null ? "severity" : "") + "!", 
                    "Oh, No!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if (ReportSymptomToServer(symptom.Tag.ToString(), severity.Tag.ToString()))
                {
                    Log("Symptom report: " + symptom.Text + " - " + severity.Text);
                    MessageBox.Show("Thank you for your report!\nHope you get better soon!", "Symptom Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    symptom.Checked = false;
                    severity.Checked = false;
                } 
                else
                    MessageBox.Show("Could not send your symptom report at this moment.\nPlease, try again.", "Symptom Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
