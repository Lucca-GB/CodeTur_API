using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using CodeTur.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTur.Infra.Data.Repositorios
{
    public class PacoteRepositorio : IPacoteRepositorio
    {
        private readonly CodeTurContext _context;
        public PacoteRepositorio(CodeTurContext context)
        {
            _context = context;
        }
        public void Adicionar(Pacote pacote)
        {
            _context.Pacotes.Add(pacote);
            _context.SaveChanges();
        }

        public void Alterar(Pacote pacote)
        {
            _context.Entry(pacote).State = EntityState.Modified;
        }

        public Pacote BuscarPorId(Guid id)
        {
            return _context
                .Pacotes
                .AsNoTracking()
                .Include(x => x.Comentarios)
                .FirstOrDefault(p => p.Id == id);
        }

        public Pacote BuscarPorTitulo(string titulo)
        {
            return _context
                .Pacotes
                .AsNoTracking()
                .Include(x => x.Comentarios)
                .FirstOrDefault(p => p.Titulo.ToLower() == titulo.ToLower());
        }

        public IEnumerable<Pacote> Listar(bool? ativo = null)
        {
            if (ativo == null)
                return _context
                    .Pacotes
                    .AsNoTracking()
                    .Include(x => x.Comentarios)
                    .OrderBy(x => x.DataCriacao);
            else
                return _context
                    .Pacotes
                    .AsNoTracking()
                    .Include(x => x.Comentarios)
                    .Where(x => x.Ativo == ativo)
                    .OrderBy(x => x.DataCriacao);
        }
    }
}
