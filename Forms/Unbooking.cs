using CyberCafe.Models;
using Google.Cloud.Firestore;
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

namespace CyberCafe.Forms
{
    public partial class Unbooking : Form
    {
        private FirestoreController _firestoreConnector;
        private readonly string _cafeName;
        private readonly string _bookingRoomsDocument;
        private readonly bool _unbooking;
        private DocumentSnapshot _documentSnapshot;

        public Unbooking(FirestoreController firestoreConnector, string cafeName, string doc)
        {
            InitializeComponent();
            _firestoreConnector = firestoreConnector;
            _cafeName = cafeName;
            _bookingRoomsDocument = doc;
        }

        public async void Booking_Load(object sender, EventArgs e)
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
            var splitSlot = selectedSlot.Split(';');
            var timeSlot = splitSlot[0]?.Trim();

            if (string.IsNullOrEmpty(selectedRoom) || string.IsNullOrEmpty(timeSlot))
            {
                MessageBox.Show("Välj rum och tid för att avboka!");
                return;
            }

            // Retrieve current room data
            var fields = _documentSnapshot.ToDictionary();
            if (fields.TryGetValue(selectedRoom, out var currentBookings))
            {
                var currentRoom = JsonConvert.DeserializeObject<Room>(currentBookings.ToString());
                var date = currentRoom?.BookedDates?.FirstOrDefault(x => x.Date == selectedDate);

                // If the date and booking slot exist, proceed to remove the booking slot
                if (date != null && date.BookedHours != null)
                {
                    var hourToRemove = date.BookedHours.FirstOrDefault(b => b.Hour == timeSlot);
                    if (hourToRemove != null)
                    {
                        date.BookedHours.Remove(hourToRemove);

                        // If no more slots are booked for this date, remove the date entry
                        if (date.BookedHours.Count == 0)
                        {
                            currentRoom.BookedDates.Remove(date);
                        }

                        // Serialize the updated booking information and save it back to Firestore
                        var updatedBookings = JsonConvert.SerializeObject(currentRoom);
                        await _firestoreConnector.UpdateFieldAsync(_cafeName, _bookingRoomsDocument, selectedRoom, updatedBookings);
                        MessageBox.Show("Bokningen har avbokats!");
                    }
                    else
                    {
                        MessageBox.Show("Det valda tidsintervallet kunde inte hittas för avbokning.");
                    }
                }
                else
                {
                    MessageBox.Show("Inga bokningar hittades för det valda datumet och rummet.");
                }
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

                if (date == null)
                {
                    MessageBox.Show("Inga bokningar hittades för det valda datumet och rummet.");
                    return;
                }

                PopulateBookedTimeSlots(date?.BookedHours);
            }
        }

        private void PopulateBookedTimeSlots(List<BookedHour> bookedHours)
        {
            if (bookedHours == null || !bookedHours.Any())
            {
                bookedHours = new List<BookedHour>();
            }

            timeSlotsDropdown.Items.Clear();
            foreach (var slot in bookedHours)
            {
                if (!string.IsNullOrEmpty(slot.Hour))
                {
                    var item = slot.Hour;
                    if (!string.IsNullOrEmpty(slot.BookingReference))
                    {
                        item = string.Join(" ; ", slot.Hour, slot.BookingReference);
                    }

                    timeSlotsDropdown.Items.Add(item);
                }
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

                PopulateBookedTimeSlots(date?.BookedHours);
            }
        }
    }
}
