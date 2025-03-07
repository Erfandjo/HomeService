using App.Domain.Core.HomeService.CommentEntity.AppService;
using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Customer.Profile
{
    [Authorize(Roles = "Customer")]
    public class CommentModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;


        public CommentModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
            Results = new Result();
            Comment = new CommentCreateDto();
        }

        [BindProperty]
        public int ExpertId { get; set; }

        [BindProperty]
        public int RequestId { get; set; }

        [BindProperty]
        public Result Results { get; set; }

        [BindProperty]
        public CommentCreateDto Comment { get; set; }



        public async Task OnGetAsync(int expertId, int requestId, CancellationToken cancellation)
        {
            ExpertId = requestId;
            RequestId = expertId;
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                Comment.ExpertId = ExpertId;
                Comment.RequestId = RequestId;
                Comment.CustomerId = UserTools.GetCustomerId(User.Claims);
                Results = await _commentAppService.Add(Comment, cancellationToken);
            }
         
            return Page();


        }
    }
}
