using App.Domain.Core.HomeService.Category.Entities;
using App.Domain.Core.HomeService.Comment.Data;
using App.Domain.Core.HomeService.Result;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Comment
{
    public class CommentRepository(AppDbContext _dbContext) : ICommentRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.Comment.Entities.Comment comment, CancellationToken cancellation)
        {
            if (comment is null)
                return new Result(false, "Comment Is Null");

            await _dbContext.Comments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
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

        public async Task<List<Domain.Core.HomeService.Comment.Entities.Comment>>? GetAll(Domain.Core.HomeService.Comment.Entities.Comment comment, CancellationToken cancellation)
        {
            return await _dbContext.Comments.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Comment.Entities.Comment>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Comment.Entities.Comment comment, CancellationToken cancellation)
        {
            var com = await _dbContext.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (com is null)
                return new Result(false, "Comment Not Found.");


            com.ExpertId = comment.ExpertId;
            com.Text = comment.Text;
            

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
