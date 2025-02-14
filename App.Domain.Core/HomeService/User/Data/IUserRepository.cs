namespace App.Domain.Core.HomeService.User.Data
{
    public interface IUserRepository
    {
        public Task<Result.Result> Add(User.Entities.User user, CancellationToken cancellation);
        public Task<Result.Result> Update(int id, User.Entities.User user , CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<User.Entities.User>>? GetAll(User.Entities.User user, CancellationToken cancellation);
        public Task<User.Entities.User>? GetById(int id, CancellationToken cancellation);
    }
}
