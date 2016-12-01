using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Bisnode.Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient mongoClient = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
           // var a = mongoClient.ListDatabases();
            var db = mongoClient.GetDatabase("HKO_Log");
            var collec = db.GetCollection<BsonDocument>("Exceptions");
            var document = new BsonDocument
            {
                {"Username","Dell"},
                {"Function","400"},
                {"Status","8GB"},
                {"IP","1TB"},
                {"MachineIpShort","16inch"},
                {"query","16inch"},
                {"Exception","16inch"},
                {"ExceptionType","16inch"},
                {"Browser","16inch"},
                {"DateCreated","16inch"}
            };

            collec.InsertOneAsync(document);

            var getted = collec.AsQueryable().FirstOrDefault();
           
          
        }
    }
}

//The MongoDB Driver does provide a method for deserializing from Bson to your type.The BsonSerializer can be found in MongoDB.Bson.dll, in the MongoDB.Bson.Serialization namespace.
//You can use the BsonSerializer.Deserialize<T>() method.Some example code would be

//var obj = new MyClass { MyVersion = new Version(1,0,0,0) };
//var bsonObject = obj.ToBsonDocument();
//var myObj = BsonSerializer.Deserialize<MyClass>(bsonObject);
//Console.WriteLine(myObj);
//Where MyClass is defined as

//public class MyClass
//{
//    public Version MyVersion { get; set; }
//}
