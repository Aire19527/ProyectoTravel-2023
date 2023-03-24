using Commnon.Utils.Enums;
using Infraestructure.Core.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Domain.Services.Security.Interfaces;

namespace Travel.Domain.Services.Security
{
    public class PermissionServices: IPermissionServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        #region Builder
        public PermissionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


        #region Methods
        public bool ValidatePermissionByRol(Enums.Permission permission, int idRol)
        {
            var result = _unitOfWork.RolRepository
                                    .FirstOrDefault(x => x.Id == idRol
                                                      && x.RolPermissionEntities
                                                                    .Any(p => p.Id== permission.GetHashCode()));

            return result != null;
        }
        #endregion
    }
}
