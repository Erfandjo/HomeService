using App.Domain.Core.HomeService.ExpertEntity.Data;
using App.Domain.Core.HomeService.ExpertEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.HomeService.Expert
{
    public class ExpertService(IExpertRepository _expertRepository) : IExpertService
    {
        public async Task<Result> Price(int id, string price, CancellationToken cancellation)
        {
            return await _expertRepository.Price(id, price, cancellation);
        }
    }
}
