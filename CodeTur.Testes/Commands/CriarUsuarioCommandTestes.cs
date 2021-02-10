using CodeTur.Dominio.Commands.Usuario;
using Xunit;

namespace CodeTur.Testes.Commands
{
    public class CriarUsuarioCommandTestes
    {
        [Fact]
        public void DeveRetornarErroSeDadosInvalidos()
        {
            var command = new CriarUsuarioCommand();

            Assert.True(command.Invalid, "Usuário é válido");
        } 
    }
}
