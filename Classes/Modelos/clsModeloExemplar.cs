using Gerenciador_biblioteca.Classes.Logica;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerenciador_biblioteca.Classes.Modelos
{
    public class clsModeloExemplar : ConexaoBanco
    {
        public int Codigo { get; set; }
        public clsModeloLivro Livro { get; set; }

        public clsModeloExemplar(int codigoExemplar, int codigoLivro)
        {
            Codigo = codigoExemplar;
            Livro = new clsModeloLivro(codigoLivro);
        }
    }
}
