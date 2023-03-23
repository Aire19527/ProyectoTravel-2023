using Commnon.Utils.Enums;
using Commnon.Utils.Exceptions;
using Commnon.Utils.Resources;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model.Security;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using Travel.Domain.DTO.User;
using Travel.Domain.Services.Security.Interfaces;

namespace Travel.Domain.Services.Security
{
    public class UserServices : IUserServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Builder
        public UserServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Methods

        public UserEntity Login(LoginDto login)
        {
            UserEntity user = _unitOfWork.UserRepository.FirstOrDefault(x => x.UserName.ToLower() == login.UserName.ToLower()
                                                                  && x.Password == EncryptProvider.Sha256(login.Password));
            if (user == null)
                throw new BusinessException(GeneralMessages.BadCredentials);

            return user;
        }


        public async Task<bool> RegisterUser(AddUserDto add)
        {
            if (ExistUserName(add.UserName))
                throw new BusinessException(GeneralMessages.RegisteredUser);

            UserEntity user = new UserEntity()
            {
                Id = Guid.NewGuid(),
                LastName = add.UserName,
                Name = add.Name,
                UserName = add.UserName,
                Password = EncryptProvider.Sha256(add.Password),
                IdRol = (int)Enums.RolUser.Estandar,
            };
            _unitOfWork.UserRepository.Insert(user);

            return await _unitOfWork.Save() > 0;
        }

        private bool ExistUserName(string userName)
        {
            bool result = false;

            if (_unitOfWork.UserRepository.FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower()) == null)
                result = false;
            else
                result = true;

            return result;
        }

        #endregion
    }
}
