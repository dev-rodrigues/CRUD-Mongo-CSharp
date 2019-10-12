using AgendaMongo.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.Interface
{
    interface IAgendaDAO
    {
        void Salvar( Agenda agenda );
        void Atualizar( Agenda agenda );
        void Deletar( ObjectId id );
        List<Agenda> BuscaAgendas();
        Agenda BuscaAgenda( String codigo );
    }
}
