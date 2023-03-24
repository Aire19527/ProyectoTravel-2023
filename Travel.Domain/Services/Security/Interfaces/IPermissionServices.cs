using Commnon.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Domain.Services.Security.Interfaces
{
    public interface IPermissionServices
    {
        bool ValidatePermissionByRol(Enums.Permission permission, int idRol);
    }
}
