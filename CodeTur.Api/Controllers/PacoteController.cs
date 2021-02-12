using CodeTur.Comum.Comands;
using CodeTur.Comum.Enum;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Handlers.Pacotes;
using CodeTur.Dominio.Queries.Pacotes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace CodeTur.Api.Controllers
{
    [Route("v1/package")]
    [ApiController]
    public class PacoteController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public GenericCommandResult Create(CriarPacoteCommand command,
                                            [FromServices] CriarPacoteCommandHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet]
        [Authorize]
        public GenericQueryResult GetAll([FromServices] ListarPacoteQueryHandle handle)
        {
            //Crio um objeto
            ListarPacotesQuery query = new ListarPacotesQuery();

            //Pega qual o tipo de usuário
            var tipoUsuario = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            
            //Verifica se o tipo de usuario é comum
            if (tipoUsuario.Value.ToString() == EnTipoUsuario.Comum.ToString())
                query.Ativo = true; //Se for comum defina que só quer visualizar os pacotes ativos

            return (GenericQueryResult)handle.Handle(query);
        }
    }
}
