using InfoSec_Lab2_Backend_API.Models;
using InfoSec_Lab2_Backend_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace InfoSec_Lab2_Backend_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class VigenereController : Controller
    {
        // POST api/vigenere/decrypt
        [HttpPost]
        [Route("decrypt")]
        public IActionResult DecryptMessage([FromBody]VigenereModel message)
        {
            var encryptedText = message.Message;
            var alphabet = message.Alphabet;
            var password = message.Password;

            VigenereCipher cipher = new VigenereCipher(alphabet);

            message.Message = cipher.Decrypt(encryptedText, password);

            return Json(message);
        }

        // POST api/vigenere/encrypt
        [HttpPost]
        [Route("encrypt")]
        public IActionResult EncryptMessage([FromBody]VigenereModel message)
        {
            var plainText = message.Message;
            var alphabet = message.Alphabet;
            var password = message.Password;

            VigenereCipher cipher = new VigenereCipher(alphabet);

            message.Message = cipher.Encrypt(plainText, password);

            return Json(message);
        }
    }
}
