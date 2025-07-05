using MCV_Empity.SharedRepository;
using Microsoft.EntityFrameworkCore.Storage;

namespace MCV_Empity.UnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;

        public Task<IDbContextTransaction> BeginTransactionAsync();

        public Task CommitTransactionAsync();
        public Task RollBackTransactionAsync();

        public Task<int> CompleteAsync();
    }
}
