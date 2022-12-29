using Accelerator1.Model;
using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Accelerator1.Controllers
{
    [Route("")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private AcceleratorContext _dbcontext;

        public IQRService _qrService { get; } //QR сервис для которого оплачена лицензия

        public UrlController(AcceleratorContext _context, IQRService qrService)
        {
            _dbcontext = _context;
            _qrService = qrService;
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var redir = new RedirectURL();
            redir.Get(id, _dbcontext);
            var url = redir.website;
            if (url == null)
                return NotFound();
            return Redirect(url);
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (value == null || value == "")
                throw new ArgumentException("value argument must not be null or empty");
            var redir = new RedirectURL();
            redir.Create(value, _dbcontext);
            if (redir.shortUrl == null)
                throw new Exception("shortUrl creatin gone wrong");
            var QR = _qrService.websiteToQR(value);
            var result = new UrlCreateResult(redir.shortUrl, QR);
            return Ok(result);
        }
    }
}
