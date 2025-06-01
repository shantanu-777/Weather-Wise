using WeatherWise.server.Configurations;
using WeatherWise.server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WeatherWise.server.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        }

        public IMongoCollection<UserSearchHistory> UserSearchHistories =>
            _database.GetCollection<UserSearchHistory>("UserSearchHistory");

        public IMongoCollection<FavoriteCity> FavoriteCities =>
            _database.GetCollection<FavoriteCity>("FavoriteCities");
    }
}