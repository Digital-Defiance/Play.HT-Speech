using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TTSPlay.HT
{
    public partial class Settings : Form
    {
        private Dictionary<string, string> deviceDictionary = new Dictionary<string, string>();

        public Settings()
        {
            InitializeComponent();
        }

        public List<KeyValuePair<string, string>> GetAudioDeviceList()
        {
            var devices = new MMDeviceEnumerator();
            var deviceList = new List<KeyValuePair<string, string>>();
            foreach (var endpoint in devices.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)) {
                deviceList.Add(new KeyValuePair<string, string>(endpoint.ID, endpoint.FriendlyName));
            }

            return deviceList;
        }

        public ListViewItem[] AudioDevicesToListItems(List<KeyValuePair<int, string>> items)
        {
            var list = new List<ListViewItem>();
            foreach(var item in items)
            {
                var listItem = new ListViewItem(item.Value);
                listItem.Tag = item.Key;
                list.Add(listItem);
            }
            return list.ToArray();
        }
        private string GetDeviceNameFromId(string deviceId)
        {
            foreach (var pair in deviceDictionary)
            {
                if (pair.Value == deviceId)
                {
                    return pair.Key; // Return the device name
                }
            }
            return null; // Return null if not found
        }

        private void SelectDeviceInListBox(string deviceName)
        {
            int index = listAudioDevices.Items.IndexOf(deviceName);
            if (index != -1)
            {
                listAudioDevices.SelectedIndex = index;
            }
            else
            {
                // Handle the case where the device is not found
                listAudioDevices.SelectedIndex = -1;
            }
        }


        private void Settings_Load(object sender, EventArgs e)
        {
            txtUserId.Text = Properties.Settings.Default.APIUser;
            txtUserSecret.Text = Properties.Settings.Default.APISecret;
            listAudioDevices.Items.Clear();
            deviceDictionary.Clear();
            var audioDevices = GetAudioDeviceList();
            foreach (var audioDevice in audioDevices)
            {
                listAudioDevices.Items.Add(audioDevice.Value);
                deviceDictionary[audioDevice.Value] = audioDevice.Key;
            }
            var selectedDeviceId = Properties.Settings.Default.OutputDevice;
            var deviceName = GetDeviceNameFromId(selectedDeviceId);
            if (deviceName != null)
            {
                SelectDeviceInListBox(deviceName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.APIUser = txtUserId.Text;
            Properties.Settings.Default.APISecret = txtUserSecret.Text;
            string selectedDeviceName = listAudioDevices.SelectedItem.ToString();
            if (selectedDeviceName != null && deviceDictionary.TryGetValue(selectedDeviceName, out string selectedDeviceId))
            {
                Properties.Settings.Default.OutputDevice = selectedDeviceId;
            } else
            {
                Properties.Settings.Default.OutputDevice = "";
            }
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
