using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class AboutUsModel : BaseEntity
    {
        public List<Address>? Addresses { get; set; }
        public List<ContactModel>? Contacts { get; set; }
        public List<EmailAddressModel>? Emails { get; set; }
        public required string Description { get; set; }
    }
}
