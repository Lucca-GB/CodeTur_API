using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace CodeTur.Dominio.Repositorios
{
    public interface IUsuarioRepositorio
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">Dados do usuário</param>
        void Adicionar(Usuario usuario);
        void Alterar(Usuario usuario);
        Usuario BuscarPorEmail(string email);
        Usuario BuscarPorId(Guid id);
        ICollection<Usuario> Listar();
    }
}
