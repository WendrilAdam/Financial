using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaPFController : ControllerBase
    {
        private static readonly string[] TipoConta = new[]
        {
            "Poupança","Conta Corrente","Conta salário","Depósito judicial"
        };

        private static readonly string[] NomeCompleto = new[]
        {
            "João","Creuza","José","Denise"
        };

        private readonly ILogger<ContaPFController> _logger;

        public ContaPFController(ILogger<ContaPFController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// List of weather around the world
        /// </summary>
        /// <remarks>Generate a list of weather around the worlds</remarks>
        /// <returns>List of weathers</returns>
        // GET: api/<ContaPFController>
        [HttpGet]
        public IEnumerable<ContaPF> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ContaPF
            {
                Agencia = rng.Next(1111, 9999),
                Conta = rng.Next(111111, 999999),
                TipoConta = TipoConta[rng.Next(TipoConta.Length)],
                NomeCompleto = NomeCompleto[rng.Next(NomeCompleto.Length)]
            })
            .ToArray();
        }

        // GET api/<ContaPFController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContaPFController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContaPFController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContaPFController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
