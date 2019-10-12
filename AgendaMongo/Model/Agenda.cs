using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.Model
{
    public class Agenda
    {
        public ObjectId Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public List<Contato> Contatos { get; set; }

        public BsonArray TransformaContatosDocumentos()
        {
            var documentos = new BsonArray();
            foreach (var contato in Contatos)
            {
                var document = new BsonDocument();
                document.Add( "email", contato.Email );
                document.Add( "telefone", contato.Telefone );
                document.Add( "tipo", contato.Tipo );
                documentos.Add( document );
            }
            return documentos;
        }

        public void TransformaDocumentosContatos( BsonArray documentos )
        {
            if (Contatos == null)
            {
                Contatos = new List<Contato>();
            }
            if (documentos != null && documentos.Count > 0)
            {
                foreach (var documento in documentos)
                {
                    Contato contato = new Contato();
                    contato.Email = documento [ "email" ].ToString();
                    contato.Telefone = documento [ "telefone" ].ToString();
                    contato.Tipo = Convert.ToInt32( documento [ "tipo" ] );
                    Contatos.Add( contato );
                }
            }
        }
    }
}