using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using almoxarifadoTeste.Builders;
using ExpectedObjects;
using Xunit;

namespace almoxarifadoTeste
{
    public class Inventario
    {
        [Fact]
        public void cadastroItem()
        {
            var itemEsperado = new Itens("Batata", 0, "uma batata", "muito boa", DateTime.Now);

            var novoItem = new Itens(
                itemEsperado.Nome,
                itemEsperado.Quantidade,
                itemEsperado.Descricao,
                itemEsperado.Qualidade,
                itemEsperado.Date
            );

            itemEsperado.ToExpectedObject().ShouldMatch(novoItem);
        }

        [Fact]
        public void faltaProduto()
        {
            Itens item = new Itens("Produto", 0, string.Empty, string.Empty, DateTime.Today);
         
            Assert.Equal(0, item.Quantidade);
        }


        public class Itens
        {
            private string _nome;
            private int _quantidade;
            private string _descricao;
            private string _qualidade;
            private DateTime _date;

            public string Nome { get => _nome ; set => _nome = value; }
            public int Quantidade { get => _quantidade; set => _quantidade = value; }
            public string Descricao { get => _descricao; set => _descricao = value; }
            public string Qualidade { get => _qualidade; set => _qualidade = value; }
            public DateTime Date { get => _date; set => _date = value; }

            public Itens(string nome, int quantidade, string descricao, string qualidade, DateTime date)
            {
                this.Nome = nome;
                this.Quantidade = quantidade;
                this.Descricao = descricao;
                this.Qualidade = qualidade;
                this.Date = date;
            }


        }
    }
}
