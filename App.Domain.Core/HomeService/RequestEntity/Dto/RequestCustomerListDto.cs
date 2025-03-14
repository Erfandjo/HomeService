﻿using App.Domain.Core.HomeService.RequestEntity.Enum;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestCustomerListDto
    {

        public int Id { get; set; }
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? ServiceImagePath { get; set; }
        public StatusRequestEnum Status { get; set; }
        public string ServiceName { get; set; }
        public List<SuggestionRequestListDto> Suggestions { get; set; }
    }
}
