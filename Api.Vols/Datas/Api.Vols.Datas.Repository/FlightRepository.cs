using Api.Vols.Datas.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api.Vols.Datas.Repository
{
    public class FlightRepository : IFlightRepository
    {

        private readonly IMongoClient mongoClient;

        public FlightRepository(IMongoClient mongoClient)
        {
            this.mongoClient = mongoClient;
        }

        public async Task<Flight> CreateFlightAsync(Flight flight)
        {
            IMongoDatabase database = mongoClient.GetDatabase("reservation_vol");
            IMongoCollection<Flight> flightCollection = database.GetCollection<Flight>("flights");

            await flightCollection.InsertOneAsync(flight);
            return flight;
        }


        public async Task<bool> DeleteFlightAsync(ObjectId id)
        {
            IMongoDatabase database = mongoClient.GetDatabase("reservation_vol");
            IMongoCollection<Flight> flightCollection = database.GetCollection<Flight>("flights");

            var deleteResult = await flightCollection.DeleteOneAsync(Builders<Flight>.Filter.Eq(x => x.Id, id));
            return deleteResult.DeletedCount > 0;
        }


        public async Task<Flight> GetFlightByIdAsync(ObjectId id)
        {
            IMongoDatabase database = mongoClient.GetDatabase("reservation_vol");
            IMongoCollection<Flight> flightCollection = database.GetCollection<Flight>("flights");

            return await flightCollection.Find(Builders<Flight>.Filter.Eq(x => x.Id, id)).FirstOrDefaultAsync();
        }

        public async Task<List<Flight>> GetFlightsAsync()
        {
            IMongoDatabase database = mongoClient.GetDatabase("reservation_vol");
            IMongoCollection<Flight> flightCollection = database.GetCollection<Flight>("flights");

            return await flightCollection.Find(FilterDefinition<Flight>.Empty).ToListAsync();
        }


        //public async Task<Seat?> GetSeatStatusAsync(string flightNumber, string seatName)
        //{
        //    Flight? flight = await GetFlightByIdAsync(new ObjectId(flightNumber));

        //    if (flight == null)
        //    {
        //        return null;
        //    }

        //    return flight.Sieges.Find(s => s.Name == seatName);
        //}

        public async Task<Flight> UpdateFlightAsync(Flight flight)
        {
            IMongoDatabase database = mongoClient.GetDatabase("reservation_vol");
            IMongoCollection<Flight> flightCollection = database.GetCollection<Flight>("flights");

            await flightCollection.ReplaceOneAsync(Builders<Flight>.Filter.Eq(x => x.Id, flight.Id), flight);
            return flight;
        }
    }
}
