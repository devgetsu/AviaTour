﻿using AviaTour.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviaTour.Application.UseCases.Emails.Commands
{
    public class UpdateEmailCommand: IRequest<ResponseModel> 
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
    }
}
