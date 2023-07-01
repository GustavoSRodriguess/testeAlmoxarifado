using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static almoxarifadoTeste.Inventario;

namespace almoxarifadoTeste
{
    public class entradaTeste
    {

        [Fact]
        public void CadastroFornecedor()
        {
            var fornecedorEsperado = new
            {
                Nome = "Jonas alimentos",
                Endereco = "rua sei la",
                Cnpj = 1324596,
            };

            Fornecedor novoFornecedor = new Fornecedor(
                fornecedorEsperado.Nome,
                fornecedorEsperado.Endereco,
                fornecedorEsperado.Cnpj
            );

            fornecedorEsperado.ToExpectedObject().ShouldMatch( novoFornecedor );
        }

        [Fact]
        public void VerificarPrazoEntrega()
        {
            Itens item = new Itens("nome sla", 0, string.Empty, string.Empty, DateTime.Today.AddDays(2));
            DateTime dataAtual = DateTime.Today;
            bool sla = item.Date >= dataAtual;

            Assert.True(sla);
        }


        public class Fornecedor
        {
            private string _nome = "";
            private string _endereco = "";
            private int cnpj = 0;

            public string Nome { get => _nome; set => _nome = value; }
            public string Endereco { get => _endereco; set => _endereco = value; }
            public int Cnpj { get => cnpj; set => cnpj = value; }

            public Fornecedor(string nome, string endereco, int cnpj)
            {
                this.Nome = nome;
                this.Endereco = endereco;
                this.Cnpj = cnpj;
                
            }
        }

    }
}
