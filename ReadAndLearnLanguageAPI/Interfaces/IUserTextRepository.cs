using ReadAndLearnLanguageAPI.Model;

namespace ReadAndLearnLanguageAPI.Interfaces
{
    public interface IUserTextRepository
    {
        Task<List<UserText>> GetAllTexts(int userId);

        Task<bool> CreateText(UserText text);

        Task<bool> DeleteText(int textId);
    }
}