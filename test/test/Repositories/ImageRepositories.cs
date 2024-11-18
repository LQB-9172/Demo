using AutoMapper;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Repositories
{
    public class ImageRepositories : IImageRepositories
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public ImageRepositories(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ImageModel> GetImage(int Id)
        {
            var image = await _context.Images.SingleOrDefaultAsync();
            return _mapper.Map<ImageModel>(image);
        }
    }
}
