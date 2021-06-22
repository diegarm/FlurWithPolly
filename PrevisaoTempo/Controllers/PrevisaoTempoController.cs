using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PrevisaoTempo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrevisaoTempoController : ControllerBase
    {

        [HttpPost]
        [Route("retry")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetryAsync(int boletoChangeId)
        {
            return Retry();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Retry();
        }

        private IActionResult Retry()
        {
            var randomNumber = new Random();
            var randomInteger = randomNumber.Next(0, 8);

            switch (randomInteger)
            {
                case 0:
                    Debug.WriteLine("Webservice:About to serve a 404...");
                    return StatusCode(StatusCodes.Status404NotFound);

                case 1:
                    Debug.WriteLine("Webservice:About to serve a 503...");
                    return StatusCode(StatusCodes.Status503ServiceUnavailable);

                case 2:
                    Debug.WriteLine("Webservice:Sleeping for 10 seconds then serving a 504...");
                    Thread.Sleep(10000);
                    Debug.WriteLine("Webservice:About to serve a 504...");

                    return StatusCode(StatusCodes.Status504GatewayTimeout);
                default:
                    {
                        var formattedCustomObject = JsonConvert.SerializeObject(
                            new
                            {
                                WeekDay = DateTime.Today.DayOfWeek.ToString()
                            });

                        Debug.WriteLine("Webservice:About to correctly serve a 200 response");

                        return Ok(formattedCustomObject);
                    }
            }
        }
    }
}
