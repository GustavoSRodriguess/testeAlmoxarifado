using Microsoft.Win32;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System;
using Xunit.Abstractions;
using ExpectedObjects;
using almoxarifadoTeste._Util;
using System.Runtime.CompilerServices;

namespace almoxarifadoTeste
{
    public class almoxarifadoTeste
    {
        /*  Requisitos
            •	Cadastro de usuário
            •	Cadastro do departamento
            •	Inventário organização do almoxarifado
            •	Controle de entrada
            •	Cadastro de almoxarife 
            •	Lista de compra de produtos 
            •	Lista de distribuição


    -------- 
            Cadastro de usuário
                O almoxarife precisa ter acesso ao cadastro de usuário e departamento para que 
                possa fazer a liberação dos itens solicitados
                Critérios de aceitação:
            •Cadastrar o nome, cpf e matricula do usuário
            •O colaborador precisa apresentar a libração de seus superiores para a liberação dos itens
            •Precisa estar filiado a algum departamento
    --------

            Cadastro de departamento
                O almoxarife precisa ter acesso ao cadastro do departamento na empresa
                Critérios de aceitação:
            •Cadastrar o nome do departamento, o gerente geral e a função
            •O departamento precisa estar associado a empresa para fazer a liberação dos itens
            •O departamento precisa emitir uma declaração solicitando a necessidade dos itens

            Inventário e organização
                O almoxarife precisa ter acesso a lista de produtos e garantir a organização do inventario
                Critérios de aceitação:
            •Cadastrar os itens e sua quantidade
            •Garantir que os itens estejam organizados de forma a garantir o fácil acesso aos mesmos
            •Precisa poder reportar a falta de algum produto

            Controle de entrada
                Deve ser possível ter um controle dos fornecedores, mantendo atualizada a entrada de novos produtos
                Critérios de aceitação:
            •Criar um cadastro dos fornecedores 
            •Manter um registro da qualidade dos produtos
            •Verificar os prazos de entrega dos itens 
            •Ter registrado as condições comerciais oferecidas

            Cadastro do almoxarife
                O almoxarife precisa poder realizar todas as operações dentro do almoxarifado
                Critérios de aceitação:
            •Criar um cadastro de usuário e ser registrado na empresa
            •Ter permissão para realizar qualquer operação no almoxarifado 
            •Precisa ser registrado no almoxarifado

            Lista de compra de produtos
                A lista deve ser criada com os produtos requisitados pelos superiores
                Critérios de aceitação:
            •Precisa atender a todas as necessidades da empresa
            •Precisa ser revisada pelo almoxarife 
            •A lista deve ser emitida de mês em mês

            Lista de distribuição
                A lista servirá para designar quais produtos serão enviados para quais departamentos
                Critérios de aceitação:
            •A lista deve ser autorizada pelos gerentes de departamentos
            •O almoxarife deve revisar as solicitações 
            •A lista precisa se adequar aos itens que existem no almoxarifado

              */

        private string _nomeUsuario;
        private double _cpfUsuario;
        private int _cadastroUsuario;
        private int _codLiberacaoUsuario;
        private int _depUsuario;

        [Fact]
        public void cadastroUsuario()
        {
            //arrange
            var usuario = new
            {
                Nome = "sales",
                Cpf = (double)10113824904,
                Cadastro = (int)11
            };

            //act
            Usuario newUsuario = new Usuario(usuario.Nome, usuario.Cpf, usuario.Cadastro);

            //assert
            usuario.ToExpectedObject().ShouldMatch(newUsuario);
        }

        [Fact]
        public void deleteUsuario()
        {
            
            
            
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void liberacaoUsuario(int liberacao) {

            //arrange
            var libUsuario = new
            {
                Liberacao = 10
            };

            //act e assert

            Assert.Throws<ArgumentException>(
                () =>
                new Usuario(liberacao)
                ).Mensagem("numero de liberacao invalido");
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(-1,-1)]
        public void departamentoUsuario(int cadastro, int departamento)
        {
            //arrange
            var departamentos = new
            {
                Cadastro = cadastro,
                Departamento = departamento
            };

            //act e assert
            Assert.Throws<ArgumentException>(
                () =>
                new Usuario(cadastro, departamento)
                ).Mensagem("departamento ou cadastro invalidos");

        }


        public class Usuario
        {
            private string nome;
            private double cpf;
            private int cadastro;
            private int liberacao;
            private int departamento;

            public Usuario(string nome, double cpf, int cadastro)
            {
                this.Nome = nome;
                this.Cpf = cpf;
                this.Cadastro = cadastro;
            }

            public Usuario(int liberacao)
            {
                this.liberacao = liberacao;

                if(liberacao <= 0)
                {
                    throw new ArgumentException("numero de liberacao invalido");
                }
            }

            public Usuario(int cadastro, int departamento)
            {
                this.departamento = departamento;
                this.cadastro = cadastro;

                if(cadastro <= 0 || departamento <=0)
                {
                    throw new ArgumentException("departamento ou cadastro invalidos");
                }
            }

            public string Nome { get => nome; set => nome = value; }
            public double Cpf { get => cpf; set => cpf = value; }
            public int Cadastro { get => cadastro; set => cadastro = value; }
            public int Liberacao { get => liberacao; set => liberacao = value; }
            public int Departamento { get => departamento; set => departamento = value; }
        }
    }
}