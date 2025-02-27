using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CommentEntity.AppService;
using App.Domain.Core.HomeService.CommentEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Comment
{
    // [Authorize(Roles = "Admin")]
    public class IndexModel(ICommentAppService _commentAppService) : PageModel
    {
      

    

        [BindProperty]
        public List<CommentSummaryDto> Comments { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)

        {
            Comments = await _commentAppService.GetAll(cancellation);
        }

        public async Task<IActionResult> OnGetApproveAsync(int id, CancellationToken cancellation)
        {
            var result = await _commentAppService.ApproveComment(id, cancellation);
            return RedirectToAction("OnGet");
        }

        public async Task<IActionResult> OnGetRejectAsync(int id, CancellationToken cancellation)
        {
            var result = await _commentAppService.RejectComment(id, cancellation);
            return RedirectToAction("OnGet");
        }


        //public async Task<IActionResult> OnGetDeleteAsync(int id, CancellationToken cancellation)
        //{
        //    var result = await _categoryAppService.Delete(id, cancellation);
        //    return RedirectToAction("OnGet");
        //}
    }
}
