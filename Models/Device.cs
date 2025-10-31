using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCafe.Models
{
    public class Device
    {
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool IsLocked { get; set; }

    }
}
