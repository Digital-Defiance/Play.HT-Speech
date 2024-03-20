using RestSharp;
using NAudio.Wave;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace TTSPlay.HT
{
    public partial class Form1 : Form
    {
        const int SW_RESTORE = 9;  // Command to restore the window

        public Form1()
        {
            InitializeComponent();
            txtContent.KeyDown += TxtContent_KeyDown;
            Resize += Form1_Resize;
            cmbVoices.SelectedIndexChanged += CmbVoices_SelectedIndexChanged;
        }

        private void CmbVoices_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbVoices.SelectedItem != null)
            {
                Voice selectedVoice = (Voice)cmbVoices.SelectedItem;
                Properties.Settings.Default.SelectedVoice = selectedVoice.Id;
                Properties.Settings.Default.Save();
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private void ShowWindow()
        {
            // Make sure the window is not minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowWindow(this.Handle, SW_RESTORE);
            }

            // Show the window (in case it was hidden) and bring it to front
            this.Show();
            this.BringToFront();

            // Set the window to be the foreground window
            SetForegroundWindow(this.Handle);

            // Optionally, activate the window and focus on a specific control
            this.Activate();
            txtContent.Focus();
        }

        private bool HasSettings()
        {
            var user = Properties.Settings.Default.APIUser;
            var secret = Properties.Settings.Default.APISecret;
            return (user != null && user.Length > 0 && secret != null && secret.Length > 0);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.FormClosed += Settings_FormClosed;
            settings.ShowDialog();
        }

        public async Task Speak(string text, string selectedDeviceId)
        {
            MessageBox.Show("Would have spoken \"" + text + "\" to deviceId=\"" + selectedDeviceId + "\"");
        }

        private void TxtContent_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var textToSpeak = txtContent.Text;
                Task.Run(async () =>
                {
                    await Speak(textToSpeak, Properties.Settings.Default.OutputDevice);
                });
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (!e.Shift)
                {
                    txtContent.Text = "";
                }
            }
        }

        private async void Settings_FormClosed(object? sender, FormClosedEventArgs e)
        {
            await UpdateVoices();
        }

        private async Task<List<Voice>> getClonedVoices()
        {
            var options = new RestClientOptions("https://api.play.ht/api/v2/cloned-voices");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("AUTHORIZATION", Properties.Settings.Default.APISecret);
            request.AddHeader("X-USER-ID", Properties.Settings.Default.APIUser);
            try
            {
                var response = await client.GetAsync(request);
                if (response.Content == null)
                {
                    return new List<Voice>();
                }
                var voices = JsonSerializer.Deserialize<List<Voice>>(response.Content);
                if (voices == null)
                {
                    return new List<Voice>();
                }
                return voices; // Return the deserialized list
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Voice>(); // Return an empty list in case of an exception
            }
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                await Speak(txtContent.Text, Properties.Settings.Default.OutputDevice);
            });
        }

        private async Task UpdateVoices()
        {
            if (HasSettings())
            {
                List<Voice> voices = await getClonedVoices();

                cmbVoices.DataSource = null;

                // Check if the voices list is null or empty
                if (voices != null && voices.Count > 0)
                {
                    cmbVoices.DisplayMember = "Name";
                    cmbVoices.ValueMember = "Id";
                    cmbVoices.DataSource = voices;
                    if (Properties.Settings.Default.SelectedVoice.Length > 0)
                    {
                        cmbVoices.SelectedValue = Properties.Settings.Default.SelectedVoice;
                    }
                }
                else
                {
                    // Handle the case where voices is null or empty
                    MessageBox.Show("No voices found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await UpdateVoices();
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowWindow();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
