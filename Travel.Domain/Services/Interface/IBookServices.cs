using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library.Book;

namespace Travel.Domain.Services.Interface
{
    public interface IBookServices
    {
        List<ConsultBook_Dto> GetAllBook();

        Task<bool> InsertBook(AddBook_Dto add);

        Task<bool> UpdateBook(Book_Dto update);

        Task<bool> DeleteBook(int idBook);
    }
}
