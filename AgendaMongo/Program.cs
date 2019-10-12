using AgendaMongo.Config;
using AgendaMongo.DAO;
using AgendaMongo.Interface;
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
        private static IAgendaDAO dao = ServiceLab.GetInstanceOf<AgendaDAO>();

        static void Main( string [] args )
        {

            Console.WriteLine( "testando" );

            Contato c = new Contato( "c@gmail.com", "21212222", 1 );

            Agenda a = new Agenda();
            a.Codigo = "codificado";
            a.Nome = "testando";
            a.Sobrenome = "tt";
            a.Contatos = new List<Contato>();
            a.Contatos.Add( c );

            dao.Salvar( a );
            Console.ReadKey();
        }
    }
}
