using AgendaMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo
{
    class Program
    {
        static void Main( string [] args )
        {

            Console.WriteLine( "testando" );

            Contato c = new Contato();
            c.Email = "c@gmail.com";
            c.Telefone = "21212222";
            c.Tipo = 1;

            Agenda a = new Agenda();
            a.Codigo = 1;
            a.Nome = "testando";
            a.Sobrenome = "tt";
            a.Contatos.Add( c );
            Console.ReadKey();
        }
    }
}
