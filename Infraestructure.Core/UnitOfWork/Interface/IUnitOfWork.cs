using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Model;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<BookEntity> BookRepository { get; }

        IRepository<EditorialEntity> EditorialRepository { get; }

    

        IRepository<AutorEntity> AutorRepository { get; }

        void Dispose();

        Task<int> Save();


        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
