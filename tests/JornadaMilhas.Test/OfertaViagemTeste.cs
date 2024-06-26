using JornadaMilhasV1.Modelos;
using NuGet.Frameworks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTeste
    {
        [Fact]
        public void TestandoOfertaValida()
        {
            //cenário - arrange
            Rota rota = new("OrigemTeste","DestinoTeste");
            Periodo periodo = new(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(2));
            double preco = 100.0;
            var validacao = true;
            
            //ação - act
            OfertaViagem oferta = new(rota, periodo, preco);
            
            //validação - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void TestandoOfertaComRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(2));
            double preco = 100.0;

            OfertaViagem oferta = new(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido); 
        }

        [Fact]
        public void TestandoPrecoNegativo()
        {
            //cenário - arrange
            Rota rota = new("OrigemTeste", "DestinoTeste");
            Periodo periodo = new(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(2));
            double preco = -100.0;

            //ação - act
            OfertaViagem oferta = new(rota, periodo, preco);

            //validação - assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }
    }
}