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
            //Validar command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Verifica Email Existe
            var usuarioExiste = _usuarioRepositorio.BuscarPorEmail(command.Email);

            if(usuarioExiste != null)
                return new GenericCommandResult(false, "Email já cadastrado", null);

            //Criptografar Senha
            command.Senha = Senha.Criptografar(command.Senha);

            //Cria instancia do usuario passando os parametros
            var usuario = new Usuario(command.Nome, command.Email, command.Senha, command.TipoUsuario);

            //Se passou o telefone altera
            if (!string.IsNullOrEmpty(command.Telefone)) 
                usuario.AdicionarTelefone(command.Telefone);

            //verifica se os dados do usuario sao validos
            if(usuario.Invalid)
                return new GenericCommandResult(false, "Usuário inválido", usuario.Notifications);

            _usuarioRepositorio.Adicionar(usuario);


            //Enviar Email Boas Vinhas
            return new GenericCommandResult(true, "Usuário Criado", usuario);
        }
    }
}
 