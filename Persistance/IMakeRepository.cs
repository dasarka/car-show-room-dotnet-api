using System.Collections.Generic;
using System.Threading.Tasks;
using CarShowRoom.Models;

namespace CarShowRoom.Persistance
{
    public interface IMakeRepository
    {
        Task<List<Make>> GetMakes(bool includeRelated = true);
    }
}