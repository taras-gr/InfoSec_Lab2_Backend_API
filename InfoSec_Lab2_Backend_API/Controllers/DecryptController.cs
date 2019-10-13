using Microsoft.AspNetCore.Mvc;
using TZI.Models;
using TZI.Utils;

namespace TZI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecryptController : Controller
    {
        // POST api/decrypt
        [HttpPost]
        public IActionResult Post([FromBody]EncryptedMessage message)
        {
            var aplhabet = message.Alphabet;
            var encryptedText = message.EncryptedText;

            Caesar cipher = new Caesar(aplhabet);

            message.EncryptedText = cipher.Decrypt(encryptedText);

            return Json(message);
        }
    }
}