using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using ManageSales.Data;
using ManageSales.Models;
using ManageSales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageSales.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ISaleServices _saleService;
        public ValuesController(ISaleServices saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IEnumerable<string> Get(int idOrder)
        {
            return new string[] { "ok", "up" };
        }

        [HttpPost]
        public IActionResult Upload(IFormFile upload){

            var stream = upload.OpenReadStream();
            this._saleService.SaveData(stream);
            return Ok("");
        }
    }
}
