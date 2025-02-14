namespace App.Domain.Core.HomeService.Category.Data
{
    public interface ICategoryRepository
    {
        public Task<Result.Result> Add(Category.Entities.Category category , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Category.Entities.Category category, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Category.Entities.Category>>? GetAll(Category.Entities.Category category, CancellationToken cancellation);
        public Task<Category.Entities.Category>? GetById(int id , CancellationToken cancellation);
    }
}
