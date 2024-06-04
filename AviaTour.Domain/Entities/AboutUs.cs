using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class AboutUs : BaseEntity
    {
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
