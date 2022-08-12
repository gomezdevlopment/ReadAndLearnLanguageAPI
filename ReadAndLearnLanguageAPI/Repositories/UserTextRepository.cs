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

        public async Task<bool> CreateText(UserText text)
        {
            await _context.AddAsync(text);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}