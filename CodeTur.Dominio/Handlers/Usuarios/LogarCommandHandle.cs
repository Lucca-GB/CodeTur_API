using CodeTur.Comum.Comands;
using CodeTur.Comum.Handlers;
using CodeTur.Comum.Util;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Usuarios
{
    public class LogarCommandHandle : IHandlerCommand<LogarCommand>
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LogarCommandHandle(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public ICommandResult Handle(LogarCommand command)
        {
            //Validar Command
            command.Validar();

            if (command.Valid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            //Buscar usuário pelo e-mail
            var usuario = _usuarioRepositorio.BuscarPorEmail(command.Email);

            //Verificar usuário existe
            if(usuario == null)
                return new GenericCommandResult(false, "E-mail inválido", null);

            //Verificar senha é valida
            if (!Senha.Validar(command.Senha, usuario.Senha))
                return new GenericCommandResult(false, "Senha inválida", null);

            //Retornar true e os dados do usuário
            return new GenericCommandResult(true, "Usuário Logado", usuario);
        }
    }
}
