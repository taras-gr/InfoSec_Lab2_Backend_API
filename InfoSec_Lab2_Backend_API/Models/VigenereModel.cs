using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSec_Lab2_Backend_API.Models
{
    public class VigenereModel
    {
        public string Message { get; set; }
        public string Alphabet { get; set; }
        public string Password { get; set; }
    }
}
