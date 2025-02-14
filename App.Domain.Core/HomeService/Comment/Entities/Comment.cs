namespace App.Domain.Core.HomeService.Comment.Entities
{
    public class Comment
    {


        #region Properties
        public int Id { get; set; }
        public string Text { get; set; }
        public DateOnly CommentAt { get; set; }
        public int ExpertId { get; set; }
        #endregion

        #region NavigationProperties
        public Expert.Entities.Expert Expert { get; set; }
        #endregion
    }
}
