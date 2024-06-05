using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class EmailAddressModel : BaseEntity
    {
        public string EmailAddress { get; set; }
    }
}
