using App.Domain.Core.HomeService.ImageEntity.Service;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace App.Domain.Services.HomeService.Image
{
    public class ImageService : IImageService
    {

        public async Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellation)
        {
            string filePath;
            string fileName;
            if (FormFile != null)
            {
            // \wwwroot\Images\Profiles\ddc18de5 - 6339 - 4a80 - a5ac - 2f9933a6b4d2R.jpg
            fileName = Guid.NewGuid().ToString() +
                           ContentDispositionHeaderValue.Parse(FormFile.ContentDisposition).FileName.Trim('"');
                filePath = Path.Combine($"wwwroot\\Images\\{folderName}", fileName);
                try
                {
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await FormFile.CopyToAsync(stream, cancellation);
                    }
                }
                catch
                {
                    throw new Exception("Upload files operation failed");
                }
                return $"\\Images\\{folderName}\\{fileName}";
            }
            else
                fileName = "";

            return fileName;
        }

       
    
}
}
