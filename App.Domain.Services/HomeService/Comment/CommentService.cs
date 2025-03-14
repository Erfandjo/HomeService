using App.Domain.Core.HomeService.CommentEntity.Data;
using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.CommentEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Services.HomeService.Comment
{
    public class CommentService(ICommentRepository _commentRepository) : ICommentService
    {
        public async Task<Result> Add(CommentCreateDto comment , CancellationToken cancellation)
        {
            return await _commentRepository.Add(comment , cancellation);
        }

        public async Task<Result> ApproveComment(int id, CancellationToken cancellation)
        {
            return await _commentRepository.ApproveComment(id, cancellation);
        }

        public async Task<bool> CheckComment(int requestId , CancellationToken cancellation)
        {
            return await _commentRepository.CheckComment(requestId, cancellation);
        }

        public async Task<List<CommentSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _commentRepository.GetAll(cancellation);
        }

        public async Task<Result> RejectComment(int id, CancellationToken cancellation)
        {
            return await _commentRepository.RejectComment(id, cancellation);
        }
    }
}
