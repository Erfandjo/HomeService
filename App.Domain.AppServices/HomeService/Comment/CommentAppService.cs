using App.Domain.Core.HomeService.CommentEntity.AppService;
using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.CommentEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.AppServices.HomeService.Comment
{
    public class CommentAppService(ICommentService _commentService) : ICommentAppService
    {
        public async Task<Result> ApproveComment(int id, CancellationToken cancellation)
        {
            return await _commentService.ApproveComment(id, cancellation);
        }

        public async Task<List<CommentSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _commentService.GetAll(cancellation);
        }

        public async Task<Result> RejectComment(int id, CancellationToken cancellation)
        {
            return await _commentService.RejectComment(id, cancellation);
        }
    }
}
