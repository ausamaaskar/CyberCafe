using CyberCafe.Models;

namespace CyberCafe.Forms
{
    public partial class NewRoom : Form
    {
        private FirestoreController _firestoreConnector;
        private readonly string _cafeName;
        private readonly string _bookingRoomsDoc;

        public NewRoom(string cafeName, string bookingRoomsDoc)
        {
            InitializeComponent();
            _firestoreConnector = new FirestoreController("netcafeaskar", "");
            _cafeName = cafeName;
            _bookingRoomsDoc = bookingRoomsDoc;
        }

        private void NewRoom_Load(object sender, EventArgs e)
        {

        }

        private async void Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RoomNameField.Text) || IntervalDropdown.SelectedIndex == -1)
            {
                MessageBox.Show("Ange namn och intervall!");
                return;
            }

            var interval = 0;
            switch (IntervalDropdown.SelectedIndex)
            {
                case 0:
                    interval = 30;
                    break;
                case 1:
                    interval = 45;
                    break;
                case 2: 
                    interval = 60;
                    break;
            }

            var data = new Room
            {
                Name = RoomNameField.Text,
                Interval = interval
            };

            await _firestoreConnector.AddDocumentAsync(_cafeName, _bookingRoomsDoc, data.Name, data);
            MessageBox.Show($"Skapade upp rummet {RoomNameField.Text}");
            RoomNameField.Text = string.Empty;
        }
    }
}
