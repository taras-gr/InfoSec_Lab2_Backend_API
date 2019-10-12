using Microsoft.AspNetCore.Mvc;
using TZI.Models;
using TZI.Utils;

namespace TZI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CeasarController : Controller
    {
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]EncryptedText message)
        {
            Caesar cipher = new Caesar();

            message.CodedText = cipher.Decrypt(message.CodedText);

            return Json(message);
        }
    }
}