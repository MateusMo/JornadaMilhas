using JornadaMilhasV1.Modelos;
using NuGet.Frameworks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("",null,"2024-01-01","2024-01-02",0,false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-01-11", "2024-01-12", 100,true)]
        [InlineData(null, "S�o Paulo", "2024-01-11", "2024-01-12", -1,false)]
        [InlineData(null, "Belo Horizonte", "2024-01-11", "2024-01-12", 0, false)]
        [InlineData(null, "Vit�ria", "2024-01-11", "2024-01-12", -500, false)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(
            string origem,
            string destino, 
            DateTime dataIda, 
            DateTime dataVolta, 
            double preco,
            bool validacao)
        {
            //cen�rio - arrange
            Rota rota = new(origem,destino);
            Periodo periodo = new(dataIda,dataVolta);
            
            //a��o - act
            OfertaViagem oferta = new(rota, periodo, preco);
            
            //valida��o - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaEPeriodoInvalidoQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(2));
            double preco = 100.0;

            OfertaViagem oferta = new(rota, periodo, preco);

            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido); 
        }

        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
        {
            //cen�rio - arrange
            Rota rota = new("OrigemTeste", "DestinoTeste");
            Periodo periodo = new(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(2));
            double preco = -100.0;

            //a��o - act
            OfertaViagem oferta = new(rota, periodo, preco);

            //valida��o - assert
            Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }
    }
}