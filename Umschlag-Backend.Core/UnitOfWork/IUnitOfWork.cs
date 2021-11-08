using System.Threading.Tasks;
using Umschlag_Backend.Core.Repositories;

namespace Umschlag_Backend.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task CommitAsync();
        void Commit();
    }
}