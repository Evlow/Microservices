using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Vols.Datas.Entities
{
    public class Seat
    {
        public string? Name { get; set; }

        public string? Status { get; set; }
    }
}
