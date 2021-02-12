using CodeTur.Comum.Comands;
using CodeTur.Comum.Handlers;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using Flunt.Notifications;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class CriarUsuarioHandle : Notifiable, IHandlerCommand<CriarUsuarioCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public CriarUsuarioHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(CriarUsuarioCommand command)
        {
            //Fail Fast Validation
            //TODO : Validar command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //TODO : Verifica Email Existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if(usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            //TODO : Criptografar Senha
            command.Senha = Senha.Criptografar(command.Senha);

            //TODO : Salvar Usuário
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);
            if (!string.IsNullOrEmpty(command.Telefone))
                usuario.AdicionarTelefone(command.Telefone);

            if(usuario.Invalid)
                return new GenericCommandResult(false, "Usuário inválido", usuario.Notifications);


            //TODO : Enviar Email Boas Vinhas
            return new GenericCommandResult(true, "Usuário Criado", null);
        }
    }
}
 