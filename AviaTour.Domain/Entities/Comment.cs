﻿using AviaTour.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Domain.Entities
{
    public class Comment : AudiTable
    {
        public required string From { get; set; }
        public required string Message { get; set; }
        public long TourId { get; set; }
        public bool isDeleted { get; set; } = false;
        public Tour Tour { get; set; }
    }
}
