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
    public partial class TimeLimit : Form
    {
        public decimal Minutes;

        public TimeLimit()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (TimeLimitInput.Value == 0)
            {
                MessageBox.Show("Ange antal minuter");
                return;
            }

            Minutes = TimeLimitInput.Value;
            this.Close();
        }
    }
}
