using Commnon.Utils.Enums;
using Infraestructure.Entity.Model.Security;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;


        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            //await CheckStateAsync();
            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();
            await CheckUserAsync();
        }

        //private async Task CheckStateAsync()
        //{
        //    if (!_context.StatusEntity.Any())
        //    {
        //        _context.StatusEntity.AddRange(new List<StatusEntity>
        //        {
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.UsuarioActivo,
        //                Status="Activo",
        //                Ambit="Usuarios",
        //                Description="Estado de un usuario Activo en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.UsuarioInactivo,
        //                Status="Inactivo",
        //                Ambit="Usuarios",
        //                Description="Estado de un usuario Inactivo en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.UsuarioSuspendido,
        //                Status="Suspendido",
        //                Ambit="Usuarios",
        //                Description="Estado de un usuario Suspendido en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.TransaccionAprobada,
        //                Status="Aprobada",
        //                Ambit="Transacciones",
        //                Description="Estado de una Transacción Aprobada en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.TransaccionCancelada,
        //                Status="Cancelada",
        //                Ambit="Transacciones",
        //                Description="Estado de una Transacción Cancelada en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.TransaccionPendiente,
        //                Status="Pendiente",
        //                Ambit="Transacciones",
        //                Description="Estado de una Transacción Pendiente en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.TransaccionInvalida,
        //                Status="Inválida",
        //                Ambit="Transacciones",
        //                Description="Estado de una Transacción Inválida en Lucky Partner"
        //            },
        //            new StatusEntity
        //            {
        //                Id=(int)Enums.State.TransaccionReferenciaPagoGenerada,
        //                Status="Referencia de Pago Generada",
        //                Ambit="Transacciones",
        //                Description="Estado de una Transacción a que se le ha generado una Referencia de Pago en Lucky Partner"
        //            },
        //        });

        //        await _context.SaveChangesAsync();
        //    }
        //}

        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                    new TypePermissionEntity
                    {
                        Id=(int)Enums.TypePermission.Usuarios,
                        TypePermission="Usuarios"
                    },
                    new TypePermissionEntity
                    {
                        Id=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"
                    },
                    new TypePermissionEntity
                    {
                        Id=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"
                    },
                    new TypePermissionEntity
                    {
                        Id=(int)Enums.TypePermission.Estados,
                        TypePermission="Estados"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Crear Usuarios",
                        Description="Crear usuarios en el sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuario en el sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuairo del sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de un Roles en el sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un Permiso en el sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos Rol",
                        Description="Denegar permisos a un rol del sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar los estados del sistema"
                    },
                    new PermissionEntity
                    {
                        Id=(int)Enums.Permission.ActualizarEstado,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estados",
                        Description="Actualizar los estados del sistema"
                    },
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        Id=(int)Enums.RolUser.Administrador,
                        Rol="Administrador"
                    },
                    new RolEntity
                    {
                        Id=(int)Enums.RolUser.Estandar,
                        Rol="Estandar"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }

        //Asignamos todos los permisos al rol administrador
        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.Id
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);

                await _context.SaveChangesAsync();
            }
        }

        //Creamos un usuario por defecto
        private async Task CheckUserAsync()
        {
            if (!_context.UserEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                UserEntity user = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    IdRol = (int)Enums.RolUser.Administrador,
                    //IdStatus = (int)Enums.State.UsuarioActivo,
                    Name = "Juan Pablo",
                    LastName = "Rodriguez Toro",
                    UserName = "aire",
                    Password = EncryptProvider.Sha256("123456"),
                };

                
                _context.UserEntity.Add(user);

                await _context.SaveChangesAsync();
            }
        }
    }
}
