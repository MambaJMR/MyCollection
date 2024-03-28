
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ItransitionMVC.Settings;
using Microsoft.Extensions.Options;

namespace ItransitionMVC.Services
{
    public class UpLoadImageService
    {
        private Cloudinary _cloudinary;
        public UpLoadImageService(IOptions<CloudinarySettings>  cloudinarySettings)
        {
            Account account = new Account(
               cloudinarySettings.Value.CloudName,
               cloudinarySettings.Value.ApiKey,
               cloudinarySettings.Value.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }
        public string UploadImage(IFormFile file)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream())
            };
            var result = _cloudinary.UploadAsync(uploadParams).Result;

            return result.Url.ToString();

        }
    }
}
