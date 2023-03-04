using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library.Book;
using Travel.Domain.Services.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Travel.Domain.Services
{
    public class BookServices : IBookServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Builder
        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods
        private BookEntity GetBook(int idBook) => _unitOfWork.BookRepository.FirstOrDefaultNotTracking(x => x.Id == idBook);

        public List<ConsultBook_Dto> GetAllBook()
        {
            IEnumerable<BookEntity> list = _unitOfWork.BookRepository.GetAll(e => e.EditorialEntity,
                                                                             a => a.AutorEntity);

            List<ConsultBook_Dto> result = list.Select(x => new ConsultBook_Dto()
            {
                Id = x.Id,
                IdEditorial = x.IdEditorial,
                N_Pages = x.N_Pages,
                Sinopsis = x.Sinopsis,
                Title = x.Title,
                Editorial = x.EditorialEntity.Name,
                Autor = x.AutorEntity.FullName
            }).ToList();

            return result;
        }

        public async Task<bool> InsertBook(AddBook_Dto add)
        {
            BookEntity book = new BookEntity()
            {
                IdEditorial = add.IdEditorial,
                N_Pages = add.N_Pages,
                Sinopsis = add.Sinopsis,
                Title = add.Title,
                IdAutor = add.IdAutor,
            };

            _unitOfWork.BookRepository.Insert(book);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> UpdateBook(Book_Dto update)
        {
            BookEntity book = GetBook(update.Id);

            book.Title = update.Title;
            book.Sinopsis = update.Sinopsis;
            book.N_Pages = update.N_Pages;
            book.IdEditorial = update.IdEditorial;
            book.IdAutor = update.IdAutor;


            _unitOfWork.BookRepository.Insert(book);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<bool> DeleteBook(int idBook)
        {
            BookEntity book = GetBook(idBook);
            _unitOfWork.BookRepository.Delete(book);

            return await _unitOfWork.Save() > 0;
        }

        #endregion
    }
}
