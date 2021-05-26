using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HNB_Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text;

namespace NS_HNB_Integration.Controllers
{
    [Route("api/integration")]
    [ApiController]
    public class HnbIntegrationController : ControllerBase
    {
        private IConfiguration _configuration;

        public HnbIntegrationController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }

        [HttpGet("run")]
        public async void Post()
        {
            HttpClient hnbClient = new HttpClient();
            string data = await hnbClient.GetStringAsync("https://api.hnb.hr/tecajn/v2");

            HttpClient nsClient = new HttpClient();
            HttpContent content = new StringContent(data, Encoding.UTF8, "application/json");
            await nsClient.PostAsync(_configuration["ClientSaveMethod"], content);
        }
    }
}