using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CommentEntity.AppService
{
    public interface ICommentAppService
    {
        public Task<List<CommentSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> ApproveComment(int id, CancellationToken cancellation);
        public Task<Result> RejectComment(int id, CancellationToken cancellation);
        public Task<Result> Add(CommentCreateDto comment , CancellationToken cancellation);
    }
}

