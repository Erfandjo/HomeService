﻿using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.Data;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.HomeService.Expert
{
    public class ExpertService(IExpertRepository _expertRepository) : IExpertService
    {
        public async Task<Result> ChangeScore(int expertId, int Score, CancellationToken cancellation)
        {
            return await _expertRepository.ChangeScore(expertId, Score, cancellation);
        }

        public async Task<ExpertProfileDto> GetByIdForProfile(int id, CancellationToken cancellation)
        {
            return await _expertRepository.GetByIdForProfile(id, cancellation);
        }

        public async Task<ExpertUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _expertRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<List<int>>? GetExpertSkils(int expertId, CancellationToken cancellation)
        {
            return await _expertRepository.GetExpertSkils(expertId, cancellation);
        }

        public async Task<Result> Price(int id, string price, CancellationToken cancellation)
        {
            return await _expertRepository.Price(id, price, cancellation);
        }

        public async Task<Result> Update(ExpertUpdateDto expert, CancellationToken cancellation)
        {
            return await _expertRepository.Update(expert, cancellation);
        }
    }
}
