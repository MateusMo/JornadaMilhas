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
    }
}
