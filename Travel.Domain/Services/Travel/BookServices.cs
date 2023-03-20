using Commnon.Utils.Exceptions;
using Commnon.Utils.Helpers;
using Commnon.Utils.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library.Book;
using Travel.Domain.Services.Travel.Interface;

namespace Travel.Domain.Services.Travel
{
    public class BookServices : IBookServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _environment;
        #endregion

        #region Builder
        public BookServices(IUnitOfWork unitOfWork, IConfiguration configuration, IHostingEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _config = configuration;
            _environment = environment;
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
                Autor = x.AutorEntity.FullName,
                IdAutor = x.IdAutor,
                UrlImagen = GetImagen(x.UrlImage)
            }).ToList();

            return result;
        }

        private string GetImagen(string img)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(img))
                path = $"/{_config.GetSection("PathFiles").GetSection("NoImage").Value}";
            else
                path = $"/{img}";

            return path;
        }

        public async Task<bool> InsertBook(AddBook_Dto add)
        {
            string urlImage = string.Empty;
            if (add.FileImage != null)
                urlImage = UploadImage(add.FileImage);

            BookEntity book = new BookEntity()
            {
                IdEditorial = add.IdEditorial,
                N_Pages = add.N_Pages,
                Sinopsis = add.Sinopsis,
                Title = add.Title,
                IdAutor = add.IdAutor,
                UrlImage = urlImage
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

            _unitOfWork.BookRepository.Update(book);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<string> UpdateImageBook(Book_Dto update)
        {
            string urlImage = string.Empty;
            if (update.FileImage != null)
                urlImage = UploadImage(update.FileImage);
            else
                throw new BusinessException("Por favor seleccionar una imagen.");

            BookEntity book = GetBook(update.Id);

            if (!string.IsNullOrEmpty(book.UrlImage))
                DeleteImage(book.UrlImage);

            book.UrlImage = urlImage;

            _unitOfWork.BookRepository.Update(book);
            await _unitOfWork.Save();

            return urlImage;
        }

        private void DeleteImage(string path)
        {
            string fullPath = Path.Combine(_environment.WebRootPath, path);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }



        private string UploadImage(IFormFile fileImage)
        {
            if (fileImage.Length > 3000000)
                throw new BusinessException("El archivo seleccionado es muy grande: [máximo 3 MB]");

            //Valido primero todas las extensiones de los archivos antes de mandar a guardar en nube.
            string extension = Path.GetExtension(fileImage.FileName);
            if (!Helper.ValidImageExtencion(extension))
                throw new BusinessException(GeneralMessages.ImgExtension);

            string path = _config.GetSection("PathFiles").GetSection("Book").Value;
            string uploads = Path.Combine(_environment.WebRootPath, path);
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);


            string uniqueFileName = Helper.GetUniqueFileName(fileImage.FileName);
            string filePath = $"{uploads}/{uniqueFileName}";
            using (var stream = File.Create(filePath))
            {
                fileImage.CopyTo(stream);
            }

            return $"{path}/{uniqueFileName}";
        }

        public async Task<bool> DeleteBook(int idBook)
        {
            BookEntity book = GetBook(idBook);
            if (!string.IsNullOrEmpty(book.UrlImage))
                DeleteImage(book.UrlImage);

            _unitOfWork.BookRepository.Delete(book);

            return await _unitOfWork.Save() > 0;
        }

        #endregion
    }
}
