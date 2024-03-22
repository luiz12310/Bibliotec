using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloParametro
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public clsModeloParametro()
        {

        }

        public clsModeloParametro(string nome, string valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
