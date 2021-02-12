using CodeTur.Comum.Comands;
using CodeTur.Comum.Handlers;
using CodeTur.Dominio.Commands.Pacote;
using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class CriarPacoteCommandHandler : IHandlerCommand<CriarPacoteCommand>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;
        public CriarPacoteCommandHandler(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }
        public ICommandResult Handle(CriarPacoteCommand command)
        {
            //Valida Command
            command.Validar();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);
            //Verifica se existe um pacote com o mesmo titulo
            var pacoteexiste = _pacoteRepositorio.BuscarPorTitulo(command.Titulo);

            if (pacoteexiste != null)
                return new GenericCommandResult(false, "Título do pacote já cadastrado", null);
            //Gera entidade Pacote
            var pacote = new Pacote(command.Titulo, command.Descricao, command.Imagem, command.Ativo);


            if (pacote.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", pacote.Notifications);

            //Adiciona no banco
            _pacoteRepositorio.Adicionar(pacote);

            //retorna mensagem sucesso
            return new GenericCommandResult(true, "Pacote criado", pacote);
        }
    }
}
