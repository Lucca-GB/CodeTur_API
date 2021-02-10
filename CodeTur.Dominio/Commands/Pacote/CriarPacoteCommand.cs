using CodeTur.Comum.Comands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Pacote
{
    public class CriarPacoteCommand : Notifiable, ICommand
    {
        public CriarPacoteCommand(string titulo, string descricao, string imagem, bool ativo)
        {
            Titulo = titulo;
            Descricao = descricao;
            Imagem = imagem;
            Ativo = ativo;
        }

        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Imagem { get; private set; }
        public bool Ativo { get; private set; }

        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Informe o Título do pacote")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Informe o Descrição do pacote")
                .IsNotNullOrEmpty(Imagem, "Imagem", "Informe o Imagem do pacote")
                );
        }
    }
}
