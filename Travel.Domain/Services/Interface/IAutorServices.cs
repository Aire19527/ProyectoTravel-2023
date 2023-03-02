using Infraestructure.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.Library;
using Travel.Domain.DTO.Library.Autor;

namespace Travel.Domain.Services.Interface
{
    public interface IAutorServices
    {
        List<ConsultAutor_DTO> GetAllAutores();
        Task<bool> InsertAutor(Autor_DTO autor);
        Task<bool> UpdateAutor(ConsultAutor_DTO autor);
        Task<bool> DeleteAutor(int idAutor);
    }
}
