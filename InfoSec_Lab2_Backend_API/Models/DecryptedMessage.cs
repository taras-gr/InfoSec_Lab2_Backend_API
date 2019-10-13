using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoSec_Lab2_Backend_API.Models
{
    public class DecryptedMessage
    {
        public string DecryptedText { get; set; }
        public string Alphabet { get; set; }
        public int Key { get; set; }
    }
}
