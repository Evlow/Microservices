using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Vols.Datas.Entities
{
    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string FlightCollectionName { get; set; } = null!;
        public string SeatCollectionName { get; set; } = null!;

    }
}