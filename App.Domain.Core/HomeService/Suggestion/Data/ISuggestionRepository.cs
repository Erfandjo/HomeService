namespace App.Domain.Core.HomeService.Suggestion.Data
{
    public interface ISuggestionRepository
    {
        public Task<Result.Result> Add(Suggestion.Entities.Suggestion suggestion, CancellationToken cancellation);
        public Task<Result.Result> Update(int id , Suggestion.Entities.Suggestion suggestion, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Suggestion.Entities.Suggestion>>? GetAll(Suggestion.Entities.Suggestion suggestion, CancellationToken cancellation);
        public Task<Suggestion.Entities.Suggestion>? GetById(int id , CancellationToken cancellation);
    }
}
