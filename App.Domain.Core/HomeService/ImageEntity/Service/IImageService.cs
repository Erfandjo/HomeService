using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.ImageEntity.Service
{
    public interface IImageService
    {
       public Task<string> UploadImage(IFormFile FormFile, string folderName, CancellationToken cancellationToken);
    }
}
