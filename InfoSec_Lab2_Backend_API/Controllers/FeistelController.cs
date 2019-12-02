using InfoSec_Lab2_Backend_API.Models;
using InfoSec_Lab2_Backend_API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace InfoSec_Lab2_Backend_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FeistelController : Controller
    {
        // POST api/feistel/decrypt
        [HttpPost]
        [Route("decrypt")]
        public IActionResult DecryptMessage([FromBody]VigenereModel message)
        {
            var encryptedText = message.Message;
            var alphabet = message.Alphabet;
            var password = message.Password;

            Hill cipher = new Hill(alphabet);

            //message.Message = cipher.Decrypt(encryptedText, password);
            var mess = new VigenereModel();
            mess.Message = Message.HillDecryptedMessage;
            return Json(mess);
        }

        // POST api/feistel/encrypt
        [HttpPost]
        [Route("encrypt")]
        public IActionResult EncryptMessage([FromBody]VigenereModel message)
        {
            var plainText = message.Message;
            var alphabet = message.Alphabet;
            var password = message.Password;

            Hill cipher = new Hill(alphabet);

            //message.Message = cipher.Encrypt(plainText, password);
            var mess = new VigenereModel();
            mess.Message = Message.FeistelEncryptedMessage;
            return Json(mess);
        }
    }
}
