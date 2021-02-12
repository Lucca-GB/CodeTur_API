using CodeTur.Comum.Comands;
using CodeTur.Dominio.Commands.Usuario;
using CodeTur.Dominio.Handlers.Usuarios;
using CodeTur.Testes.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeTur.Testes.Handlers.Usuario
{
    public class CriarUsuarioHandleTestes
    {
        [Fact]
        public void Deve_Retornar_Erro_Se_Os_Dados_Do_Handler_Forem_Invalidos()
        {
            //Criar um command
            var command = new CriarUsuarioCommand("Lucca",
                                                  "email@email.com",
                                                  "",
                                                  "",
                                                  Comum.Enum.EnTipoUsuario.Comum);
            //Criar um handle
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());
            //pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);
            //valida a condição
            Assert.False(resultado.Sucesso, "Usuário é válido");
        }
        [Fact]
        public void Deve_Retornar_Erro_Se_Os_Dados_Do_Handler_Forem_Validos()
        {
            //Criar um command
            var command = new CriarUsuarioCommand("Lucca",
                                                  "email@email.com",
                                                  "1234567",
                                                  "",
                                                  Comum.Enum.EnTipoUsuario.Comum);
            //Criar um handle
            var handle = new CriarUsuarioHandle(new FakeUsuarioRepositorio());
            //pega o resultado
            var resultado = (GenericCommandResult)handle.Handle(command);
            //valida a condição
            Assert.True(resultado.Sucesso, "Usuário é válido");
        }
    }
}
