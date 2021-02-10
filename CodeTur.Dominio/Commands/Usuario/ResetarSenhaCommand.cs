using CodeTur.Comum.Comands;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Dominio.Commands.Usuario
{
    public class ResetarSenhaCommand : Notifiable, ICommand
    {
        public ResetarSenhaCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
        public void Validar()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Email", "Informe um email válido")
                );
        }
    }
}
