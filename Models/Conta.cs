using Financial.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financial.Models
{
    public class Conta : IConta
    {
        #region Propriedades
        #region Dados Individuais
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Endereco { get; set; }
        #endregion
        #region DadosConta
        public string PacoteServico { get; set; }
        public TipoConta TipoConta { get; set; }
        #endregion
        #endregion

        #region Metodos
        public decimal VizualisarSaldo()
        {
            throw new NotImplementedException();
        }

        public decimal GerarSaldo(decimal valor)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
