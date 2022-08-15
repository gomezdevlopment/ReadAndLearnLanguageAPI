using Microsoft.EntityFrameworkCore;
using ReadAndLearnLanguageAPI.Data;
using ReadAndLearnLanguageAPI.Interfaces;
using ReadAndLearnLanguageAPI.Model;

namespace ReadAndLearnLanguageAPI.Repositories
{
    public class UserTextRepository : IUserTextRepository
    {
        private readonly AppDbContext _context;

        public UserTextRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserText>> GetAllTexts(int userId)
        {
            return await _context.Texts.Where(text => text.UserId == userId).ToListAsync();
        }

        public  UserText? GetTextById(int textId)
        {
            return  _context.Texts.Single(x => x.TextId == textId);
        }

        public async Task<bool> CreateText(UserText text)
        {
            await _context.AddAsync(text);
            return await Save();
        }

        public async Task<bool> DeleteText(int textId)
        {
            var text = GetTextById(textId);
            if (text != null)
            {
                _context.Remove(text);
                return await Save();
            }
            return false;
        }

        public async Task<bool> Save()
        {
            await _context.SaveChangesAsync();
            return true;
        }
    }
}