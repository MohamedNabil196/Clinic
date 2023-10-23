using BackEnd.DTOModels;
using BackEnd.IRepo;
using BackEnd.IService;
using BackEnd.Models;
using BackEnd.Mongo.IMongo;
using MongoDB.Bson;
using MongoDB.Driver;
using NuGet.Configuration;
using NuGet.Packaging.Signing;

namespace BackEnd.Services
{
    public class RecordService : IRecordService
    {
        public IRepository<Record> _recordClassRepo;
        private readonly IMongoCollection<Record> _recordRepoMongo;

        public RecordService(IRepository<Record> firstClassRepo,IStudentStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            _recordClassRepo = firstClassRepo;
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _recordRepoMongo = database.GetCollection<Record>(settings.StudentCoursesCollectionName);

        }

        //GetAll from Mongo
        public  async Task< IEnumerable<Record>> GetAll()
        {
            //   return _recordClassRepo.GetAll();
            try
            {
                var x = await _recordRepoMongo.Find(new BsonDocument()).ToListAsync();
                return x;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


        public async Task <object> Add(RecordDTO Model)
        {
            try
            {
                Record NewItem = new Record();
                NewItem.Id = AsObjectId() ;
                NewItem.Name = Model.name;
                NewItem.Diagnosis= Model.diagnosis;
                NewItem.TreatmentPlan=Model.treatmentPlan;
                NewItem.Date= Model.date;
               _recordClassRepo.Insert(NewItem);
                _recordClassRepo.Save();

                //FilterDefinition<Record> filter = Builders<Record>.Filter.Eq("Id", NewItem.Id);
                //UpdateDefinition<Record> update = Builders<Record>.Update.AddToSet<string>("name",Model.name);
                await _recordRepoMongo.InsertOneAsync(NewItem);
                return NewItem;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public static string AsObjectId()
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray().Take(12).ToArray();

            // Convert bytes to a hexadecimal string
            string hexString = BitConverter.ToString(bytes).Replace("-", "").ToLower();

            return hexString;
        }
    }
}
