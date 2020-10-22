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

        private List<ContaPF> GerarLista()
        {
            var rng = new Random();
            var listaContas = Enumerable.Range(1, 2).Select(index => new ContaPF
            {
                Agencia = rng.Next(1111, 9999),
                Conta = rng.Next(111111, 999999),
                TipoConta = TipoConta[rng.Next(TipoConta.Length)],
                NomeCompleto = NomeCompleto[rng.Next(NomeCompleto.Length)]
            })
            .ToList();

            listaContas.Add(new ContaPF
            {
                Agencia = 1234,
                Conta = 123456,
                TipoConta = "Poupança",
                NomeCompleto = "Wendril Adam"
            });
            listaContas.Add(new ContaPF
            {
                Agencia = 2345,
                Conta = 234567,
                TipoConta = "Poupança",
                NomeCompleto = "Nayla Gomes"
            });
            listaContas.Add(new ContaPF
            {
                Agencia = 3456,
                Conta = 345678,
                TipoConta = "Conta Corrente",
                NomeCompleto = "Thiago Barcellos"
            });
            listaContas.Add(new ContaPF
            {
                Agencia = 4567,
                Conta = 456789,
                TipoConta = "Conta Corrente",
                NomeCompleto = "Everton Teodoro"
            });

            var id = 1;
            foreach (var item in listaContas)
            {
                item.Id = id;
                id++;
            }
            return listaContas;
        }

        private readonly ILogger<ContaPFController> _logger;

        public ContaPFController(ILogger<ContaPFController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Lista de Contas de Clientes
        /// </summary>
        /// <remarks>Geração de lista de contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        // GET: api/<ContaPFController>
        [HttpGet]
        public List<ContaPF> GetAll()
        {
            /*var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ContaPF
            {
                Agencia = rng.Next(1111, 9999),
                Conta = rng.Next(111111, 999999),
                TipoConta = TipoConta[rng.Next(TipoConta.Length)],
                NomeCompleto = NomeCompleto[rng.Next(NomeCompleto.Length)]
            })
            .ToList();*/
            return GerarLista();
        }

        /// <summary>
        /// Busca de Conta por Id
        /// </summary>
        /// <remarks>Busca de lista de contas de clientes por id</remarks>
        /// <returns>Lista de Contas</returns>
        // GET api/<ContaPFController>/5
        [HttpGet("{id}")]
        public ContaPF GetById(int id)
        {
            return GerarLista()
                .FirstOrDefault(conta => conta.Id == id);
        }

        /// <summary>
        /// Adicionar Nova Conta
        /// </summary>
        /// <remarks>Adiciona contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        // POST api/<ContaPFController>
        [HttpPost]
        public IEnumerable<ContaPF> Post([FromBody] ContaPF contaPF)
        {
            var lista = new List<ContaPF>();
            lista.Add(new ContaPF
            {
                Id = contaPF.Id,
                Agencia = contaPF.Agencia,
                Conta = contaPF.Conta,
                TipoConta = contaPF.TipoConta,
                NomeCompleto = contaPF.NomeCompleto
            });
            return GerarLista().Append(contaPF);
        }

        /// <summary>
        /// Atualizar Conta de cliente
        /// </summary>
        /// <remarks>Atualização de contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        // PUT api/<ContaPFController>/5
        [HttpPut("{id}")]
        public ContaPF Put(int id, [FromBody] ContaPF contaPF)
        {
            var conta = GetById(id);

            conta.Agencia = contaPF.Agencia;
            conta.Conta = contaPF.Conta;
            conta.TipoConta = contaPF.TipoConta;
            conta.NomeCompleto = contaPF.NomeCompleto;

            return conta;
        }

        /// <summary>
        /// Remover Conta de Cliente
        /// </summary>
        /// <remarks>Remoção de contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        // DELETE api/<ContaPFController>/5
        [HttpDelete("{id}")]
        public ContaPF Remove(int id, [FromBody] ContaPF contaPF)
        {
            var conta = GetById(id);
            var cont = new List<ContaPF>();

            cont.RemoveAll(conta => conta.Id == id);
            return conta;
        }
    }
}
