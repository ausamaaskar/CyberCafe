using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CyberCafe.Forms;
using CyberCafe.Models;
using CyberCafe;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

public enum DeviceSelectionMode
{
    Start,      
    End,        
    Running    
}

public class DeviceSelection : Form
{
    private List<CheckBox> checkboxes = new List<CheckBox>();
    private readonly IFirestoreController _firestoreConnector;
    private readonly string _cafeName;
    private readonly string _activatedDocument;

    public DeviceSelection(DeviceSelectionMode mode, DocumentSnapshot sourceDoc, DocumentSnapshot? targetDoc, EventHandler clickHandler, IFirestoreController firestoreConnector, string cafeName, string activatedDocument)
    {
        _firestoreConnector = firestoreConnector;
        _cafeName = cafeName;
        _activatedDocument = activatedDocument;
        InitializeUI(mode, sourceDoc, targetDoc, clickHandler);
    }

    #region UI Initialization

    private void InitializeUI(DeviceSelectionMode mode, DocumentSnapshot sourceDoc, DocumentSnapshot? targetDoc, EventHandler clickHandler)
    {
        SetupFormProperties(mode);

        var mainLayout = CreateMainLayout();
        var deviceContainer = CreateDeviceContainer();
        PopulateDeviceContainer(deviceContainer, mode, sourceDoc, targetDoc, clickHandler);

        var scrollPanel = CreateScrollPanel(deviceContainer);
        mainLayout.Controls.Add(scrollPanel, 0, 0);

        var multiSelectionButton = CreateMultiSelectionButton(mode);
        SetupMultiSelectionButton(multiSelectionButton, mode, targetDoc);
        var bottomPanel = CreateBottomPanel(multiSelectionButton);
        mainLayout.Controls.Add(bottomPanel, 0, 1);

        this.Controls.Add(mainLayout);
    }

    private void SetupFormProperties(DeviceSelectionMode mode)
    {
        this.Text = mode == DeviceSelectionMode.Running
            ? "Pågående Enheter"
            : (mode == DeviceSelectionMode.Start ? "Starta Enhet" : "Avsluta Enhet");
        this.BackColor = Color.AliceBlue;
        this.Size = new Size(900, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.AutoScroll = false;
    }

    private TableLayoutPanel CreateMainLayout()
    {
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1,
            BackColor = Color.AliceBlue
        };
        layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
        return layout;
    }

