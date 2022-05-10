using MongoDB.Driver;
using SignalRChat.Data.Configurations;
using SignalRChat.Models;

namespace SignalRChat.Data.Repositories
{
    public class UserMessageRepository : IUserMessageRepository
    {
        private readonly IMongoCollection<UserMessage> _usersMessage;

        public UserMessageRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _usersMessage = database.GetCollection<UserMessage>("UserMessage");
        }

        public void Create(UserMessage entity)
        {
            _usersMessage.InsertOne(entity);
        }

        public UserMessage Get(Guid id)
        {
            return _usersMessage.Find(u => u.Id == id).FirstOrDefault();
        }

        public IEnumerable<UserMessage> GetAll()
        {
            return _usersMessage.Find(u => true).ToList();
        }

        public void Update(Guid id, UserMessage entity)
        {
            _usersMessage.ReplaceOne(u => u.Id == id, entity);
        }
    }
}