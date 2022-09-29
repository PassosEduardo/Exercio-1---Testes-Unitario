using Eleicao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

////Para a classe Urna, utilize o código dos métodos já prontos e construa os seguintes cenários de teste:

//-Validar se o construtor está inserindo os dados iniciais corretamente
//- Validar se a eleição está sendo iniciada/encerrada corretamente
//- Validar se, ao cadastrar um candidato, o última candidato na lista é o mesmo que foi cadastrado
//- Validar o método de votação quando é informado um candidato não cadastrado
//- Validar o método de votação quando é informado um candidato cadastrado
//- Validar o resultado da eleição

namespace TesteEleicao
{
    public class TesteUrna
    {
       [Theory]
       [InlineData("",0,false)]
       public void ValidaSaidaValoresDoConstrutor(string VencedorEleicao, int Votos, bool eleicaoAtiva)
       {
            //Arrange
            var urna = new Urna();

            //Act
            var resultadoEsperadoVencedorEleicao = "";
            var resultadoEsperadoVotosVencedor = 0;
            var resultadoEsperadoCandidatos = new List<Candidato>();
            var resultadoEsperadoEleicaoAtiva = false;

            //Assert

            Assert.Equal(resultadoEsperadoVencedorEleicao, VencedorEleicao);
            Assert.Equal(resultadoEsperadoVotosVencedor, Votos);
            Assert.Equal(resultadoEsperadoCandidatos, urna.Candidatos); ;
            Assert.Equal(resultadoEsperadoEleicaoAtiva, eleicaoAtiva);

        }
        [Fact]
        public void ValidarInicioEleicao()
        {
            //Arrange
            var urna = new Urna();

            //Act
            var valorInicial = urna.EleicaoAtiva;

            urna.IniciarEncerrarEleicao();

            //Assert
            Assert.False(valorInicial == urna.EleicaoAtiva);
        }

        [Fact]
        public void TestaCadastroDeCandidatos()
        {
            //Arrange
            var urna = new Urna();

            urna.CadastrarCandidato("Nome1");

            urna.CadastrarCandidato("Antonio");

            //Act
            var resultadoEsperado = urna.Candidatos.Where(x => x.Nome == "Antonio").FirstOrDefault();

            var resultadoObtido = urna.Candidatos.Last();

            //Assert
            Assert.Equal(resultadoEsperado, resultadoObtido);
            


        }

        [Fact]
        public void ValidaMetodoVotacaoUsuarioNaoCadastrado()
        {
            var urna = new Urna();

            Assert.False(urna.Votar("Fulano"));
        }
        [Fact]
        public void ValidarMetodoVotocaoUsuarioCadastrado()
        {
            var urna = new Urna();
            urna.CadastrarCandidato("Eduardo");

            Assert.True(urna.Votar("Eduardo"));

        }
        [Fact]
        public void ValidarResultadoEleicoes()
        {
            //Arrange
            var urna = new Urna();

            var candidatoVencedor = new Candidato("Joao")
            {
                Votos = 70
            };

            var candidatoPerdedor = new Candidato("Jose")
            {
                Votos = 69
            };
            
            //Act
            urna.Candidatos.Add(candidatoPerdedor);
            urna.Candidatos.Add(candidatoVencedor);


            //Assert
            var resultadoObtido = urna.MostrarResultadoEleicao();

            var resultadoEsperado = $"Nome vencedor: {candidatoVencedor.Nome}. Votos: {candidatoVencedor.Votos}";

            Assert.Equal(resultadoObtido, resultadoEsperado);

        }


    }
}
