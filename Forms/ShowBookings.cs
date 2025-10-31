using CyberCafe.Models;
using Google.Cloud.Firestore;
using Google.Type;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateTime = System.DateTime;

namespace CyberCafe.Forms
{
    public partial class ShowBookings : Form
    {
        private FirestoreController _firestoreConnector;
        private string _cafeName;
        private string _bookingRoomsDocument;
        private DocumentSnapshot _documentSnapshot;

        public ShowBookings(FirestoreController firestoreConnector, string cafeName, string doc)
        {
            InitializeComponent();
            _firestoreConnector = firestoreConnector;
            _cafeName = cafeName;
            _bookingRoomsDocument = doc;
        }

        public async void ShowBookings_Load(object sender, EventArgs e)
        {
            _documentSnapshot = await _firestoreConnector.GetDocumentAsync(_cafeName, _bookingRoomsDocument);
            if (_documentSnapshot != null)
            {
                PopulateRoomsDropdown();
            }
        }

        public void PopulateRoomsDropdown()
        {
            var fields = _documentSnapshot.ToDictionary();
            if (fields != null)
            {
                foreach (var field in fields)
                {
                    RoomsDropdown.Items.Add(field.Key);
                }
            }
        }

        public void RoomsDropdown_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedRoom = RoomsDropdown.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedRoom) && _documentSnapshot != null && _documentSnapshot.ContainsField(selectedRoom))
            {
                var str = _documentSnapshot.GetValue<string>(selectedRoom);
                var currentRoom = JsonConvert.DeserializeObject<Room>(str);

                if (currentRoom != null && currentRoom.BookedDates != null)
                {
                    // Get the date one week ago from today
                    var oneWeekAgo = DateTime.Now.AddDays(-7).Date;

                    // Filter dates to include only those within the last week
                    var recentDates = currentRoom.BookedDates
                        .Where(bd => DateTime.TryParse(bd.Date, out var bookedDate) && bookedDate >= oneWeekAgo)
                        .Select(bd => bd.Date)
                        .Distinct()
                        .ToList();

                    // Clear existing columns and rows in DataGridView
                    dataGridView.Columns.Clear();
                    dataGridView.Rows.Clear();

                    // Add columns to DataGridView
                    dataGridView.Columns.Add("TimeSlot", "Bokningstider");
                    foreach (var date in recentDates)
                    {
                        dataGridView.Columns.Add(date, date);
                    }


                    var timeSlots = new List<string>();
                    int startHour = 14;
                    int endHour = 23;
                    for (int hour = startHour; hour <= endHour; hour++)
                    {
                        for (int minute = 0; minute < 60; minute += currentRoom.Interval)
                        {
                            // Calculate the start and end of the time slot
                            var start = new TimeSpan(hour, minute, 0);
                            var end = start.Add(TimeSpan.FromMinutes(currentRoom.Interval));

                            // Ensure the end time does not exceed 23:00
                            if (end > new TimeSpan(23, 0, 0))
                                break;

                            // Format the time slot and add it to the list
                            var timeSlot = $"{start:hh\\:mm}-{end:hh\\:mm}";
                            var rowIndex = dataGridView.Rows.Add();
                            dataGridView.Rows[rowIndex].Cells["TimeSlot"].Value = timeSlot;
                        }

                        // Break the outer loop if the next slot starts at or after 23:00
                        if (new TimeSpan(hour + 1, 0, 0) >= new TimeSpan(23, 0, 0))
                            break;
                    }


                    // Populate bookings in DataGridView based on recent dates
                    foreach (var bookedDate in currentRoom.BookedDates.Where(bd => recentDates.Contains(bd.Date)))
                    {
                        foreach (var bookedHour in bookedDate.BookedHours)
                        {
                            // Find the row for the specific time slot
                            var row = dataGridView.Rows
                                .Cast<DataGridViewRow>()
                                .FirstOrDefault(r => r.Cells["TimeSlot"].Value?.ToString() == bookedHour.Hour);

                            if (row != null)
                            {
                                // Find the column index for the date
                                var columnIndex = dataGridView.Columns
                                    .Cast<DataGridViewColumn>()
                                    .FirstOrDefault(c => c.HeaderText == bookedDate.Date)?.Index;

                                if (columnIndex.HasValue)
                                {
                                    row.Cells[columnIndex.Value].Value = !string.IsNullOrEmpty(bookedHour.BookingReference) ? bookedHour.BookingReference : "Bokad";
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No bookings found.");
                }
            }
        }
    }
}
