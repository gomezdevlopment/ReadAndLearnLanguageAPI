using Microsoft.EntityFrameworkCore;
using ReadAndLearnLanguageAPI.Data;
using ReadAndLearnLanguageAPI.Interfaces;
using ReadAndLearnLanguageAPI.Model;

namespace ReadAndLearnLanguageAPI.Repositories
{
    public class UserWordRepository : IRepository
    {
        private readonly AppDbContext _context;

        public UserWordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<M>> GetAll<M>(int userId) where M : class
        {
            return await _context.Set<M>().ToListAsync();
        }

        public async Task<bool> CreateWord(UserWord word)
        {
            await _context.AddAsync(word);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}