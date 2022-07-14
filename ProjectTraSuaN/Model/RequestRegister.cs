using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTraSuaN.Model
{
    class RequestRegister
    {
        public RequestRegister()
        {
        }

        public string NameUser { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pass { get; set; }

        public string Role { get; set; }
    }
}
