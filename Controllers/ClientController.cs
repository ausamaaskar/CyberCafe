using CyberCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberCafe.Controllers
{
    public class ClientController : Device
    {
        public ClientController() 
        {
            IsAdmin = false;
        }
    }
}
