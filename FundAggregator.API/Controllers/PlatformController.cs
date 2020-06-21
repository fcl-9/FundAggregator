using System;
using System.Collections.Generic;
using System.Linq;
using FundAggregator.API.Commands;
using FundAggregator.API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Raven.Client.Documents;
using Raven.Client.Documents.Commands;
using Raven.Client.Documents.Session;

namespace FundAggregator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IDocumentStore _documentStore;
        private static List<CreatePlatformConfiguration> platformConfigurationCommands = null ;
        public PlatformController(IDocumentStore documentStore) {
            _documentStore = documentStore;
            if (platformConfigurationCommands == null)
            {
                platformConfigurationCommands = new List<CreatePlatformConfiguration>();
            }
        }

        [HttpGet("accounts")]
        public IActionResult ConfiguredPlatforms() {
            //using (IDocumentSession session = _documentStore.OpenSession())
            //{
            //    return Ok(session.Query<CreatePlatformConfiguration>().ToList());
            //}
            return Ok(platformConfigurationCommands.Select(command => MapCommandToViewModel(command)));
        }
        
        [HttpPost("accounts")]
        public IActionResult CreatePlatformConfiguration(CreatePlatformConfiguration platformConfigurationCommand)
        {
            platformConfigurationCommands.Add(platformConfigurationCommand);
            return Ok();

            //using (IDocumentSession session = _documentStore.OpenSession())
            //{
            //    session.Store(platformConfigurationCommand);
            //    session.SaveChanges();
            //    return Ok();
            //}
        }

        [HttpGet]
        public IActionResult Platforms() {
            //using (IDocumentSession session = _documentStore.OpenSession())
            //{
            //    return Ok(session.Query<PlatformConfigurationViewModel>().ToList());
            //}
            return Ok(new List<string>() { 
                "Hardgreaves Lansdown",
                "Vanguard"
            });
        }

        private PlatformConfigurationViewModel MapCommandToViewModel(CreatePlatformConfiguration command)
        {
            return new PlatformConfigurationViewModel()
            {
                PlatformName = command.PlatformName,
                Username = command.Username,
                Password = command.Password
            };
        }
    }
}
