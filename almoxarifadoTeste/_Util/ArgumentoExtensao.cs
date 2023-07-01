using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace almoxarifadoTeste._Util
{
    public static class ArgumentoExtensao
    {
        public static void Mensagem(this ArgumentException execao, string mensagem)
        {
            if(execao.Message == mensagem)
            {
                Assert.True(true);
            }
            else
            {
                Assert.False(true);
            }
        }
    }
}
