using CodeTur.Comum.Enum;
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

            command.Validar();

            Assert.False(command.Valid, "Usuário é válido");
        }
        [Fact]
        public void DeveRetornarErroSeDadosValidos()
        {
            var command = new CriarUsuarioCommand("Lucca",
                                                  "email@email.com",
                                                  "1234567",
                                                  "",
                                                  EnTipoUsuario.Comum);

            command.Validar();

            //Se o meu objeto command passar pelas validacoes
            //Invalid = false
            //Se nao Invalid = false

            //Se o meu objeto command passar pelas validacoes
            //Valid = true
            //Se nao = false



            Assert.True(command.Valid, "Usuário é inválido");
        }
    }
}
