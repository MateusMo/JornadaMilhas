using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test
{
    public class OfertaViagemDesconto
    {
        [Fact]
        public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
        {
            Rota rota = new Rota("OrigemA","DestinoB");
            Periodo periodo = new(DateTime.Now, DateTime.Now.AddDays(5));
            double precoOriginal = 100.00;
            double desconto = 20.00;
            double precoComDesconto = precoOriginal - desconto;
            OfertaViagem oferta = new(rota, periodo, precoOriginal);

            oferta.Desconto = desconto;
            Assert.Equal(precoComDesconto, oferta.Preco);
        }

        [Fact]
        public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
        {
            Rota rota = new Rota("OrigemA", "DestinoB");
            Periodo periodo = new(DateTime.Now, DateTime.Now.AddDays(5));
            double precoOriginal = 100.00;
            double desconto = 120.00;
            double precoComDesconto = 30.00;
            OfertaViagem oferta = new(rota, periodo, precoOriginal);

            oferta.Desconto = desconto;
            Assert.Equal(precoComDesconto, oferta.Preco,0.001);
        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPrecoSaoInvalidos()
        {
            //arrange
            Rota rota = null;
            Periodo periodo = new(new DateTime(2024,6,1),new DateTime(2024,5,10));
            double preco = -100;
            int quantidadeEsperada = 3;
            //act
            OfertaViagem oferta = new(rota, periodo, preco);
            //asset
            Assert.Equal(quantidadeEsperada, oferta.Erros.Count());
        }
    }
}
