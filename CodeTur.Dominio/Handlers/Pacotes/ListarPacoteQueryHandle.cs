using CodeTur.Comum.Handlers;
using CodeTur.Comum.Queries;
using CodeTur.Dominio.Queries.Pacotes;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Handlers.Pacotes
{
    public class ListarPacoteQueryHandle : IHandlerQuery<ListarPacotesQuery>
    {
        private readonly IPacoteRepositorio _pacoteRepositorio;
        public ListarPacoteQueryHandle(IPacoteRepositorio pacoteRepositorio)
        {
            _pacoteRepositorio = pacoteRepositorio;
        }
        public IQueryResult Handle(ListarPacotesQuery query)
        {
            var pacotes = _pacoteRepositorio.Listar(query.Ativo);

            var retornoPacotes = pacotes.Select(
                    p =>
                    {
                        return new ListarPacoteQueryResult
                        {
                            Id= p.Id,
                            Titulo = p.Titulo,
                            Descricao = p.Descricao,
                            Imagem = p.Imagem,
                            Ativo = p.Ativo,
                            QuantidadeComentarios = p.Comentarios.Count(),
                            DataCriacao = p.DataCriacao
                        };
                    }
                );

            List<ListarPacoteQueryResult> IsPacotes = new List<ListarPacoteQueryResult>();
            foreach (var item in pacotes)
            { 
                var itemPacote = new ListarPacoteQueryResult();
                itemPacote.Titulo = item.Titulo;
                itemPacote.Id = item.Id;

                IsPacotes.Add(itemPacote);
           }
            return new GenericQueryResult(true, "Lista de Pacotes", retornoPacotes);
        }
    }
}
