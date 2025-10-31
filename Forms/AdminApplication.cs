// Refactored AdminApplication.cs (Complete)
using CyberCafe.Forms;
using CyberCafe.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System.Configuration;

namespace CyberCafe
{
    public partial class AdminApplication : Form
    {
        private FirestoreController _firestoreConnector;
        private readonly string _cafeName = ConfigurationManager.AppSettings["CafeName"];
        private readonly string _projectId = ConfigurationManager.AppSettings["ProjectId"];
        private readonly string _authenticationPath = ConfigurationManager.AppSettings["AuthenticationPath"];
        private readonly string _availableDocument = ConfigurationManager.AppSettings["AvailableDocument"];
        private readonly string _activatedDocument = ConfigurationManager.AppSettings["ActivatedDocument"];
        private readonly string _bookingRoomsDocument = ConfigurationManager.AppSettings["BookingRooms"];

        public AdminApplication()
        {
            InitializeComponent();
            _firestoreConnector = new FirestoreController(_projectId, _authenticationPath);
        }

        private void AdminApplication_Load(object sender, EventArgs e) { }

        private void CreateDevice_Click(object sender, EventArgs e)
        {
            using var newDeviceForm = new NewDevice(_cafeName, _availableDocument, true);
            newDeviceForm.ShowDialog();
        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            using var newRoomForm = new NewRoom(_cafeName, _bookingRoomsDocument);
            newRoomForm.ShowDialog();
        }

        private void BookRoom_Click(object sender, EventArgs e)
        {
            using var bookingForm = new Booking(_firestoreConnector, _cafeName, _bookingRoomsDocument);
            bookingForm.ShowDialog();
        }

        private void UnbookRoom_Click(object sender, EventArgs e)
        {
            using var bookingForm = new Unbooking(_firestoreConnector, _cafeName, _bookingRoomsDocument);
            bookingForm.ShowDialog();
        }

        private async void StartDevice_Click(object sender, EventArgs e)
        {
            var availableDoc = await _firestoreConnector.GetDocumentAsync(_cafeName, _availableDocument);
            var activatedDoc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);

            if (availableDoc?.Exists == true && activatedDoc?.Exists == true)
            {
                ShowDeviceSelectorForm(availableDoc, activatedDoc, ActivateDevice_Click, true);
            }
        }

        private void ShowDeviceSelectorForm(DocumentSnapshot sourceDoc, DocumentSnapshot targetDoc, EventHandler clickHandler, bool activate)
        {
            using var form = new DeviceSelection(DeviceSelectionMode.Running, null, null, null, _firestoreConnector, _cafeName, _activatedDocument)
            {
                Text = activate ? "Starta Enhet" : "Avsluta Enhet",
                BackColor = Color.AliceBlue,
                AutoScroll = false,
                Size = new Size(900, 600),
                StartPosition = FormStartPosition.CenterScreen
            };

            var mainLayout = CreateMainLayout(out var deviceTable, out var scrollPanel, out var checkboxes);
            PopulateDeviceTable(sourceDoc, targetDoc, deviceTable, checkboxes, clickHandler, activate);
            AddBottomPanel(mainLayout, checkboxes, activate);

            form.Controls.Add(mainLayout);
            form.ShowDialog();
        }

