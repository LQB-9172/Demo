using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public ImageRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddImageAsync(ImageModel model)
        {
            var newImage = _mapper.Map<Image>(model);
            _context.Images.Add(newImage);
            await _context.SaveChangesAsync();
            return newImage.ImageId;
        }

        public async Task<bool> DeleteImageAsync(int id)
        {
            var deleteImage = await _context.Images.FindAsync(id);
            if (deleteImage == null)
            {
                return false;
            }

            _context.Images.Remove(deleteImage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ImageModel>> GetAllImageAsync()
        {
            var images = await _context.Images.ToListAsync();
            return _mapper.Map<List<ImageModel>>(images);
        }

        public async Task<ImageModel> GetImage(int ImageId)
        {
            var image = await _context.Images.FindAsync(ImageId);
            return _mapper.Map<ImageModel>(image);
        }

        public async Task<bool> UpdateImageAsync(int id, ImageModel model)
        {
            var existImage = await _context.Images.FindAsync(id);
            if (existImage != null)
            {
                _context.Entry(existImage).State = EntityState.Detached;
                var updateImage = _mapper.Map<Image>(model);
                _context.Images.Update(updateImage);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
