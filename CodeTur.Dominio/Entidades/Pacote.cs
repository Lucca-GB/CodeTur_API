using CodeTur.Comum.Entidades;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTur.Dominio.Entidades
{
    public class Pacote : Entidade
    {
        private readonly IList<Comentario> _comentarios;

        public Pacote(string titulo, string descricao, string imagem, bool ativo)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informe o titulo do pacote")
                .IsNotNullOrEmpty(descricao, "Descricao", "Informe a descricao do pacote")
                .IsNotNullOrEmpty(imagem, "Imagem", "Informe a imamgem do pacote")
                );
            if (Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
                Imagem = imagem;
                Ativo = ativo;
                _comentarios = new List<Comentario>();
            }
        }


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
            Ativo = false;
        }
        public void AtualizarPacote(string titulo, string descricao)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(titulo, "Titulo", "Informeo o titulo do pacote")
                .IsEmailOrEmpty(descricao, "Descricao", "Informe a Descricao do pacote")
                );
            if(Valid)
            {
                Titulo = titulo;
                Descricao = descricao;
            }
        }
        public void AtualizarImagem(string imagem)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(imagem, "Imagem", "")
                );
            if (Valid)
                Imagem = imagem;
        }
    }
}
