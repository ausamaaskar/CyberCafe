using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace CyberCafe.Forms
{
    public partial class Countdown : Form
    {
        private Timer timer;
        private double countdownSeconds;
        private FirestoreController _firestoreConnector;
        private bool _warned5Min;
        private readonly string _cafeName = ConfigurationManager.AppSettings["CafeName"];
        private readonly string _projectId = ConfigurationManager.AppSettings["ProjectId"];
        private readonly string _authenticationPath = ConfigurationManager.AppSettings["AuthenticationPath"];
        private readonly string _activatedDocument = ConfigurationManager.AppSettings["ActivatedDocument"];
        private readonly string _deviceName = ConfigurationManager.AppSettings["DeviceName"];

        public Countdown(double seconds)
        {
            InitializeComponent();
            InitializeCustomSettings();
            _firestoreConnector = new FirestoreController(_projectId, _authenticationPath);
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            countdownSeconds = seconds;

        }

        private void InitializeCustomSettings()
        {
            this.FormBorderStyle = FormBorderStyle.None;  // No borders
            this.TopMost = true;  // Keep it always on top
            this.BackColor = Color.Lime;  // Set a color to be transparent
            this.TransparencyKey = Color.Lime;  // Make that color transparent

            // Position the form in the top-right corner
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;

            if (countdownSeconds % 60 == 0)
            {
                await RefreshSessionStateAsync();
            }

            if (countdownSeconds <= 0)
            {
                await HandleSessionEndAsync();
            }
            else
            {
                UpdateTimerDisplay();
            }
        }

        // Refresh Firestore Session State
        private async Task RefreshSessionStateAsync()
        {
            try
            {
                var doc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
                if (doc == null || !doc.ContainsField(_deviceName))
                {
                    await TransitionToClientApplicationAsync();
                    return;
                }

                var str = doc.GetValue<string>(_deviceName);
                var session = JsonConvert.DeserializeObject<Session>(str);
                if (session == null) return;

                if (session.TimeExtended)
                {
                    countdownSeconds = int.Parse(session.TimeLimit) * 60;
                    session.TimeExtended = false;
                }

                double minutes = countdownSeconds / 60.0;
                session.TimeLimit = minutes.ToString("F0");

                var updatedSession = JsonConvert.SerializeObject(session);
                await _firestoreConnector.UpdateFieldAsync(_cafeName, _activatedDocument, _deviceName, updatedSession);

                ShowTimeWarnings(minutes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error refreshing session: " + ex.Message);
            }
        }

        // Handle Session End
        private async Task HandleSessionEndAsync()
        {
            try
            {
                await _firestoreConnector.DeleteFieldAsync(_cafeName, _activatedDocument, _deviceName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to end session: " + ex.Message);
            }
            finally
            {
                timer.Stop();
                await TransitionToClientApplicationAsync();
            }
        }

        // Transition to Client Application
        private async Task TransitionToClientApplicationAsync()
        {
            this.Close();
            using var clientApp = new ClientApplication();
            clientApp.ShowDialog();
        }

        // Update Countdown Display
        private void UpdateTimerDisplay()
        {
            var timeRemaining = TimeSpan.FromSeconds(countdownSeconds);
            TimerText.Text = $"{timeRemaining.Hours:00}:{timeRemaining.Minutes:00}:{timeRemaining.Seconds:00}";
        }

        // Show Time Warnings
        private void ShowTimeWarnings(double minutes)
        {
            if (!_warned5Min && minutes <= 5)
            {
                _warned5Min = true;
                MessageBox.Show("Du har 5 minuter kvar");
            }
        }

        private void CountdownForm_Load(object sender, EventArgs e)
        {
            timer.Start();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, 0);
        }

        private void notifyMinimize_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HandleWindowShowing();

        }

        private void HandleWindowShowing()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyMinimize.Visible = false;
        }

        private void Countdown_SizeChanged(object sender, EventArgs e)
        {
            HandleWindowClosing();
        }

        private void HandleWindowClosing()
        { 
            Hide();
            notifyMinimize.Visible = true;
            notifyMinimize.ShowBalloonTip(1000);
        }

        private void Countdown_FormClosing(object sender, FormClosingEventArgs e)
        {
            //HandleWindowClosing();
            e.Cancel = true;
        }

        private void notifyMinimize_Click(object sender, EventArgs e)
        {
            //HandleWindowShowing();
        }
    }
}
