using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Attibutes
        private readonly DataContext _context;
        private bool disposed = false;
        #endregion

        //ctrl + k + s
        #region MyRegion
        public UnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
        }
        #endregion

        #region Properties

        private IRepository<EditorialEntity> editorialRepository;
        private IRepository<AutorBookEntity> autorBookRepository;
        private IRepository<AutoresEntity> autoresRepository;
        private IRepository<BookEntity> bookRepository;
        #endregion

        #region Members

        public IRepository<BookEntity> BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                    this.bookRepository = new Repository<BookEntity>(_context);

                return bookRepository;
            }
        }

        public IRepository<EditorialEntity> EditorialRepository
        {
            get
            {
                if (this.editorialRepository == null)
                    this.editorialRepository = new Repository<EditorialEntity>(_context);

                return editorialRepository;
            }
        }

        public IRepository<AutorBookEntity> AutorBookRepository
        {
            get
            {
                if (this.autorBookRepository == null)
                    this.autorBookRepository = new Repository<AutorBookEntity>(_context);

                return autorBookRepository;
            }
        }

        public IRepository<AutoresEntity> AutorRepository
        {
            get
            {
                if (this.autoresRepository == null)
                    this.autoresRepository = new Repository<AutoresEntity>(_context);

                return autoresRepository;
            }
        }



        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
        #endregion



        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();


    }
}
