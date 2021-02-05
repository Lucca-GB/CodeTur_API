using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodeTur.Testes.Entidades
{
    public class UsuarioTestes
    {
        [Fact]
        public void DeveRetornarErroSeUsuarioInvalido()
        {
            var usuario = new Usuario("", "lucca@gmail.com", "", EnTipoUsuario.Admin);
            Assert.True(usuario.Invalid, "Usuário é válido");
        }
        [Fact]
        public void DeveRetornarSucessoSeUsuarioValido()
        {
            var usuario = new Usuario("Lucca", "lucca@gmail.com", "1234567", EnTipoUsuario.Admin);
            
            Assert.True(usuario.Valid, "Usuário é inválido");
        }
        [Fact]
        public void DeveRetornarErroSeTelefoneValido()
        {
            var usuario = new Usuario("Lucca", "lucca@gmail.com", "1234567", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("1198575");
            Assert.True(usuario.Invalid, "Número do telefone é válido");
        }
        [Fact]
        public void DeveRetornarSucessoSeTelefoneValido()
        {
            var usuario = new Usuario("Lucca", "lucca@gmail.com", "1234567", EnTipoUsuario.Admin);
            usuario.AdicionarTelefone("11986095972");
            Assert.True(usuario.Valid, "Número do telefone é inválido");
        }
    }
}

