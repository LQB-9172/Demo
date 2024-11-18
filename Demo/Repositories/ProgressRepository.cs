using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class ProgressRepository : IProgressRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public ProgressRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddProgressAsync(ProgressModel model)
        {
            var newProgress = _mapper.Map<Progress>(model);
            _context.Progresses.Add(newProgress);
            await _context.SaveChangesAsync();
            return newProgress.ProgressID;
        }

        public async Task<bool> DeleteProgressAsync(int id)
        {
            var deleteProgress = await _context.Progresses.FindAsync(id);
            if (deleteProgress == null)
            {
                return false;
            }

            _context.Progresses.Remove(deleteProgress);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProgressModel>> GetAllProgressAsync()
        {
            var progresses = await _context.Progresses.ToListAsync();
            return _mapper.Map<List<ProgressModel>>(progresses);
        }

        public async Task<ProgressModel> GetProgress(int ProgressId)
        {
            var progress = await _context.Progresses.FindAsync(ProgressId);
            return _mapper.Map<ProgressModel>(progress);
        }

        public async Task<bool> UpdateProgressAsync(int id, ProgressModel model)
        {
            var existProgress = await _context.Progresses.FindAsync(id);
            if (existProgress != null)
            {
                _context.Entry(existProgress).State = EntityState.Detached;
                var updateProgress = _mapper.Map<Progress>(model);
                _context.Progresses.Update(updateProgress);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
