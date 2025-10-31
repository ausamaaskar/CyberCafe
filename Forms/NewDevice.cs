using CyberCafe.Models;

namespace CyberCafe.Forms
{
    public partial class NewDevice : Form
    {
        private FirestoreController _firestoreConnector;
        private bool _newDevice;
        private string _document;
        private string _cafeName;

        public NewDevice(string cafeName, string document, bool newDevice)
        {
            InitializeComponent();
            _firestoreConnector = new FirestoreController("netcafeaskar", "");
            _newDevice = newDevice;
            _document = document;
            _cafeName = cafeName;
        }

        private void NewDevice_Load(object sender, EventArgs e)
        {

        }

        private async void Create_Click(object sender, EventArgs e)
        {
            object data = new Room
            {
                Name = DeviceNameField.Text
            };

            if (_newDevice)
            {
                data = new Device
                {
                    IsAdmin = false,
                    Name = DeviceNameField.Text
                };
            }

            await _firestoreConnector.AddDocumentAsync(_cafeName, _document, DeviceNameField.Text, data);
            MessageBox.Show($"Skapade upp {DeviceNameField.Text}");
            DeviceNameField.Text = string.Empty;
        }
    }
}
