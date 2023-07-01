using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using almoxarifadoTeste.Builders;

namespace almoxarifadoTeste
{
    public class DptoTeste
    {

        [Fact]
        public void cadastrarDpto()
        {
            var dptoEsperado = new
            {
                Nome = "Tree",
                Gerente = "Pedra",
                Funcao = "Dar o cu",
                EmpresaParceira = "Celta"
            };

            Departamento novoDpto = new Departamento(
                dptoEsperado.Nome,
                dptoEsperado.Gerente,
                dptoEsperado.Funcao,
                dptoEsperado.EmpresaParceira
                );

            novoDpto.ToExpectedObject().ShouldMatch(dptoEsperado);

        }

        [Theory]
        [InlineData("", "", "", "")]
        [InlineData(null, null, null, null)]
        public void nomeDptoVazio(string nome, string gerente, string funcao, string empresaParceira)
        {
            Assert.Throws<ArgumentException>(() =>

                DptoBuilder.Novo().ComNome(nome).ComGerente(gerente).ComFuncao(funcao).ComEmpresa(empresaParceira).Criar()
            );
        }

        [Fact]
        public void EmitirDeclaracaoSolicitacao()
        {
            string nome = "Departamento A";
            string gerente = "João Silva";
            string funcao = "Gestor de Compras";
            string empresaParceira = "Empresa XYZ";

            Departamento departamento = new Departamento(nome, gerente, funcao, empresaParceira);

            string declaracaoEsperada = "Declaração de Solicitação de Itens:\n" +
                                        $"Departamento: {nome}\n" +
                                        $"Gerente: {gerente}\n" +
                                        $"Função: {funcao}\n" +
                                        $"Empresa Parceira: {empresaParceira}\n" +
                                        "Itens Necessários:\n" +
                                        "- Item 1\n" +
                                        "- Item 2\n" +
                                        "- Item 3";

            string declaracaoGerada = departamento.EmitirDeclaracaoSolicitacao();         
            Assert.Equal(declaracaoEsperada, declaracaoGerada);
        }





        public class Departamento
        {
            private string nome;
            private string gerente;
            private string funcao;
            private string empresaParceira;

            public string Nome { get => nome; set => nome = value; }
            public string Gerente { get => gerente; set => gerente = value; }
            public string Funcao { get => funcao; set => funcao = value; }
            public string EmpresaParceira { get => empresaParceira; set => empresaParceira = value; }
            public Departamento(string nome, string gerente, string funcao, string empresaParceira)
            {
                if (String.IsNullOrEmpty(nome)) throw new ArgumentException();
                if (String.IsNullOrEmpty(gerente)) throw new ArgumentException();
                if (String.IsNullOrEmpty(funcao)) throw new ArgumentException();
                if (String.IsNullOrEmpty(empresaParceira)) throw new ArgumentException();

                this.Nome = nome;
                this.Gerente = gerente;
                this.Funcao = funcao;
                this.EmpresaParceira = empresaParceira;
            }

            public string EmitirDeclaracaoSolicitacao()
            {
             
                string declaracao = "Declaração de Solicitação de Itens:\n" +
                                    $"Departamento: {Nome}\n" +
                                    $"Gerente: {Gerente}\n" +
                                    $"Função: {Funcao}\n" +
                                    $"Empresa Parceira: {EmpresaParceira}\n" +
                                    "Itens Necessários:\n" +
                                    "- Item 1\n" +
                                    "- Item 2\n" +
                                    "- Item 3";

                return declaracao;
            }

        }
    }
}
