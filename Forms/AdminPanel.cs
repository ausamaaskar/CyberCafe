using CyberCafe.Models;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberCafe.Forms
{
    public partial class AdminPanel : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private FirestoreController _firestoreConnector;
        private readonly string _cafeName = ConfigurationManager.AppSettings["CafeName"];
        private readonly string _projectId = ConfigurationManager.AppSettings["ProjectId"];
        private readonly string _authenticationPath = ConfigurationManager.AppSettings["AuthenticationPath"];
        private readonly string _availableDocument = ConfigurationManager.AppSettings["AvailableDocument"];
        private readonly string _activatedDocument = ConfigurationManager.AppSettings["ActivatedDocument"];
        private readonly string _bookingRoomsDocument = ConfigurationManager.AppSettings["BookingRooms"];

        public AdminPanel()
        {
            InitializeComponent();
            try
            {
                if (string.IsNullOrEmpty(_projectId) || string.IsNullOrEmpty(_authenticationPath))
                {
                    MessageBox.Show("Felaktiga inställningar!");
                    return;
                }

                _firestoreConnector = new FirestoreController(_projectId, _authenticationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kunde inte ansluta till databasen : " + ex.Message);
                this.Dispose();
            }
        }

        private struct RGBColors
        {
            public static Color BtnBackground = Color.FromArgb(172, 126, 241);
            public static Color PanelBackground = Color.FromArgb(126, 108, 185);

        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = RGBColors.PanelBackground;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private async void RunningDevices_ClickAsync(object sender, EventArgs e)
        {
            var activatedDoc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
            if (activatedDoc == null)
            {
                return;
            }

            ActivateButton(sender, RGBColors.BtnBackground);
            OpenChildForm(new DeviceSelection(DeviceSelectionMode.Running, activatedDoc, null, ProlongDevice_Click, _firestoreConnector, _cafeName, _activatedDocument));
        }

        private void CreateDevice_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.BtnBackground);
            OpenChildForm(new NewDevice(_cafeName, _availableDocument, true));
        }

        private async void StartDevice_Click(object sender, EventArgs e)
        {
            try
            {
                var availableDoc = await _firestoreConnector.GetDocumentAsync(_cafeName, _availableDocument);
                var activatedDoc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
                if (availableDoc == null || activatedDoc == null)
                {
                    return;
                }

                ActivateButton(sender, RGBColors.BtnBackground);
                OpenChildForm(new DeviceSelection(DeviceSelectionMode.Start, availableDoc, activatedDoc, ActivateDevice, _firestoreConnector, _cafeName, _activatedDocument));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void EndDevice_Click(object sender, EventArgs e)
        {
            try
            {
                var doc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
                if (doc == null)
                    return;

                ActivateButton(sender, RGBColors.BtnBackground);
                OpenChildForm(new DeviceSelection(DeviceSelectionMode.End, doc, null, DeactivateDevice_Click, _firestoreConnector, _cafeName, _activatedDocument));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.BtnBackground);
            OpenChildForm(new NewRoom(_cafeName, _bookingRoomsDocument));
        }

        private void BookRoom_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.BtnBackground);
            OpenChildForm(new Booking(_firestoreConnector, _cafeName, _bookingRoomsDocument));
        }

        private void UnbookRoom_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.BtnBackground);
            OpenChildForm(new Unbooking(_firestoreConnector, _cafeName, _bookingRoomsDocument));
        }

        private void Bookings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.BtnBackground);
            OpenChildForm(new ShowBookings(_firestoreConnector, _cafeName, _bookingRoomsDocument));
        }

        private async void ActivateDevice(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var device = (Session)clickedButton.Tag;
            var timeLimitForm = new TimeLimit();
            timeLimitForm.ShowDialog();

            if (timeLimitForm.Minutes == 0)
            {
                return;
            }

            var session = new Session
            {
                Name = device.Name,
                TimeLimit = timeLimitForm.Minutes.ToString()
            };
            await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, session.Name, session);

            this.Controls.Remove(clickedButton);
            clickedButton.Dispose();

            //MessageBox.Show($"Aktiverade enhet: {session.Name}");
        }

        private async void ProlongDevice_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            if (clickedButton.Tag is not (Session device, Label timeLabel))
            {
                MessageBox.Show("Invalid session data.");
                return;
            }

            var timeLimitForm = new TimeLimit();
            timeLimitForm.ShowDialog();

            if (timeLimitForm.Minutes == 0)
            {
                return;
            }

            var newTimeLimit = timeLimitForm.Minutes.ToString();

            var session = new Session
            {
                Name = device.Name,
                TimeLimit = newTimeLimit,
                TimeExtended = true
            };

            await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, session.Name, session);

            timeLabel.Text = $"{newTimeLimit} min kvar";
            MessageBox.Show($"Tiden för {session.Name} har ändrats.");
        }

        private async void DeactivateDevice_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;
            var session = (Device)clickedButton.Tag;

            await _firestoreConnector.DeleteFieldAsync(_cafeName, _activatedDocument, session.Name);
            this.Controls.Remove(clickedButton);
            clickedButton.Dispose();
        }
    }
}
