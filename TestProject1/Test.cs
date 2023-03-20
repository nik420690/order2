using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MentorAPI;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Core.Clusters;
using SharpCompress.Common;

namespace TestProject1
{
    public class Test
    {
        [Fact]
        public void TestMongo()
        {
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");

            try
            {
                client.ListDatabaseNames();
                Assert.True(true);
            }
            catch (Exception)
            {
                Assert.True(false);

            }

        }
        [Fact]
        public void TestDatabase()
        {
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");

            var collectionExists = client.ListDatabaseNames().ToList().Contains("ITA");
            if (collectionExists)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }

        }
        [Fact]
        public void TestCollectionExist()
        {
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var db = client_mongo.GetDatabase("ITA");
            var collection=db.GetCollection<Mentor>("Mentor");

            if (collection != null)
            {
                Assert.True(true);

            }
            else
            {
                Assert.True(false);

            }

        }
    }
}
