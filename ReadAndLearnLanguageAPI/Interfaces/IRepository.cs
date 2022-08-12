using ReadAndLearnLanguageAPI.Model;

namespace ReadAndLearnLanguageAPI.Interfaces
{
    public interface IRepository
    {
        Task<List<M>> GetAll<M>(int userId) where M : class;

        Task<bool> CreateWord(UserWord word);
    }
}