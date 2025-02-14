namespace App.Domain.Core.HomeService.Comment.Data
{
    public interface ICommentRepository
    {
        public Task<Result.Result> Add(Comment.Entities.Comment comment , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Comment.Entities.Comment comment , CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Comment.Entities.Comment>>? GetAll(Comment.Entities.Comment comment, CancellationToken cancellation);
        public Task<Comment.Entities.Comment>? GetById(int id, CancellationToken cancellation);
    }
}
