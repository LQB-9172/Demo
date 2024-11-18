using AutoMapper;
using Demo.Data;
using Demo.Models;
using Demo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        private readonly Datacontext _context;
        private readonly IMapper _mapper;

        public AudioRepository(Datacontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddAudioAsync(AudioModel model)
        {
            var newAudio = _mapper.Map<Audio>(model);
            _context.Audios.Add(newAudio);
            await _context.SaveChangesAsync();
            return newAudio.AudioId;
        }

        public async Task<bool> DeleteAudioAsync(int id)
        {
            var deleteAudio = await _context.Audios.FindAsync(id);
            if (deleteAudio == null)
            {
                return false;
            }

            _context.Audios.Remove(deleteAudio);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AudioModel>> GetAllAudioAsync()
        {
            var audios = await _context.Audios.ToListAsync();
            return _mapper.Map<List<AudioModel>>(audios);
        }

        public async Task<AudioModel> GetAudio(int AudioId)
        {
            var audio = await _context.Audios.FindAsync(AudioId);
            return _mapper.Map<AudioModel>(audio);
        }

        public async Task<bool> UpdateAudioAsync(int id, AudioModel model)
        {
            var existAudio = await _context.Audios.FindAsync(id);
            if (existAudio != null)
            {
                _context.Entry(existAudio).State = EntityState.Detached;
                var updateAudio = _mapper.Map<Audio>(model);
                _context.Audios.Update(updateAudio);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
