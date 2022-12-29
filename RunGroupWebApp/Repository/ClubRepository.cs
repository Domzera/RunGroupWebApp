using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Club club)
        {
            //throw new NotImplementedException();
            _context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            //throw new NotImplementedException();
            _context.Remove(club);
            return Save();
        }

        //Aqui por ser ação asincrona tem que ter esses 'async' ' await' e o ToList-Async
        public async Task<IEnumerable<Club>> GetAll()
        {
            //throw new NotImplementedException();
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            //throw new NotImplementedException();
            return await _context.Clubs.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetClubByCity(string city)
        {
            //throw new NotImplementedException();
            return await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            //throw new NotImplementedException();
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            //throw new NotImplementedException();
            _context.Update(club);
            return Save();
        }
    }
}
