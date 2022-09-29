using Eleicao;
using Xunit;

namespace TesteEleicao
{
    public class TesteCandidato
    {
        [Fact]
        public void ValidarQuantidadeVotosCorreta()
        {
            //Arrange
            var candidato = new Candidato("Eduardo")
            {
                Votos = 5
            };

            //Act
            var resultadoEspetado = candidato.Votos + 1;

            candidato.AdicionarVoto();

            //Asset

            Assert.Equal(resultadoEspetado, candidato.Votos);

        }

        [Theory]
        [InlineData("Eduardo")]
        public void ValidaNomeCandidatoAposCadastro(string nome)
        {
            //Arrange

            var candidato = new Candidato("Eduardo");

            //Act 
            var resultadoEspetado = nome;

            //Assert
            Assert.Equal(resultadoEspetado, candidato.Nome);
        }
    }
}