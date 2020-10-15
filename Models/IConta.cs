using System;
using System.Collections.Generic;
using System.Text;

namespace Financial.Models
{
    interface IConta
    {
        decimal VizualisarSaldo();
        decimal GerarSaldo(decimal valor);
    }
}
