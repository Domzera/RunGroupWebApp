using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Repository
{
    public class RaceRepository:IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Race race)
        {
            //throw new NotImplementedException();
            _context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            //throw new NotImplementedException();
            _context.Remove(race);
            return Save();
        }

        //Aqui por ser ação asincrona tem que ter esses 'async' ' await' e o ToList-Async
        public async Task<IEnumerable<Race>> GetAll()
        {
            //throw new NotImplementedException();
            return await _context.Races.ToListAsync();
        }

        public Task<IEnumerable<Race>> GetAllRacesByCity(string city)
        {
            throw new NotImplementedException();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            //throw new NotImplementedException();
            return await _context.Races.FirstOrDefaultAsync();
        }

        public bool Save()
        {
            //throw new NotImplementedException();
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            //throw new NotImplementedException();
            _context.Update(race);
            return Save();
        }
    }
}
