using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMongo.Config
{
    class ConexaoDB : IDisposable
    {

        public IMongoClient MongoClient { get; }
        public IMongoCollection<BsonDocument> MongoCollection { get; }

        public ConexaoDB()
        {
            try
            {
                var host = ConfigurationSettings.AppSettings [ "host" ];
                var databaseName = ConfigurationSettings.AppSettings [ "database" ];
                var collectionName = ConfigurationSettings.AppSettings [ "collection" ];

                MongoClient = new MongoClient( host );
                IMongoDatabase database = MongoClient.GetDatabase( databaseName );
                MongoCollection = database.GetCollection<BsonDocument>( collectionName );
            } catch (Exception e)
            {
                Console.WriteLine( e.Message );
            }

        }

        public void Dispose()
        {
            GC.SuppressFinalize( this );
        }
    }
}
