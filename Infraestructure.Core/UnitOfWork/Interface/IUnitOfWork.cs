using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Model;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<BookEntity> BookRepository { get; }

        IRepository<EditorialEntity> EditorialRepository { get; }

        IRepository<AutorBookEntity> AutorBookRepository { get; }

        IRepository<AutoresEntity> AutorRepository { get; }
    }
}