    private Control CreateDeviceContainer()
    {
        return new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            WrapContents = true,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(10),
            BackColor = Color.AliceBlue,
        };
    }

    private Panel CreateScrollPanel(Control deviceContainer)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = Color.AliceBlue,
        };

        panel.Controls.Add(deviceContainer);
        return panel;
    }

    #endregion

    #region Device Panels Population

    private void PopulateDeviceContainer(Control container, DeviceSelectionMode mode, DocumentSnapshot sourceDoc, DocumentSnapshot? targetDoc, EventHandler clickHandler)
    {
        var fields = sourceDoc.ToDictionary();
        foreach (var field in fields)
        {
            // For Start mode, skip devices that are already activated.
            if (mode == DeviceSelectionMode.Start && targetDoc != null && targetDoc.ContainsField(field.Key))
                continue;

            Panel devicePanel = mode == DeviceSelectionMode.Running
                ? CreateRunningDevicePanel(field.Key, field.Value.ToString(), clickHandler)
                : CreateStartEndDevicePanel(field.Key, field.Value.ToString(), mode, clickHandler);

            if (container is FlowLayoutPanel flowPanel)
            {
                flowPanel.Controls.Add(devicePanel);
            }
            else if (container is TableLayoutPanel tablePanel)
            {
                int count = tablePanel.Controls.Count;
                int columns = tablePanel.ColumnCount;
                int row = count / columns;
                int col = count % columns;
                if (col == 0)
                {
                    tablePanel.RowCount = row + 1;
                    tablePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                tablePanel.Controls.Add(devicePanel, col, row);
            }
        }
    }

    private Panel CreateRunningDevicePanel(string key, string fieldValue, EventHandler clickHandler)
    {
        // Deserialize the field as a Session.
        var session = JsonConvert.DeserializeObject<Session>(fieldValue);
        if (session == null)
            return new Panel();

        var panel = new Panel
        {
            Size = new Size(250, 140),
            Margin = new Padding(10),
            BackColor = Color.AliceBlue
        };

        var button = new Button
        {
            Text = key,
            Size = new Size(212, 84),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 14, FontStyle.Regular),
            Cursor = Cursors.Hand,
            Location = new Point(10, 10),
            FlatAppearance = { BorderSize = 0 }
        };

        var timeLabel = new Label
        {
            Text = $"{session.TimeLimit} min kvar",
            AutoSize = true,
            Font = new Font("Segoe UI", 10, FontStyle.Italic),
            ForeColor = Color.Gray,
            BackColor = Color.AliceBlue,
            Location = new Point(10, button.Bottom + 5)
        };

        // Store both the session and its label.
        button.Tag = new Tuple<Session, Label>(session, timeLabel);
        button.Click += clickHandler;

        var checkBox = CreateDeviceCheckBox(button);
        panel.Controls.Add(button);
        panel.Controls.Add(timeLabel);
        panel.Controls.Add(checkBox);
        return panel;
    }

    private Panel CreateStartEndDevicePanel(string key, string fieldValue, DeviceSelectionMode mode, EventHandler clickHandler)
    {
        // For Start mode, deserialize as Session; for End mode, as Device.
        object tag = mode == DeviceSelectionMode.Start
            ? JsonConvert.DeserializeObject<Session>(fieldValue)
            : JsonConvert.DeserializeObject<Device>(fieldValue);

        var panel = new Panel
        {
            Size = new Size(250, 100),
            Margin = new Padding(10),
            BackColor = Color.AliceBlue
        };

        var button = new Button
        {
            Text = key,
            Size = new Size(212, 84),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 14, FontStyle.Regular),
            Cursor = Cursors.Hand,
            Location = new Point(10, 10),
            FlatAppearance = { BorderSize = 0 },
            Tag = tag
        };

        // Wrap the click handler to dispose the associated checkbox.
        button.Click += (sender, e) =>
        {
            clickHandler(sender, e);
            var btn = (Button)sender;
            var associatedCheckbox = checkboxes.FirstOrDefault(cb => cb.Tag == btn);
            if (associatedCheckbox != null)
            {
                checkboxes.Remove(associatedCheckbox);
                associatedCheckbox.Dispose();
            }
        };

        var checkBox = CreateDeviceCheckBox(button);
        panel.Controls.Add(button);
        panel.Controls.Add(checkBox);
        return panel;
    }

    private CheckBox CreateDeviceCheckBox(Button associatedButton)
    {
        var checkBox = new CheckBox
        {
            Size = new Size(20, 20),
            Tag = associatedButton,
            Location = new Point(associatedButton.Right + 5, associatedButton.Top + (associatedButton.Height - 20) / 2)
        };
        checkboxes.Add(checkBox);
        return checkBox;
    }

    #endregion

    #region Bottom Panel & Multi-Selection

    private Button CreateMultiSelectionButton(DeviceSelectionMode mode)
    {
        string buttonText = mode == DeviceSelectionMode.End ? "Avsluta flera enheter" : "Aktivera flera enheter";
        return new Button
        {
            Text = buttonText,
            Size = new Size(200, 60),
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Yu Gothic Medium", 14, FontStyle.Bold),
            ForeColor = Color.White,
            Cursor = Cursors.Hand,
            BackColor = Color.FromArgb(126, 108, 185)
        };
    }

    private Panel CreateBottomPanel(Button multiSelectionButton)
    {
        var panel = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.AliceBlue
        };
        panel.Controls.Add(multiSelectionButton);
        panel.Resize += (s, e) =>
        {
            multiSelectionButton.Location = new Point(
                panel.ClientSize.Width - multiSelectionButton.Width - 10,
                (panel.ClientSize.Height - multiSelectionButton.Height) / 2);
        };
        return panel;
    }

    private void SetupMultiSelectionButton(Button button, DeviceSelectionMode mode, DocumentSnapshot? targetDoc)
    {
        button.Click += async (sender, e) =>
        {
            var selectedButtons = checkboxes
                .Where(cb => cb.Checked && cb.Tag is Button)
                .Select(cb => (Button)cb.Tag)
                .ToList();

            if (!selectedButtons.Any())
            {
                MessageBox.Show(mode == DeviceSelectionMode.Running
                    ? "Välj minst en enhet att aktivera."
                    : "Välj minst en enhet.");
                return;
            }

            decimal minutes = 0;
            if (mode == DeviceSelectionMode.Start || mode == DeviceSelectionMode.Running)
            {
                var timeLimitForm = new TimeLimit();
                timeLimitForm.ShowDialog();
                minutes = timeLimitForm.Minutes;
                if (minutes == 0)
                    return;
            }

            foreach (var btn in selectedButtons)
            {
                switch (mode)
                {
                    case DeviceSelectionMode.Start:
                        {
                            var session = (Session)btn.Tag;
                            session.TimeLimit = minutes.ToString();
                            await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, session.Name, session);
                            break;
                        }
                    case DeviceSelectionMode.End:
                        {
                            var device = (Device)btn.Tag;
                            await _firestoreConnector.DeleteFieldAsync(_cafeName, _activatedDocument, device.Name);
                            break;
                        }
                    case DeviceSelectionMode.Running:
                        {
                            var tuple = (Tuple<Session, Label>)btn.Tag;
                            var session = tuple.Item1;
                            session.TimeLimit = minutes.ToString();
                            tuple.Item2.Text = $"{minutes} min kvar";
                            await _firestoreConnector.AddDocumentAsync(_cafeName, _activatedDocument, session.Name, session);
                            break;
                        }
                }
                if (mode == DeviceSelectionMode.Start || mode == DeviceSelectionMode.End)
                {
                    btn.Dispose();

                }
                var selectedCheckboxes = checkboxes.Where(cb => cb.Checked && cb.Tag is Button).ToList();
                foreach (var cb in selectedCheckboxes)
                {
                    if (mode == DeviceSelectionMode.Start || mode == DeviceSelectionMode.End)
                    {
                        cb.Dispose();
                        checkboxes.Remove(cb);
                    }
                    else
                    {
                        cb.Checked = false;
                    }
                }
            }
            string resultText = (mode == DeviceSelectionMode.Start || mode == DeviceSelectionMode.Running)
                ? $"Aktiverade {selectedButtons.Count} enheter{(minutes > 0 ? $" med {minutes} minuter." : ".")}"
                : $"Avslutade {selectedButtons.Count} enheter.";
            MessageBox.Show(resultText);
        };
    }

    #endregion
}
