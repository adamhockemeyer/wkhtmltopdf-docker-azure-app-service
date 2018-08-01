using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HtmlToPDF.Controllers
{
    [Route("api/[controller]")]
    public class ConvertController : Controller
    {
        private IConverter _converter;

        public ConvertController(IConverter converter)
        {
            _converter = converter;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(string url)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.Letter,
                    Orientation = Orientation.Portrait,
                    ViewportSize = "1280x1024"
                }
                
            };

            if(!string.IsNullOrEmpty(url))
            {
                doc.Objects.Add(new ObjectSettings { Page = url,  });
            }

            byte[] pdf = _converter.Convert(doc);


            return new FileContentResult(pdf, "application/pdf");
        }

        [HttpPost]
        public IActionResult Post(string html)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.Letter,
                    Orientation = Orientation.Landscape
                }

            };

            if (!string.IsNullOrEmpty(html))
            {
                doc.Objects.Add(new ObjectSettings {  HtmlContent = html });
            }

            byte[] pdf = _converter.Convert(doc);


            return new FileContentResult(pdf, "application/pdf");
        }
    }
}