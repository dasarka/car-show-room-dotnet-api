using System.Threading.Tasks;
using CarShowRoom.Models;

namespace CarShowRoom.Persistance
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicle(int id, bool includeRelated = true);
        void Add(Vehicle vehicle);
        void Remove(Vehicle vehicle);
    }
}