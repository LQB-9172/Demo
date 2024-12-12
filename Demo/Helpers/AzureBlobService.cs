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

            // Mở stream để đọc tệp
            using (var stream = file.OpenReadStream())
            {
                // Xác định ContentType dựa trên loại tệp
                var contentType = file.ContentType;

                // Kiểm tra và gán content type đúng
                if (string.IsNullOrEmpty(contentType))
                {
                    // Nếu không thể lấy ContentType, tự động nhận diện dựa vào phần mở rộng
                    var extension = Path.GetExtension(file.FileName).ToLower();
                    contentType = extension switch
                    {
                        ".jpg" => "image/jpeg",
                        ".jpeg" => "image/jpeg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        ".mp3" => "audio/mp3",
                        ".mp4" => "video/mp4",
                        _ => "application/octet-stream" // Loại mặc định cho tệp không xác định
                    };
                }

                // Tạo HTTP headers với ContentType xác định
                var blobHttpHeaders = new BlobHttpHeaders
                {
                    ContentType = contentType
                };

                // Upload tệp lên Azure Blob Storage
                await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeaders });
            }

            // Trả về URL của file đã upload
            return blobClient.Uri.ToString();
        }
    }
}
