using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface IImageRepository
    {
        public Task<List<ImageModel>> GetAllImageAsync();
        public Task<ImageModel> GetImage(int ImageId);
        public Task<int> AddImageAsync(ImageModel model);
        public Task<bool> UpdateImageAsync(int id, ImageModel model);
        public Task<bool> DeleteImageAsync(int id);
    }
}
