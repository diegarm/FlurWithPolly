using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FlurlPolly.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlurPollyController : ControllerBase
    {
        private readonly ILogger<FlurPollyController> _logger;

        [HttpGet]
        public async Task<bool> Get()
        {

            try
            {
                var result = await "http://localhost:2931/weatherforecast".GetJsonAsync();

                Debug.WriteLine("Api Sucesso");
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Api Falhou");
                throw;
            }
        }
    }
}
