using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CommentEntity.Data
{
    public interface ICommentRepository
    {
        public Task<Result> Add(CommentCreateDto comment , CancellationToken cancellation);
        public Task<Result> Update(int id, Entities.Comment comment, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<CommentSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Entities.Comment>? GetById(int id, CancellationToken cancellation);
        public Task<Result> ApproveComment(int id, CancellationToken cancellation);
        public Task<Result> RejectComment(int id, CancellationToken cancellation);
        public Task<bool> CheckComment(int requestId ,  CancellationToken cancellation);
    }
}
