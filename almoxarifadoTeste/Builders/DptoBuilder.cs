using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static almoxarifadoTeste.DptoTeste;

namespace almoxarifadoTeste.Builders
{
    public class DptoBuilder
    {
        private string _nome ="";
        private string _gerente="";
        private string _funcao = "";
        private string _empresaParceira = "";

        public static DptoBuilder Novo()
        {
            return new DptoBuilder();
        }

        public Departamento Criar()
        {
            return new Departamento(_nome,_gerente, _funcao, _empresaParceira);
        }

        public DptoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public DptoBuilder ComGerente(string gerente) 
        {
            _gerente = gerente;
            return this;
        }

        public DptoBuilder ComFuncao(string funcao) 
        {
            _funcao = funcao;
            return this;
        }

        public DptoBuilder ComEmpresa(string empresaParceira) 
        {
            _empresaParceira=empresaParceira;
            return this;
        }

    }
}
