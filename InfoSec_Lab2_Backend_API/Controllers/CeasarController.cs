using InfoSec_Lab2_Backend_API.Models;
using Microsoft.AspNetCore.Mvc;
using TZI.Models;
using TZI.Utils;

namespace TZI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CeasarController : Controller
    {
        // POST api/ceasar/decrypt
        [HttpPost]
        [Route("decrypt")]
        public IActionResult Post([FromBody]EncryptedMessage message)
        {
            var alphabet = message.Alphabet;
            var encryptedText = message.EncryptedText;

            Caesar cipher = new Caesar(alphabet);

            message.EncryptedText = cipher.Decrypt(encryptedText);

            return Json(message);
        }

        // POST api/ceasar/encrypt
        [HttpPost]
        [Route("encrypt")]
        public IActionResult Post([FromBody]DecryptedMessage message)
        {
            var alphabet = message.Alphabet;
            var key = message.Key;
            var decryptedText = message.DecryptedText;

            Caesar cipher = new Caesar(alphabet);

            message.DecryptedText = cipher.Encrypt(decryptedText, key);

            return Json(message);
        }
    }
}