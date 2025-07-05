using MCV_Empity.Data;
using MCV_Empity.SharedRepository;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace MCV_Empity.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContect _Context;

        private readonly Dictionary<Type,object>_Repositories=new Dictionary<Type,object>();

        private IDbContextTransaction _Transaction;

        private bool IsDispose = false;
        public UnitOfWork(AppDbContect Context)
        {
            _Context=Context;
        }


        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
             _Transaction= await _Context.Database.BeginTransactionAsync();
            return _Transaction;
        }

        public async Task CommitTransactionAsync()
        {
            await _Transaction.CommitAsync();
        }

        public async Task<int> CompleteAsync()
        {
            return await _Context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!IsDispose)
            {
                if (disposing)
                {
                    _Transaction.Dispose();
                    _Context.Dispose();
                }
                IsDispose = true;
            }

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            if (_Repositories.ContainsKey(typeof(T)))
            {
                return _Repositories[typeof(T)] as IGenericRepository<T>;
            }

            var Repository = new GenericRepository<T>(_Context);
            _Repositories.Add(typeof(T), Repository);
            return Repository;
        }

        public async Task RollBackTransactionAsync()
        {
            await _Transaction.CommitAsync();
        }
    }
}
