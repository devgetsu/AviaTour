using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class Tour : AudiTable
    {
        public required string WhereEx {  get; set; }
        public required string Where { get; set; }
        public required string Subtitle { get; set; }
        public required string Description { get; set; }
        public required string PicturePath { get; set; }
        public long Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Comment> Comments { get; set; }
    }
}