        private TableLayoutPanel CreateMainLayout(out TableLayoutPanel deviceTable, out Panel scrollPanel, out List<CheckBox> checkboxes)
        {
            var layout = new TableLayoutPanel { Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1 };
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));

            scrollPanel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            deviceTable = new TableLayoutPanel { AutoSize = true, ColumnCount = 3, Dock = DockStyle.Top };

            for (int i = 0; i < 3; i++)
                deviceTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / 3));

            scrollPanel.Controls.Add(deviceTable);
            layout.Controls.Add(scrollPanel, 0, 0);
            checkboxes = new List<CheckBox>();

            return layout;
        }

        private void PopulateDeviceTable(DocumentSnapshot sourceDoc, DocumentSnapshot targetDoc,
            TableLayoutPanel table, List<CheckBox> checkboxes, EventHandler clickHandler, bool activate)
        {
            var fields = sourceDoc.ToDictionary();
            int deviceCount = 0;

            foreach (var field in fields)
            {
                if (activate && targetDoc.ContainsField(field.Key)) continue;

                object tag;
                try
                {
                    tag = activate ?
                        JsonConvert.DeserializeObject<Session>(field.Value.ToString()) :
                        JsonConvert.DeserializeObject<Device>(field.Value.ToString());

                    if (tag == null) continue;
                }
                catch (JsonException)
                {
                    continue;
                }

                var panel = BuildDevicePanel(field.Key, tag, clickHandler, checkboxes);
                int col = deviceCount % 3;
                int row = deviceCount / 3;

                if (col == 0)
                {
                    table.RowCount = row + 1;
                    table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                table.Controls.Add(panel, col, row);
                deviceCount++;
            }
        }

        private Panel BuildDevicePanel(string deviceId, object tag, EventHandler clickHandler, List<CheckBox> checkboxes)
        {
            var panel = new Panel { Size = new Size(250, 100), Margin = new Padding(10) };
            var button = new Button
            {
                Text = deviceId,
                Size = new Size(212, 84),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14),
                Tag = tag,
                Cursor = Cursors.Hand,
                Location = new Point(10, 10)
            };
            button.FlatAppearance.BorderSize = 0;
            button.Click += clickHandler;

            var checkBox = new CheckBox
            {
                Size = new Size(20, 20),
                Tag = button,
                Location = new Point(button.Right + 5, button.Top + (button.Height - 20) / 2)
            };

            checkboxes.Add(checkBox);
            panel.Controls.Add(button);
            panel.Controls.Add(checkBox);
            return panel;
        }

        private void AddBottomPanel(TableLayoutPanel layout, List<CheckBox> checkboxes, bool activate)
        {
            var panel = new Panel { Dock = DockStyle.Fill };
            var button = new Button
            {
                Text = activate ? "Aktivera flera enheter" : "Avsluta flera enheter",
                Size = new Size(200, 60),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 14),
                Cursor = Cursors.Hand
            };

            panel.Controls.Add(button);
            panel.Resize += (s, e) =>
            {
                button.Location = new Point(panel.ClientSize.Width - button.Width - 10,
                                            (panel.ClientSize.Height - button.Height) / 2);
            };

            layout.Controls.Add(panel, 0, 1);

            button.Click += async (sender, e) =>
            {
                var selected = checkboxes.Where(cb => cb.Checked && cb.Tag is Button)
                                         .Select(cb => (Button)cb.Tag)
                                         .ToList();

                if (!selected.Any())
                {
                    MessageBox.Show("Välj minst en enhet.");
                    return;
                }

                using var timeForm = new TimeLimit();
                if (activate)
                {
                    timeForm.ShowDialog();
                    if (timeForm.Minutes == 0) return;
                }

                foreach (var btn in selected)
                {
                    try
                    {
                        if (activate)
                        {
                            var session = (Session)btn.Tag;
                            session.TimeLimit = timeForm.Minutes.ToString();
                            await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, session.Name, session);
                        }
                        else
                        {
                            var device = (Device)btn.Tag;
                            await _firestoreConnector.DeleteFieldAsync(_cafeName, _activatedDocument, device.Name);
                        }
                        btn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fel: " + ex.Message);
                    }
                }

                foreach (var cb in checkboxes.Where(cb => cb.Checked).ToList())
                {
                    cb.Dispose();
                    checkboxes.Remove(cb);
                }

                MessageBox.Show($"{(activate ? "Aktiverade" : "Avslutade")} {selected.Count} enheter.");
            };
        }

        private async void ActivateDevice_Click(object sender, EventArgs e)
        {
            if (sender is not Button clickedButton || clickedButton.Tag is not Session device)
            {
                MessageBox.Show("Ogiltig enhetsinformation.");
                return;
            }

            using var timeLimitForm = new TimeLimit();
            timeLimitForm.ShowDialog();
            if (timeLimitForm.Minutes == 0) return;

            var session = new Session
            {
                Name = device.Name,
                TimeLimit = timeLimitForm.Minutes.ToString()
            };

            try
            {
                await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, session.Name, session);
                clickedButton.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid aktivering: " + ex.Message);
            }
        }

        private async void ProlongDevice_Click(object sender, EventArgs e)
        {
            if (sender is not Button clickedButton || clickedButton.Tag is not Tuple<Session, Label> tag)
            {
                MessageBox.Show("Ogiltig sessionstagning.");
                return;
            }

            using var timeLimitForm = new TimeLimit();
            timeLimitForm.ShowDialog();
            if (timeLimitForm.Minutes == 0) return;

            tag.Item1.TimeLimit = timeLimitForm.Minutes.ToString();
            await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, tag.Item1.Name, tag.Item1);
            tag.Item2.Text = $"{tag.Item1.TimeLimit} min kvar";

            MessageBox.Show($"Tiden för {tag.Item1.Name} har ändrats.");
        }

        private async void EndDevice_Click(object sender, EventArgs e)
        {
            var doc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
            if (doc?.Exists == true)
            {
                ShowDeviceSelectorForm(doc, doc, DeactivateDevice_Click, false);
            }
        }

        private async void DeactivateDevice_Click(object sender, EventArgs e)
        {
            if (sender is not Button clickedButton || clickedButton.Tag is not Device session)
            {
                MessageBox.Show("Ogiltig session för borttagning.");
                return;
            }

            await _firestoreConnector.DeleteFieldAsync(_cafeName, _activatedDocument, session.Name);
            clickedButton.Dispose();
        }

        private void ShowBookings_Click(object sender, EventArgs e)
        {
            using var bookingForm = new ShowBookings(_firestoreConnector, _cafeName, _bookingRoomsDocument);
            bookingForm.ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var doc = await _firestoreConnector.GetDocumentAsync(_cafeName, _activatedDocument);
            if (doc?.Exists == true)
            {
                ShowDeviceSelectorForm(doc, doc, ProlongDevice_Click, false);
            }
        }
    }
}
