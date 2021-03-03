using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowRoom.Models;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Persistance
{

    public class FeatureRepository : IFeatureRepository
    {
        private readonly AppDbContext context;
        public FeatureRepository(AppDbContext context)
        {
            this.context = context;

        }

        public async Task<List<Feature>> GetFeatures()
        {
            return await context.Features.ToListAsync();
        }
    }
}