using System;
using FundAggregator.API.Commands;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Raven.Client.Documents;

namespace FundAggregator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformConfigurationController : ControllerBase
    {
        private readonly IDocumentStore documentDb;

        public PlatformConfigurationController(IDocumentStore documentDb) {
            this.documentDb = documentDb;
        }

        [HttpGet]
        public IActionResult ConfiguredPlatforms() {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public IActionResult CreatePlatformConfiguration(CreatePlatformConfiguration platformConfigurationCommand)
        {
            Console.WriteLine(JsonConvert.SerializeObject(platformConfigurationCommand));
            return Ok();
        }
    }
}
