using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.Model
{
    class Agenda
    {
        public ObjectId Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<Contato> Contatos { get; set; }
    }
}
