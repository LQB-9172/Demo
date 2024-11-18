using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Demo.Helpers;
using Microsoft.Extensions.Options;

namespace Demo.Helpers
{
    public class AzureBlobSettings
    {
        public required string ConnectionString { get; set; }
        public required string ContainerName { get; set; }
    }
    public class AzureBlobService
    {
        private readonly AzureBlobSettings _settings;
        private readonly BlobContainerClient _containerClient;

        public AzureBlobService(IOptions<AzureBlobSettings> options)
        {
            _settings = options.Value;
            _containerClient = new BlobContainerClient(_settings.ConnectionString, _settings.ContainerName);
            _containerClient.CreateIfNotExists(); // Tạo container nếu chưa tồn tại
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var blobClient = _containerClient.GetBlobClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                var blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = "image/jpeg" // hoặc "image/png" nếu ảnh là PNG
                };
                await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeaders });
            }
            return blobClient.Uri.ToString(); // Trả về URL của file
        }
    }
}
