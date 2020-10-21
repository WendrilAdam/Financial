﻿using Financial.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financial.Models
{
    public class ContaPessoaFisica : Conta
    {
        public int Agencia { get; set; }
        public int Conta { get; set; }

        public string TipoConta { get; set; }
        public string NomeCompleto { get; set; }
    }
}
