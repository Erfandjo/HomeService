using App.Domain.Core.HomeService.CustomerEntity.Service;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Service;
using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Service;
using System.Threading;

namespace App.Domain.AppServices.HomeService.Request
{
    public class RequestAppService(IRequestService _requestService, IImageService _imageService , ISuggestionService _suggestionService , IServiceCategoryService _serviceCategoryService , ICustomerService _customerService) : IRequestAppService
    {
        public async Task<Result> AcceptSuggestion(int requestId, int suggestionId, CancellationToken cancellation)
        {
            var requestResult = await _requestService.AcceptSuggestion(requestId , cancellation);
            if (requestResult.IsSucces)
            {
               var suggestionResult = await _suggestionService.AcceptSuggestion(suggestionId, cancellation);
                if (suggestionResult.IsSucces)
                {
                    return new Result(true, "با موفقیت انجام شد");
                } else
                {
                    await _requestService.BackStatusWaiting(requestId, cancellation);
                    return suggestionResult;
                }
            } else
            {
                return requestResult;
            }
        }

        public async Task<Result> Add(RequestCreateDto request, CancellationToken cancellation)
        {
            var service = await _serviceCategoryService.GetById(request.ServiceId, cancellation);
            if (request.Price < int.Parse(service.BasePrice))
                return new Result(false, "قیمت نمیتواند کمتر قیمت پایه سرویس باشد");

            var imagesPath = new List<string>();
            request.RequestAt = DateTime.Now;
            request.Status = Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingSuggestion;
            var result = await _requestService.Add(request, cancellation);

            
            if (request.Images is not null && result.IsSucces)
            {
                foreach (var image in request.Images)
                {
                    var imagePath = await _imageService.UploadImage(image, "Request", cancellation);
                    imagesPath.Add(imagePath);
                }
                if(result.IsSucces == true && result.Id is not  null)
                {
                    await _imageService.AddReqImages(imagesPath, (int)result.Id, cancellation);
                }
               
            }

            return result;
        }

        public async Task<Result> FinishSuggestion(int requestId, int suggestionId, CancellationToken cancellation)
        {
            var requestResult = await _requestService.FinishRequest(requestId, cancellation);
            if (requestResult.IsSucces)
            {
                var suggestionResult = await _suggestionService.FinishSuggestion(suggestionId, cancellation);
                if (suggestionResult.IsSucces)
                {
                    return new Result(true, "با موفقیت انجام شد");
                }
                else
                {
                    await _requestService.BackStatusSelection(requestId, cancellation);
                    return suggestionResult;
                }
            }
            else
            {
                return requestResult;
            }
        }

        public async Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _requestService.GetAll(cancellation);
        }

        public async Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _requestService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<List<RequestListCustomerDto>>? GetRequestsCustomer(int customerId, CancellationToken cancellation)
        {
            return await _requestService.GetRequestsCustomer(customerId, cancellation);
        }

        public async Task<Result> PaidSuggestion(int requestId, int suggestionId, int customerId , string price , CancellationToken cancellation)
        {
            var balance = await _customerService.GetBalance(customerId, cancellation);
            if (int.Parse(balance) < int.Parse(price))
                return new Result(false, "موجودی کافی نمیباشد");

            var priceResult = await _customerService.Paid(customerId , price , cancellation);

            var requestResult = await _requestService.PaidRequest(requestId, cancellation);
            if (requestResult.IsSucces)
            {
                var suggestionResult = await _suggestionService.PaidSuggestion(suggestionId, cancellation);
                if (suggestionResult.IsSucces)
                {
                    return new Result(true, "با موفقیت انجام شد");
                }
                else
                {
                    await _requestService.BackStatusFinish(requestId, cancellation);
                    return suggestionResult;
                }
            }
            else
            {
                return requestResult;
            }
        }

       

        public async Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation)
        {
            var req = await _requestService.GetById(request.Id, cancellation);
            if (request.StatusRequest == Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingExpertSelection && req.Suggestions is null)
                return (new Result(false, "هنوز پیشنهادی داده نشده است"));
            if (request.StatusRequest == Core.HomeService.RequestEntity.Enum.StatusRequestEnum.Paid && req.Suggestions is null)
                return (new Result(false, "هنوز پیشنهادی داده نشده است"));
            if (request.StatusRequest == Core.HomeService.RequestEntity.Enum.StatusRequestEnum.Started && req.Suggestions is null)
                return (new Result(false, "هنوز پیشنهادی داده نشده است"));
            if (request.StatusRequest == Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingPayment && req.Suggestions is null)
                return (new Result(false, "هنوز پیشنهادی داده نشده است"));

            
                

             await _requestService.Update(request, cancellation);
            return (new Result(false, "هنوز پیشنهادی داده نشده است"));
        }
    }
}
