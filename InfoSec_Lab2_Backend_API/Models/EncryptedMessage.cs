using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TZI.Models
{
    public class EncryptedMessage
    {
        public string EncryptedText { get; set; }
        public string Alphabet { get; set; }
    }
}