using Newtonsoft.Json;
using System.Configuration;
using Timer = System.Windows.Forms.Timer;

namespace CyberCafe.Forms
{

    public partial class ClientApplication : Form
    {
        private FirestoreController _firestoreConnector;
        private readonly string _cafeName = ConfigurationManager.AppSettings["CafeName"];
        private readonly string _projectId = ConfigurationManager.AppSettings["ProjectId"];
        private readonly string _authenticationPath = ConfigurationManager.AppSettings["AuthenticationPath"];
        private readonly string _activatedDocument = ConfigurationManager.AppSettings["ActivatedDocument"];
        private readonly string _deviceName = ConfigurationManager.AppSettings["DeviceName"];

        private const int WM_CLOSE = 0x0010;
        private const int WM_DESTROY = 0x0002;
        private const int WM_QUIT = 0x0012;
        private readonly Timer _timer;

        public ClientApplication()
        {
            InitializeComponent();
            _firestoreConnector = new FirestoreController(_projectId, _authenticationPath);
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            _timer = new Timer();
            _timer.Interval = 5000; // 5 seconds
            _timer.Tick += Timer_Tick;
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop(); // Stop the timer

            Start.Text = "Starta Enhet"; // Reset text
            Start.Enabled = true; // Enable button again
        }

        private void ClientApplication_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check the reason for the form closing
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Prevent the form from closing
                e.Cancel = true;
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CLOSE:
                    return; // Ignore the close message

                case WM_DESTROY:
                    return; // Prevent the form from being destroyed

                case WM_QUIT:
                    return; // Prevent quitting

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private async void StartDevice_Click(object sender, EventArgs e)
        {
            try
            {
                Start.Enabled = false;
                Start.Text = "⏳ Laddar...";
                _timer.Start();

                var doc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
                if (doc != null && doc.ContainsField(_deviceName))
                {
                    var str = doc.GetValue<string>(_deviceName);
                    var session = JsonConvert.DeserializeObject<Session>(str);

                    if (int.TryParse(session.TimeLimit, out var minutes))
                    {
                        var timeSpan = TimeSpan.FromMinutes(minutes);
                        var totalSeconds = timeSpan.TotalSeconds;

                        // Mark session as started in Firestore BEFORE showing countdown
                        await _firestoreConnector.UpdateSessionStatus(_cafeName, _activatedDocument, _deviceName, "active");

                        this.Hide();
                        var countDown = new Countdown(totalSeconds, _firestoreConnector, _cafeName, _activatedDocument, _deviceName);
                        countDown.ShowDialog();

                        // When countdown ends, return here
                        this.Show();
                        NoSessionText.Text = "Sessionen har avslutats";
                        NoSessionText.Visible = true;
                    }
                }
                else
                {
                    NoSessionText.Visible = true;
                }
            }
            catch (Exception ex)
            {
                NoSessionText.Text = "Något gick fel";
                NoSessionText.Visible = true;
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                _timer.Stop();
                Start.Text = "Starta Enhet";
                Start.Enabled = true;
            }
        }
    }
}
