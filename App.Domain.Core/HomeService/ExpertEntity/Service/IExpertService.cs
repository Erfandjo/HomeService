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
    }
}
