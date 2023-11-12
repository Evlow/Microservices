using Api.Vols.Business.Service;
using Api.Vols.Datas.Entities;
using Api.Vols.Datas.Repository;
using LiteDB;
using Microsoft.AspNetCore.Mvc;

namespace Api.Vols.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly MongoDBService _mongoDBService;

        public FlightsController(MongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        private readonly IFlightRepository _flightRepository;

        public FlightsController(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        [HttpGet]
        public async Task<List<Flight>> Get()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Flight flight)
        {
            await _mongoDBService.CreateAsync(flight);
            return CreatedAtAction(nameof(Get), new { id = flight.Id }, flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpddateAsync(string id, [FromBody] string flightid)
        {
            await _mongoDBService.UpdateAsync(id, flightid);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }















        //// GET: api/Flights
        //[HttpGet]
        //[ProducesResponseType(typeof(List<Flight>), 200)]
        //public IActionResult GetFlights()
        //{
        //    return Ok(_flightRepository.GetFlights());
        //}

        //// get api/flights/5
        //[httpget("{id}")]
        //[producesresponsetype(typeof(flight), 200)]
        //public iactionresult getflightbyid(string id)
        //{
        //    var flight = _flightrepository.getflightbyid(new objectid(id));

        //    if (flight == null)
        //    {
        //        return notfound();
        //    }

        //    return ok(flight);
        //}

        //// post api/flights
        //[httppost]
        //[producesresponsetype(typeof(flight), 200)]
        //public iactionresult createflight([frombody] flight flight)
        //{
        //    return ok(_flightrepository.createflight(flight));
        //}

        //// put api/flights
        //[httpput("{id}")]
        //[producesresponsetype(typeof(flight), 200)]
        //public iactionresult updateflight(string id, [frombody] flight flight)
        //{
        //    var checkflight = _flightrepository.getflightbyid(new objectid(id));

        //    if (checkflight == null)
        //    {
        //        return notfound();
        //    }

        //    return ok(_flightrepository.updateflight(flight));
        //}

        //// delete api/flights/5
        //[httpdelete("{id}")]
        //[producesresponsetype(typeof(bool), 200)]
        //public iactionresult deleteflight(string id)
        //{
        //    var checkflight = _flightrepository.getflightbyid(new objectid(id));

        //    if (checkflight == null)
        //    {
        //        return notfound();
        //    }

        //    var success = _flightrepository.deleteflight(new objectid(id));
        //    return ok(success);
        //}


        //[httpget("{numerovol}/siege/{nomsiege}")]
        //[producesresponsetype(typeof(seat), 200)]
        //public iactionresult getseatstatus(string numerovol, string nomsiege)
        //{
        //    var seat = _flightrepository.getseatstatus(numerovol, nomsiege);

        //    if (seat == null)
        //    {
        //        return notfound();
        //    }

        //    return ok(seat);
        //}
    }
}
