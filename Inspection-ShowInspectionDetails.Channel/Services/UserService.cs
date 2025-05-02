using InspectionShowInspectionDetails.Messages;
using InspectionShowInspectionDetails.Messages.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;

namespace InspectionShowInspectionDetails.Channel.Services
{
    public class UserService : MongoConnect
    {

        public UserService(string ConnectionString) : base(ConnectionString)
        {
        }

        public async Task<string> CheckIfUserExists(ShowInspectionDetailsRequest request)
        {
            var database = dbClient.GetDatabase("InspectionAppDatabase");
            var collection = database.GetCollection<BsonDocument>("Users");

            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Eq("email", request.Email)
            );


            try
            {
                var userExists = await collection.Find(filter).AnyAsync();

                Console.WriteLine($"User Exists: {userExists}");

                return userExists ? "User Exists" : "User Not Found";
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Checking For User: {e.Message}");
                return $"Error: {e.Message}";
            }
        }




    }
}