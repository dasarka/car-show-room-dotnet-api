using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowRoom.Models;

namespace CarShowRoom.Persistance
{
    public interface IFeatureRepository
    {
        Task<List<Feature>> GetFeatures();
    }
}