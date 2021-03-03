using System.Threading.Tasks;

namespace CarShowRoom.Persistance
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}