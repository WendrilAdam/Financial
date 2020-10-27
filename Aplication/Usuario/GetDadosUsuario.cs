using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Financial.Aplication.ValueObject;

namespace Financial.Aplication.Usuario
{
    public class GetDadosUsuario : IRequest<UsuarioVO>
    {
        private int id;

        public GetDadosUsuario(int id)
        {
            this.id = id;
        }
    }
}
