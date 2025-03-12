using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.ExpertEntity.Service
{
    public interface IExpertService
    {
        public Task<Result> Price(int id, string price, CancellationToken cancellation);
        public Task<Result> Update(ExpertUpdateDto expert, CancellationToken cancellation);
        public Task<ExpertUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<ExpertProfileDto> GetByIdForProfile(int id, CancellationToken cancellation);
    }
}
