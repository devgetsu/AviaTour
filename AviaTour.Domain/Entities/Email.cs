using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class Email : BaseEntity
    {
        public string EmailAddress { get; set; }
    }
}
