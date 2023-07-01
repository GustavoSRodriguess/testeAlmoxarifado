using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almoxarifadoTeste
{
    public class ListaCompraTest
    {
        [Fact]
        public void CriarListaCompra()
        {
            // Produtos requisitados pelos superiores
            var produtosRequisitados = new List<string>
            {
                "Produto A",
                "Produto B",
                "Produto C"
            };

            ListaCompra listaCompra = new ListaCompra(produtosRequisitados);

            Assert.Equal(produtosRequisitados, listaCompra.Produtos);

            Assert.True(listaCompra.Revisada);

            Assert.Equal(DateTime.Now.Month, listaCompra.DataEmissao.Month);
        }
    }

    public class ListaCompra
    {
        public List<string> Produtos { get; }
        public bool Revisada { get; }
        public DateTime DataEmissao { get; }

        public ListaCompra(List<string> produtos)
        {
            Produtos = produtos;
            Revisada = true; 
            DataEmissao = DateTime.Now; 
        }
    }
}
