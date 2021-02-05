using CodeTur.Comum.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Entidades
{
    class Pacote : Entidade
    {
        private readonly List<Comentario> _comentarios;

        public Pacote(string titulo, string descricao, string imagem, bool ativo);

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }
        public IReadOnlyCollection<Comentario> Comentarios { get { return _comentarios.ToArray(); } }
        public void AdicionarComentario(Comentario comentario)
        {
            if (_comentarios.Any(x => x.IdUsuario == comentario.IdUsuario))
                AddNotification("Comentarios", "Usuário já possui um comentário neste pacote");

            if(Valid)
                _comentarios.Add(comentario);
        }
        
        public void AtivarPacote()
        {
            Ativo = true;
        }
        public void DesativarPacote()
        {
            
        }
        public void AtualizarPacote(string titulo, string descricao)
        {

        }
        public void AtualizarImagem(string imagem)
        {

        }
    }
}
