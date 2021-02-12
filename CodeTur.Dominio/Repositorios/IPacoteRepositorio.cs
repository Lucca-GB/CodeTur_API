using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Repositorios
{
    public interface IPacoteRepositorio
    {
        void Adicionar(Pacote pacote);
        void Alterar(Pacote pacote);
        IEnumerable<Pacote> Listar(bool? ativo = null);
        Pacote BuscarPorTitulo(string titulo);
        Pacote BuscarPorId(Guid id);
    }
}
