using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        /// Lista de Contas de Clientes
        /// </summary>
        /// <remarks>Geração de lista de contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        [HttpGet]
        public List<ContaPF> GetAll()
        {
            return GerarLista();
        }

        /// <summary>
        /// Lista de Contas Ordenada por nomes
        /// </summary>
        /// <remarks>Geração de lista de contas de clientes ordenada por nomes</remarks>
        /// <returns>Lista ordenada</returns>
        [HttpGet("Lista Ordenada por nomes")]
        public List<ContaPF> GetOrder()
        {
            var conta = new ContaPF(); 
            return GerarLista().OrderBy(conta => conta.NomeCompleto).ToList();
        }

        /// <summary>
        /// Numero de Contas na lista
        /// </summary>
        /// <remarks>Numero de contas de clientes na lista</remarks>
        /// <returns>Quantidade</returns>
        [HttpGet("Numero de Elementos")]
        public int GetCont()
        {
            var lista = GerarLista();
            return lista.Count();
        }

        /// <summary>
        /// Ultimo item da lista
        /// </summary>
        /// <remarks>Ultima conta de cliente na lista</remarks>
        /// <returns>Conta</returns>
        [HttpGet("Ultima conta da lista")]
        public ContaPF GetLast()
        {
            var lista = GerarLista();
            return lista.LastOrDefault<ContaPF>();
        }

        /// <summary>
        /// Busca de Conta por Id
        /// </summary>
        /// <remarks>Busca de lista de contas de clientes por id</remarks>
        /// <returns>Lista de Contas</returns>
        [HttpGet("{id}")]
        public ContaPF Get(int id)
        {
            return GerarLista()
                .FirstOrDefault(conta => conta.Id == id);
        }

        /// <summary>
        /// Adicionar Nova Conta
        /// </summary>
        /// <remarks>Adiciona contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ContaPF contaPF)
        {
            try
            {
                
                var listaConta = GerarLista();
                var lista = new ContaPF()
                {
                    Id = GerarLista().LastOrDefault<ContaPF>().Id + 1,
                    Agencia = contaPF.Agencia,
                    Conta = contaPF.Conta,
                    TipoConta = contaPF.TipoConta,
                    NomeCompleto = contaPF.NomeCompleto
                };
                listaConta.Add(lista);
                if(listaConta.Count > 5)
                {
                    return Ok(listaConta);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        /// <summary>
        /// Atualizar Conta de cliente
        /// </summary>
        /// <remarks>Atualização de contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        [HttpPut("{id}")]
        public ContaPF Put(int id, [FromBody] ContaPF contaPF)
        {
            try
            {
                var conta = Get(id);

                if (ValidarCampos(contaPF))
                {
                    conta.Agencia = contaPF.Agencia;
                    conta.Conta = contaPF.Conta;
                    conta.TipoConta = contaPF.TipoConta;
                    conta.NomeCompleto = contaPF.NomeCompleto;

                    return conta;
                }
                else
                {
                    throw new Exception("Há algum campo não preenchido!!!");
                }
            }
            catch (Exception)
            {

                throw new Exception("Há algum campo não preenchido!!!");
            }
            
        }

        /// <summary>
        /// Atualizar Nome de cliente
        /// </summary>
        /// <remarks>Atualização de nome de cliente</remarks>
        /// <returns>Conta atualizada</returns>
        [HttpPatch]
        public ContaPF Patch(int id, string nomeCompleto)
        {
            var conta = Get(id);

            conta.NomeCompleto = nomeCompleto;

            return conta;
        }

        /// <summary>
        /// Remover Conta de Cliente
        /// </summary>
        /// <remarks>Remoção de contas de clientes</remarks>
        /// <returns>Lista de Contas</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{idParam}")]
        public IActionResult Delete(int idParam)
        {
            try
            {
                //gerar lista
                var contas = GerarLista();

                //selecionar a conta desejada a remover
                var contaASerRemovida = contas.FirstOrDefault(item => item.Id == idParam);

                //Retorna se foi removido ou não
                var seRemovido = contas.Remove(contaASerRemovida);

                if (seRemovido)
                    return Ok(contaASerRemovida);
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound();
            }
        }
        #region Métodos privados
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

        private bool ValidarCampos(ContaPF conta)
        {
            if(conta.Agencia != 0 && conta.Conta != 0 && conta.NomeCompleto != null && conta.TipoConta != null)
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }
        #endregion
    }
}
/* 1 - Web Method para retornar a quantidade de itens da lista
 * 2 - web Method que retorne o último item (conta) da lista
 * 3 - Método privado para validar se todas as propriedades estão sendo inseridas, menos o id
 * 4 - Incrementar Web Method Patch para atualizar o nome completo*/
