using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Api.Singletons;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("/")]
    public class ConversionController: ControllerBase
    {

        private readonly IRtfHtmlConverter _rtfHtmlConverter;

        public ConversionController(IRtfHtmlConverter rtfHtmlConverter)
        {
            _rtfHtmlConverter = rtfHtmlConverter;
        }

        [HttpGet("/")]
        public async Task<IActionResult> HelloWorldAsync(CancellationToken cancellationToken)
        {
            try
            {
                return Ok("Hello world");
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost("to_html", Name = "Converts RTF string to HTML")]
        [Consumes("text/plain")]
        public async Task<IActionResult> ToHtmlAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var streamReader = new StreamReader(Request.Body, Encoding.UTF8);
                var str = await streamReader.ReadToEndAsync();
                return Ok(_rtfHtmlConverter.ToHtml(str));
            }
            catch (Exception e)
            {
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPost("to_rtf", Name = "Converts HTML string to RTF")]
        [Consumes("text/plain")]
        public async Task<IActionResult> ToRtfAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var streamReader = new StreamReader(Request.Body, Encoding.UTF8);
                var str = await streamReader.ReadToEndAsync();
                return Ok(_rtfHtmlConverter.ToRtf(str));
            }
            catch (Exception e)
            {
                return Problem(e.InnerException?.Message ?? e.Message);
            }
        }
    }
}