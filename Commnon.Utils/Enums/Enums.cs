using System;
using System.Collections.Generic;
using System.Text;

namespace Commnon.Utils.Enums
{
    public class Enums
    {
        public enum State
        {
            //Usuario
            UsuarioActivo = 1,
            UsuarioInactivo = 2,
            UsuarioSuspendido = 3,
        }

        public enum TypePermission
        {
            Usuarios = 1,
            Roles = 2,
            Permisos = 3,
            Estados = 4,
        }

        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,

            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,

            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,

            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,

            //Estados
            ConsultarEstados = 10,
            ActualizarEstado = 11,
        }

        public enum RolUser
        {
            Administrador = 1,
            Estandar = 2,
        }

    }
}
