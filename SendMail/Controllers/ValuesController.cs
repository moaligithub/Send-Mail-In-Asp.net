using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendMail.Dtos;
using SendMail.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SendMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEmailSend _emailSend;

        public ValuesController(IEmailSend emailSend)
        {
            _emailSend = emailSend;
        }
        [HttpPost]
        public async Task<IActionResult> SendMail([FromForm]SendDto dto)
        {
            await _emailSend.SendMail(dto.ToEmail, dto.Subject, dto.Body);

            return Ok();
        }
    }
}
