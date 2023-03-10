using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library.Editorial;

namespace Travel.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        List<Editorial_Dto> GetAllEditorial();

        Task<bool> InsertEditorial(AddEditorial_Dto editorial);

        Task<bool> UpdateEditorial(Editorial_Dto edit);

        Task<bool> DeleteEditorial(int idEditorial);

    }
}
