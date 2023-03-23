using Commnon.Utils.Enums;
using Commnon.Utils.Exceptions;
using Commnon.Utils.Resources;
using Infraestructure.Entity.Model.Security;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.User;

namespace Travel.Domain.Services.Security.Interfaces
{
    public interface IUserServices
    {
        UserEntity Login(LoginDto login);


        Task<bool> RegisterUser(AddUserDto add);
    }
}
