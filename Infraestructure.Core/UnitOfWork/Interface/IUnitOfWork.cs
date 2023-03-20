using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Model;
using Infraestructure.Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<BookEntity> BookRepository { get; }

        IRepository<EditorialEntity> EditorialRepository { get; }

        IRepository<AutorEntity> AutorRepository { get; }

        IRepository<UserEntity> UserRepository { get; }
        IRepository<TypePermissionEntity> TypePermissionRepository { get; }

        IRepository<RolPermissionEntity> RolPermissionRepository { get; }

        IRepository<RolEntity> RolRepository { get; }

        IRepository<PermissionEntity> PermissionRepository { get; }



        void Dispose();

        Task<int> Save();


        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
