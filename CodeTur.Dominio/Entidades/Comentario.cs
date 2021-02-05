using CodeTur.Comum.Entidades;
using CodeTur.Comum.Enum;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Entidades
{
    class Comentario : Entidade
    {
        public Comentario(string texto, string sentimento, Guid idUsuario, EnStatusComentario status, Guid idPacotes)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Texto, "Texto", "")
                .IsNotNullOrEmpty(Sentimento, "Sentimento", "")
                .AreNotEquals(IdUsuario, Guid.Empty, "IdUsuario", "")
                .AreNotEquals(IdPacote, Guid.Empty, "IdPacote", "")
                );
            Texto = texto;
            Sentimento = sentimento;
            IdUsuario = idUsuario;
            IdPacote = idPacotes;
            Status = status;
        }

        public string Texto { get; private set; }
        public string Sentimento { get; private set; }
        public EnStatusComentario Status { get; private set; }
        public Guid IdUsuario { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public Guid IdPacote { get; private set; }
        public virtual Pacote Pacote { get; private set; }
    }
}
