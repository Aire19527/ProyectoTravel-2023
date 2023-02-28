using System;
using System.Collections.Generic;
using System.Text;
using Travel.Domain.DTO.Library;

namespace Travel.Domain.Services.Interface
{
    public interface IAutoresServices
    {
        List<Autor_DTO> GetAllAutores();
    }
}
