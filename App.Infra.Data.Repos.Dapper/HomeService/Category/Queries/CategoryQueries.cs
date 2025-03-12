namespace App.Infra.Data.Repos.Dapper.HomeService.Category.Queries
{
    public static class CategoryQueries
    {

        public static string GetAll =
       "SELECT Id,Title,ImagePath FROM Categories";


    }
}
