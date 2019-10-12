using AgendaMongo.Config;
using AgendaMongo.Interface;
using AgendaMongo.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.DAO
{
    public class AgendaDAO : IAgendaDAO
    {
        public void Atualizar( Agenda agenda )
        {
            try
            {
                using (var conexaoDB = new ConexaoDB())
                {
                    if (agenda != null)
                    {
                        var query = new BsonDocument( "_id", agenda.Id );

                        var agedaParaAtualizar = new BsonDocument();
                        if (!string.IsNullOrEmpty( agenda.Nome ))
                        {
                            agedaParaAtualizar.Add( "nome", agenda.Nome );
                        }
                        if (!string.IsNullOrEmpty( agenda.Sobrenome ))
                        {
                            agedaParaAtualizar.Add( "sobrenome", agenda.Sobrenome );
                        }
                        //if (agenda.Contatos != null && agenda.Contatos.Count > 0)
                        //{
                        //    agedaParaAtualizar.Add( "contatos", agenda.TransformaContatosDocumentos() );
                        //}

                        var update = new BsonDocument();
                        update.Add( "$set", agedaParaAtualizar );

                        conexaoDB.MongoCollection.UpdateOne( query, update );

                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

        public Agenda BuscaAgenda( string codigo )
        {
            Agenda agenda = null;

            try
            {
                using (var conexaoDB = new ConexaoDB())
                {
                    var filter = new BsonDocument( "codigo", codigo );
                    var result = conexaoDB.MongoCollection.Find( filter ).ToList();

                    if (result != null && result.Count > 0)
                    {
                        agenda = new Agenda();
                        agenda.Id = (ObjectId)result [ 0 ].GetValue( "_id" );
                        agenda.Codigo = result [ 0 ].GetValue( "codigo" ).ToString();
                        agenda.Nome = result [ 0 ].GetValue( "nome" ).ToString();
                        agenda.Sobrenome = result [ 0 ].GetValue( "sobrenome" ).ToString();
                        agenda.TransformaDocumentosContatos( (BsonArray)result [ 0 ].GetValue( "contatos" ) );
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }

            return agenda;
        }

        public List<Agenda> BuscaAgendas()
        {
            List<Agenda> agendas = new List<Agenda>();

            try
            {
                using (var conexaoDB = new ConexaoDB())
                {
                    var filter = new BsonDocument();
                    var result = conexaoDB.MongoCollection.Find( filter ).ToList();

                    if (result != null && result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            var agenda = new Agenda();
                            agenda.Id = (ObjectId)item [ "_id" ];
                            agenda.Codigo = item [ "codigo" ].ToString();
                            agenda.Nome = item [ "nome" ].ToString();
                            agenda.Sobrenome = item [ "sobrenome" ].ToString();
                            agenda.TransformaDocumentosContatos( (BsonArray)item [ "contatos" ] );

                            agendas.Add( agenda );
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }

            return agendas;
        }

        public void Deletar( ObjectId id )
        {
            try
            {
                using (var conexaoDB = new ConexaoDB())
                {
                    if (id != null)
                    {
                        var query = new BsonDocument( "_id", id );
                        conexaoDB.MongoCollection.DeleteOne( query );
                    }
                }

            } catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }

        public void Salvar( Agenda agenda )
        {
            try
            {
                using (var conexaoDB = new ConexaoDB())
                {
                    var document = new BsonDocument();
                    document.Add( "codigo", agenda.Codigo );
                    document.Add( "nome", agenda.Nome );
                    document.Add( "sobrenome", agenda.Sobrenome );
                    if (agenda.Contatos != null && agenda.Contatos.Count > 0)
                    {
                        document.Add( "contatos", agenda.TransformaContatosDocumentos() );
                    }

                    conexaoDB.MongoCollection.InsertOne( document );
                }
            } catch (Exception ex)
            {
                Console.WriteLine( ex.Message );
            }
        }
    }
}
