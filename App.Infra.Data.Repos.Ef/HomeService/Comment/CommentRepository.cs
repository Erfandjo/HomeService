using App.Domain.Core.HomeService.CommentEntity.Data;
using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Comment
{
    public class CommentRepository(AppDbContext _dbContext) : ICommentRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.CommentEntity.Entities.Comment comment, CancellationToken cancellation)
        {
            if (comment is null)
                return new Result(false, "Comment Is Null");

            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> ApproveComment(int id, CancellationToken cancellation)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment is null)
                return new Result(false, "نظر یافت نشد");

            comment.StatusEnum = Domain.Core.HomeService.CommentEntity.Enum.StatusEnum.Approve;
           
            await _dbContext.SaveChangesAsync();

            return new Result(true, "نظر با موفقیت تایید شد");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment is null)
                return new Result(false, "Comment Not Found.");

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<CommentSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Comments.AsNoTracking().Select(x => new CommentSummaryDto()
            {
                Id = x.Id,
                Text = x.Text,
                ExpertId = x.ExpertId,
                CommentAt = x.CommentAt,
                CustomerId = x.CustomerId,
                RequestId = x.RequestId,
                StatusEnum = x.StatusEnum,
            }).OrderBy(x => x.StatusEnum).ToListAsync();
        }

       

        public async Task<Domain.Core.HomeService.CommentEntity.Entities.Comment>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> RejectComment(int id, CancellationToken cancellation)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (comment is null)
                return new Result(false, "نظر یافت نشد");

            comment.StatusEnum = Domain.Core.HomeService.CommentEntity.Enum.StatusEnum.Reject;
            
            await _dbContext.SaveChangesAsync();

            return new Result(true, "نظر با رد شد تایید شد");
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.CommentEntity.Entities.Comment comment, CancellationToken cancellation)
        {
            var com = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (com is null)
                return new Result(false, "Comment Not Found.");


            
            com.Text = comment.Text;
            

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
