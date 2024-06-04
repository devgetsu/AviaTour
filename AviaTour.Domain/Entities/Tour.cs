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
        public string WhereEx {  get; set; }
        public string Where { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public long Price { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Comment> Comments { get; set; }
    }
}
