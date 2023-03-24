using Commnon.Utils.Enums;
using Commnon.Utils.Exceptions;
using Commnon.Utils.Resources;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using static Commnon.Utils.Constant.Const;
using static NETCore.Encrypt.Shared.Check;
using System;
using Travel.Domain.Services.Security.Interfaces;
using Commnon.Utils.Helpers;
using System.Linq;

namespace Travel.Web.Handlers
{
    public class CustomPermissionFilter : TypeFilterAttribute
    {
        public CustomPermissionFilter(Enums.Permission permission) : base(typeof(CustomPermissionFilterImplement))
        {
            Arguments = new object[] { permission };
        }

        private class CustomPermissionFilterImplement : IActionFilter
        {
            private readonly IPermissionServices _permissionServices;
            private readonly Enums.Permission _permission;

            public CustomPermissionFilterImplement(IPermissionServices permissionServices, Enums.Permission permission)
            {
                _permissionServices = permissionServices;
                _permission = permission;
            }

            public void OnActionExecuted(ActionExecutedContext context)
            {

            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                string idRol = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdRol).Value;

                bool result = _permissionServices.ValidatePermissionByRol(_permission, Convert.ToInt32(idRol));
                if (!result)
                    throw new BusinessException(GeneralMessages.WithoutPermission);
            }
        }
    }
}
