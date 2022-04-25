using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EphemeralController : ControllerBase
    {
        // GET api/<PerpetualController>/5
        [HttpGet]
        public object Get()
        {
            var yamlfile = new StreamReader("ConfigSettings\\Ephemeral\\provision_ephemeral_config.yml");
            var yaml = new Deserializer();
            var Resultobject = yaml.Deserialize(yamlfile);

            return Resultobject;
        }
    }
}