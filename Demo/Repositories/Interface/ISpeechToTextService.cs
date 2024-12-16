using System.Threading.Tasks;

namespace Demo.Repositories.Interface
{
    public interface ISpeechToTextService
    {
        Task<string> RecognizeSpeechFromMicrophoneAsync();
        string ApplyCorrections(string input, Dictionary<string, string> corrections);
    }
}
