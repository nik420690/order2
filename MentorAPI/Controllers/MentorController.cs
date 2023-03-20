using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using static MentorAPI.Controllers.MentorController;

namespace MentorAPI.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    public class MentorController : Controller
    {
        private readonly ILogger<MentorController> _logger;

        public MentorController(ILogger<MentorController> logger)
        {
            _logger = logger;
        }

        //1
        [HttpGet]
        [Route("mentor/get/All")]
        public async Task<string> GetAllAsync()
        {
            //logger
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database_mongo = client_mongo.GetDatabase("ITA_logger");
            var collection_mongo = database_mongo.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "mentor/get/All" };

            await collection_mongo.InsertOneAsync(logger);
            //logger
            HttpClient clientHttp = new HttpClient();

            //koda za delo z podatkovno bazo
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var result = await collection.FindAsync(_ => true);

            List<Mentor> resultList = new List<Mentor>();
            foreach (var item in result.ToList())
            {
                resultList.Add(item);
            }



            return JsonConvert.SerializeObject(resultList);
        }

        //2
        [HttpGet]
        [Route("mentor/get/byID")]
        public async Task<string> GetByIDAsync(string Id)
        {
            //logger
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database_mongo = client_mongo.GetDatabase("ITA_logger");
            var collection_mongo = database_mongo.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "mentor/get/byID" };

            await collection_mongo.InsertOneAsync(logger);
            //logger
            HttpClient clientHttp = new HttpClient();
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var id = new ObjectId(Id);

            var result = await collection.FindAsync(_ => true);

            List<Mentor> resultList = new List<Mentor>();
            foreach (var item in result.ToList())
            {
                resultList.Add(item);
            }

            return JsonConvert.SerializeObject(resultList.Find(item => item._id == id));
        }

        //3
        [HttpGet]
        [Route("mentor/get/latest")]
        public async Task<string> GetLatestAsync()
        {
            //logger
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database_mongo = client_mongo.GetDatabase("ITA_logger");
            var collection_mongo = database_mongo.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "mentor/get/latest" };

            await collection_mongo.InsertOneAsync(logger);
            //logger
            HttpClient clientHttp = new HttpClient();

            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var result = await collection.FindAsync(_ => true);

            List<Mentor> resultList = new List<Mentor>();
            foreach (var item in result.ToList())
            {
                resultList.Add(item);
            }


            return JsonConvert.SerializeObject(resultList.Last());
        }

        //4
        [HttpDelete]
        [Route("mentor/delete/byID")]
        public async Task<string> DeleteByIDAsync(string Id)
        {
            //logger
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database_mongo = client_mongo.GetDatabase("ITA_logger");
            var collection_mongo = database_mongo.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "mentor/delete/byID" };

            await collection_mongo.InsertOneAsync(logger);
            //logger
            HttpClient clientHttp = new HttpClient();

            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var id = new ObjectId(Id);
            var result = await collection.DeleteOneAsync(item => item._id == id);

            return "Uspešno odstranjen!";
        }

        //5
        [HttpDelete]
        [Route("mentor/delete/latest")]
        public async Task<string> DeleteLatestAsync()
        {
            //logger
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database_mongo = client_mongo.GetDatabase("ITA_logger");
            var collection_mongo = database_mongo.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "mentor/delete/latest" };

            await collection_mongo.InsertOneAsync(logger);
            //logger
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var result = await collection.FindAsync(_ => true);

            List<Mentor> resultList = new List<Mentor>();
            foreach (var item in result.ToList())
            {
                resultList.Add(item);
            }

            var id = new ObjectId(resultList.Last()._id.ToString());

            //var id = new ObjectId(Id);
            var result2 = await collection.DeleteOneAsync(x => x._id == id);

            return "Uspešno odstranjen!";
        }

        //6
        [HttpPost]
        [Route("mentor/post/mentor")]
        public async Task<string> PostMentorAsync(Mentor mentor)
        {
            //logger
            var client_mongo = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database_mongo = client_mongo.GetDatabase("ITA_logger");
            var collection_mongo = database_mongo.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "mentor/post/mentor" };

            await collection_mongo.InsertOneAsync(logger);
            //logger
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            await collection.InsertOneAsync(mentor);

            return "Uspešno dodan!";
        }

        //6.2
        [HttpPost]
        [Route("mentor/post/logger")]
        public async Task<string> PostLoggerAsync()
        {
            //logger
            var client = new MongoClient("mongodb+srv://Matematik150:Geografija1@cluster0.biay2zg.mongodb.net/test");
            var database = client.GetDatabase("ITA_logger");
            var collection = database.GetCollection<Logger>("Logger");

            Logger logger = new Logger { Date = DateTime.Now.ToString(), Information = "called logger" };
            
            await collection.InsertOneAsync(logger);
            //logger

            return "Uspešno dodan!";
        }

        //7
        [HttpPut]
        [Route("mentor/put/mentor")]
        public async Task<string> PutMentorAsync(Update update)
        {
            var client = new MongoClient("mongodb+srv://zanki1:pardi007@cluster0.jowor7u.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var resultDelete = await collection.DeleteOneAsync(item => item._id == new ObjectId(update.Id));

            update.Mentor._id = new ObjectId(update.Id);
            await collection.InsertOneAsync(update.Mentor);

            return "Uspešno posodobljen!";
        }

        //8
        [HttpPut]
        [Route("mentor/put/latest")]
        public async Task<string> PutLatestMentorAsync(Mentor mentor)
        {
            HttpClient clientHttp = new HttpClient();
           

            var client = new MongoClient("mongodb+srv://zanki1:pardi007@cluster0.jowor7u.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("ITA");
            var collection = database.GetCollection<Mentor>("Mentor");

            var result = await collection.FindAsync(_ => true);

            List<Mentor> resultList = new List<Mentor>();
            foreach (var item in result.ToList())
            {
                resultList.Add(item);
            }

            var lastMentor = resultList.Last();
            var resultDelete = await collection.DeleteOneAsync(item => item._id == lastMentor._id);
            mentor._id = lastMentor._id;
            
            await collection.InsertOneAsync(mentor);

            return "Uspešno posodobljen!";
        }

        public class Update
        {
            public Mentor Mentor { get; set; }
            public string Id { get; set; }
        }




    }
}
