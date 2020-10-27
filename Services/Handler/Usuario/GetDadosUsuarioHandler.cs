using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Financial.Aplication.Usuario;
using Financial.Aplication.ValueObject;

namespace Financial.Services.Handler.Usuario
{
    public class GetDadosUsuarioHandler : IRequestHandler<GetDadosUsuario, UsuarioVO>
    {
        public GetDadosUsuarioHandler()
        {
        }

        public Task<UsuarioVO> Handle(GetDadosUsuario request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
