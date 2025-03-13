using App.Domain.Core.HomeService.CustomerEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Data;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Request
{
    public class RequestRepository(AppDbContext _dbContext) : IRequestRepository
    {
        public async Task<Result> AcceptSuggestion(int requestId, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == requestId , cancellation);

            if (request == null)
                return new Result(false, "درخواست یافت نشد");

            request.Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.Started;

           await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<Result> Add(RequestCreateDto request, CancellationToken cancellation)
        {
            if (request is null)
                return new Result(false, "درخواستی پیدا نشد!");

            

            var req = new App.Domain.Core.HomeService.RequestEntity.Entities.Request();
            req.Description = request.Description;
            req.Price = request.Price;
            req.TimeOfCompletion = request.TimeOfCompletion;
            req.DateOfCompletion = request.DateOfCompletion;
            req.CustomerId =  request.CustomerId;
            req.ServiceId = request.ServiceId;
            req.RequestAt = request.RequestAt;
            req.Status = request.Status;

            await _dbContext.Requests.AddAsync(req);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "با موفقیت ثبت شد" , req.Id);
        }

        public async Task<Result> BackStatusFinish(int requestId, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellation);

            if (request == null)
                return new Result(false, "درخواست یافت نشد");

            request.Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingPayment;

            await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<Result> BackStatusSelection(int requestId, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellation);

            if (request == null)
                return new Result(false, "درخواست یافت نشد");

            request.Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.Started;

            await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<Result> BackStatusWaiting(int requestId, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellation);

            if (request == null)
                return new Result(false, "درخواست یافت نشد");

            request.Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingExpertSelection;

            await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request is null)
                return new Result(false, "Request Not Found.");

            _dbContext.Requests.Remove(request);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> FinishRequest(int requestId, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellation);

            if (request == null)
                return new Result(false, "درخواست یافت نشد");

            request.Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingPayment;

            await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().Select(x => new RequestSummaryDto()
            {
                Id = x.Id,
                DateOfCompletion = x.DateOfCompletion,
                TimeOfCompletion = x.TimeOfCompletion,
                Description = x.Description,
                CustomerId = x.CustomerId,
                Price = x.Price,
                RequestAt = x.RequestAt,
                ServiceName = x.Service.Title,
                Status = x.Status,

            }).ToListAsync();
        }

        public async Task<Domain.Core.HomeService.RequestEntity.Entities.Request>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().Select(x => new RequestUpdateDto()
            {
                Id = x.Id,
                StatusRequest = x.Status,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<RequestCustomerListDto>>? GetRequestsCustomer(int customerId, CancellationToken cancellation)
        {
            var suggestions = new List<SuggestionRequestListDto>();
            return await _dbContext.Requests.AsNoTracking().Where(x => x.CustomerId == customerId).Select(x => new RequestCustomerListDto()
            {
                Id = x.Id,
                ServiceImagePath = x.Service.ImagePath,
                ServiceName = x.Service.Title, 
                Status = x.Status,
                DateOfCompletion = x.DateOfCompletion,
                TimeOfCompletion = x.TimeOfCompletion,


                Suggestions = (List<SuggestionRequestListDto>) x.Suggestions.Select(x => new SuggestionRequestListDto()
                {
                    Id = x.Id,
                    SuggestedPrice = x.SuggestedPrice,
                    DeliveryDate = x.DeliveryDate,
                    Description = x.Description,
                    SuggestionAt = x.SuggestionAt,
                    ExpertName = x.Expert.User.FirstName + " " + x.Expert.User.LastName,
                    ExpertId = x.ExpertId,
                    Status = x.Status,
                }),
                
            }).ToListAsync(cancellation);
        }

        public async Task<List<RequestExpertListDto>>? GetRequestsExpert(List<int> expetSkils, CancellationToken cancellation)
        {
            var suggestions = new List<SuggestionRequestListDto>();
            return await _dbContext.Requests.AsNoTracking().Where(x => expetSkils.Contains(x.ServiceId)).Select(x => new RequestExpertListDto()
            {
                Id = x.Id,
                ServiceImagePath = x.Service.ImagePath,
                ServiceName = x.Service.Title,
                Status = x.Status,
                DateOfCompletion = x.DateOfCompletion,
                TimeOfCompletion = x.TimeOfCompletion,


            }).ToListAsync(cancellation);
        }

        public async Task<Result> PaidRequest(int requestId, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == requestId, cancellation);

            if (request == null)
                return new Result(false, "درخواست یافت نشد");

            request.Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.Paid;

            await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت انجام شد");
        }

        public async Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation)
        {
            var req = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (req is null)
                return new Result(false, "درخواست یافت نشد");


            req.Status = request.StatusRequest;
            
            

            await _dbContext.SaveChangesAsync();

            return new Result(true, "درخواست با موفقیت بروزرسانی شد");
        } 
    }
}
