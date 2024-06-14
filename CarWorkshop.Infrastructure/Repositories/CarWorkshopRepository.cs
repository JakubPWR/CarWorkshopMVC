using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories
{
    public class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;
        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbContext.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.CarWorkshop?>> GetAll()
            => await _dbContext.CarWorkshops.ToListAsync();

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name)
            => _dbContext.CarWorkshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
        public async Task<IEnumerable<Domain.Entities.CarWorkshop?>> GetByNameList(string name)
        {
            var carWorkshops = await _dbContext.CarWorkshops.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToListAsync();
            return carWorkshops;
        }
        public async Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
        {
            var carWorkshop = await _dbContext.CarWorkshops.FirstAsync(c=>c.EncodedName == encodedName);
            return carWorkshop;
        }
        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
