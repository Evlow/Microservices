using Api.Vols.Datas.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api.Vols.Business.Service
{
public class MongoDBService
    {
        private readonly IMongoCollection<Flight> _flightCollection ;
        private readonly IMongoCollection<Seat> _seatCollection;
        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _flightCollection = database.GetCollection<Flight>(mongoDBSettings.Value.FlightCollectionName);
            _seatCollection = database.GetCollection<Seat>( mongoDBSettings.Value.SeatCollectionName);
        }

        public async Task<List<Flight>> GetAsync()
        {
            return await _flightCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task CreateAsync(Flight flight)
        {
            await _flightCollection.InsertOneAsync(flight);
            return;
        }

        public async Task UpdateAsync(string id, string flightId)
        {
            FilterDefinition<Flight> filter = Builders<Flight>.Filter.Eq("Id", id);
            UpdateDefinition<Flight > update = Builders<Flight>.Update.AddToSet<string>("flights", flightId);
            await _flightCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Flight> filter = Builders<Flight>.Filter.Eq("Id", id);
            await _flightCollection.DeleteOneAsync(filter);
            return;
        }

        public async Task UpdateSeatInfo(string flightId, string seatName, string status)
        {
            FilterDefinition<Seat> filter = Builders<Seat>.Filter.And(
                Builders<Seat>.Filter.Eq("FlightId", flightId),
                Builders<Seat>.Filter.Eq("Name", seatName)
            );
            UpdateDefinition<Seat> update = Builders<Seat>.Update.Set("Status", status);
            await _seatCollection.UpdateOneAsync(filter, update);
        }

        public async Task<Seat> GetSeatInfo(string flightId, string seatName)
        {
            FilterDefinition<Seat> filter = Builders<Seat>.Filter.And(
                Builders<Seat>.Filter.Eq("FlightId", flightId),
                Builders<Seat>.Filter.Eq("Name", seatName)
            );
            Seat seat = await _seatCollection.Find(filter).FirstOrDefaultAsync();
            return seat;
        }
    }


}
