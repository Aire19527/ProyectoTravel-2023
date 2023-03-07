using System;
using System.Collections.Generic;
using System.Text;
using Travel.Domain.DTO.Library.Editorial;

namespace Travel.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        List<Editorial_Dto> GetAllEditorial();
    }
}
