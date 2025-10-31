using CyberCafe.Models;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
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
    public partial class Booking : Form
    {
        private IFirestoreController _firestoreConnector;
        private readonly string _cafeName;
        private readonly string _bookingRoomsDocument;
        private DocumentSnapshot _documentSnapshot;

        public Booking(IFirestoreController firestoreConnector, string cafeName, string doc)
        {
            InitializeComponent();
            _firestoreConnector = firestoreConnector;
            _cafeName = cafeName;
            _bookingRoomsDocument = doc;
        }

        public async void Booking_Load(object sender, EventArgs e)
        {
            await LoadAsync();
        }

        public async Task LoadAsync()
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

        private async void ConfirmButton_Click(object sender, EventArgs e)
        {
            var selectedRoom = RoomsDropdown.SelectedItem?.ToString();
            var selectedDate = dateTimePicker.Value.ToString("d");
            var selectedSlot = timeSlotsDropdown.SelectedItem?.ToString();
            var bookingRef = bookingReference.Text;

            if (string.IsNullOrEmpty(selectedRoom) || string.IsNullOrEmpty(selectedSlot))
            {
                MessageBox.Show("Välj rum och tid först!");
                return;
            }

            var fields = _documentSnapshot.ToDictionary();
            if(fields.TryGetValue(selectedRoom, out var currentBookings))
            {
                var currentRoom = JsonConvert.DeserializeObject<Room>(currentBookings.ToString());
                var date = currentRoom?.BookedDates?.FirstOrDefault(x => x.Date == selectedDate);
                var bookedHour = new BookedHour
                {
                    BookingReference = bookingRef,
                    Hour = selectedSlot
                };

                if (date != null && date.BookedHours != null && date.BookedHours.Any())
                {
                    date.BookedHours.Add(bookedHour);
                }
                else
                {
                    if (currentRoom.BookedDates == null)
                    {
                        currentRoom.BookedDates = new List<BookedDate>();
                    }

                    currentRoom.BookedDates.Add(new BookedDate
                    {
                        Date = selectedDate,
                        BookedHours = new List<BookedHour> { bookedHour }
                    });
                }

                var updatedBookings = JsonConvert.SerializeObject(currentRoom);
                await _firestoreConnector.UpdateFieldAsync(_cafeName, _bookingRoomsDocument, selectedRoom, updatedBookings);
                MessageBox.Show("Bokade rummet");
            }
        }

        private void RoomsDropdown_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedRoom = RoomsDropdown.SelectedItem?.ToString();
            var selectedDate = dateTimePicker.Value.ToString("d");

            if (!string.IsNullOrEmpty(selectedRoom) && _documentSnapshot != null && _documentSnapshot.ContainsField(selectedRoom))
            {
                var str = _documentSnapshot.GetValue<string>(selectedRoom);
                var room = JsonConvert.DeserializeObject<Room>(str);
                var date = room?.BookedDates?.FirstOrDefault(x => x.Date == selectedDate);

                PopulateTimeSlots(date?.BookedHours, room);  
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            var selectedRoom = RoomsDropdown.SelectedItem?.ToString();
            var selectedDate = dateTimePicker.Value.ToString("d");

            if (!string.IsNullOrEmpty(selectedRoom) && _documentSnapshot != null && _documentSnapshot.ContainsField(selectedRoom))
            {
                var str = _documentSnapshot.GetValue<string>(selectedRoom);
                var room = JsonConvert.DeserializeObject<Room>(str);
                var date = room?.BookedDates?.FirstOrDefault(x => x.Date == selectedDate);

                PopulateTimeSlots(date?.BookedHours, room);
            }
        }

        private void PopulateTimeSlots(List<BookedHour> bookedHours, Room room)
        {
            if (bookedHours == null)
            {
                bookedHours = new List<BookedHour>();
            }

            timeSlotsDropdown.Items.Clear();
            var timeSlots = GenerateTimeSlots(room.Interval);
            foreach (var slot in timeSlots)
            {
                if (!bookedHours.Any(booking => booking.Hour == slot))
                {
                    timeSlotsDropdown.Items.Add(slot);
                }
            }
        }

        private List<string> GenerateTimeSlots(int interval)
        {
            var timeSlots = new List<string>();

            // Start and end times in hours
            int startHour = 14;
            int endHour = 23;

            // Loop through the time range in steps of the interval
            for (int hour = startHour; hour <= endHour; hour++)
            {
                for (int minute = 0; minute < 60; minute += interval)
                {
                    // Calculate the start and end of the time slot
                    var start = new TimeSpan(hour, minute, 0);
                    var end = start.Add(TimeSpan.FromMinutes(interval));

                    // Ensure the end time does not exceed 23:00
                    if (end > new TimeSpan(23, 0, 0))
                        break;

                    // Format the time slot and add it to the list
                    timeSlots.Add($"{start:hh\\:mm}-{end:hh\\:mm}");
                }

                // Break the outer loop if the next slot starts at or after 23:00
                if (new TimeSpan(hour + 1, 0, 0) >= new TimeSpan(23, 0, 0))
                    break;
            }

            return timeSlots;
        }

    }
}
