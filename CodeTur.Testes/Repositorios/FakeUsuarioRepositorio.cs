using CodeTur.Dominio.Entidades;
using CodeTur.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Testes.Repositorios
{
    public class FakeUsuarioRepositorio : IUsuarioRepositorio
    {
        List<Usuario> Usuarios = new List<Usuario>()
            {
                new Usuario("lucca", "email2@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum),
                new Usuario("kaua", "email3@email.com", "1234567", Comum.Enum.EnTipoUsuario.Comum)
            };

        public void Adicionar(Usuario usuario)
        {
            Usuarios.Add(usuario);
        }

        public void Alterar(Usuario usuario)
        {

        }

        public void AlterarSenha(Usuario usuario)
        {

        }

        public Usuario BuscarPorEmail(string email)
        {
            return Usuarios.FirstOrDefault(x => x.Email == email);
        }

        public Usuario BuscarPorId(Guid id)
        {
            return Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public ICollection<Usuario> Listar()
        {
            return Usuarios;
        }
    }
}
