using InfoSec_Lab2_Backend_API.Models;
using Microsoft.AspNetCore.Mvc;
using TZI.Models;
using TZI.Utils;

namespace TZI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController : Controller
    {
        // POST api/ceasar
        [HttpPost]
        public IActionResult Post([FromBody]DecryptedMessage message)
        {
            var aplhabet = message.Alphabet;
            var key = message.Key;
            var decryptedText = message.DecryptedText;

            Caesar cipher = new Caesar(aplhabet);

            message.DecryptedText = cipher.Encrypt(decryptedText, key);

            return Json(message);
        }
    }
}