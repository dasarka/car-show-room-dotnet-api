using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Persistance
{

    public class MakeRepository : IMakeRepository
    {
        private readonly AppDbContext context;
        public MakeRepository(AppDbContext context)
        {
            this.context = context;

        }

        public async Task<List<Make>> GetMakes(bool includeRelated = true)
        {
            if (!includeRelated)
            {
                return await context.Makes.ToListAsync();
            }

            return await context.Makes.Include(m => m.Models).ToListAsync();
        }
    }
}