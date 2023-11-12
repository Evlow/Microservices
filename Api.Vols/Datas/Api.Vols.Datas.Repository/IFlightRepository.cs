using Api.Vols.Datas.Entities;
using MongoDB.Bson;

namespace Api.Vols.Datas.Repository
{
    public interface IFlightRepository
    {
        Task<Flight> CreateFlightAsync(Flight flight);

        Task<List<Flight>> GetFlightsAsync();

        Task<Flight> GetFlightByIdAsync(ObjectId id);

        Task<Flight> UpdateFlightAsync(Flight flight);

        //Task<Seat?> GetSeatStatusAsync(string flightNumber, string seatName);

    }
}
