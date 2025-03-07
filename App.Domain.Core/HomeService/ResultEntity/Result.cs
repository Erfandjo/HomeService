namespace App.Domain.Core.HomeService.ResultEntity
{
    public class Result
    {
        public bool IsSucces { get; set; }
        public string? Message { get; set; }
        public int? Id { get; set; }

        public Result(bool isSuccess, string? message = null , int? id = null)
        {
            IsSucces = isSuccess;
            Message = message;
            Id = id;
        }

        public Result()
        {
            
        }

    }
}
