using InspectionShowInspectionDetails.Messages;
using InspectionShowInspectionDetails.Messages.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InspectionShowInspectionDetails.Channel.Services
{
    public class InspectionDetailsService : MongoConnect
    {

        public InspectionDetailsService(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<List<BsonDocument>> GetAllModels()
        {
            try
            {
                var database = dbClient.GetDatabase("InspectionAppDatabase");
                var collection = database.GetCollection<BsonDocument>("InspectionDetails");

                var allDetails = await collection.Find(Builders<BsonDocument>.Filter.Empty).ToListAsync();

                return allDetails;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Retrieving All Models: {e.Message}");
                return new List<BsonDocument>();
            }
        }




    }
}