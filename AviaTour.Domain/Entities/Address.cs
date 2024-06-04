using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Door { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public long ZipCode { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }
}
