using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static almoxarifadoTeste.Inventario;

namespace almoxarifadoTeste.Builders
{
    internal class ItensBuilder
    {
        private string _nome = "";
        private int _quantidade = 1;
        private string _descricao = "";
        private string _qualidade = "";
        private DateTime _date = DateTime.Now;

        public static ItensBuilder Novo()
        {
            return new ItensBuilder();
        }

        public Itens Criar()
        {
            return new Itens(_nome, _quantidade, _descricao, _qualidade, _date);
        }

        public ItensBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ItensBuilder ComQuantidade(int quantidade)
        {
            _quantidade = quantidade;  
            return this;
        }

        public ItensBuilder ComDescricao(string descricao) 
        {
            _descricao = descricao;
            return this;
        }

    }
}
