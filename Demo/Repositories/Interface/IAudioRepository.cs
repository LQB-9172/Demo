using Demo.Models;

namespace Demo.Repositories.Interface
{
    public interface IAudioRepository
    {
        public Task<List<AudioModel>> GetAllAudioAsync();
        public Task<AudioModel> GetAudio(int AudioId);
        public Task<int> AddAudioAsync(AudioModel model);
        public Task<bool> UpdateAudioAsync(int id, AudioModel model);
        public Task<bool> DeleteAudioAsync(int id);
    }
}
