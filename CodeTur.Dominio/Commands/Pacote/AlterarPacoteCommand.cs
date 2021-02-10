using CodeTur.Comum.Comands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacote
{
    public class AlterarPacoteCommand : Notifiable, ICommand 
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public bool Ativo { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o Titulo do pacote")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe a Descricao do pacote")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe a Imagem do pacote")
                );
        }
    }
}
