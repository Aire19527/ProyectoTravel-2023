using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.Entity.Model.Security
{
    public class RolEntity
    {
        public RolEntity()
        {
            UserEntities=new HashSet<UserEntity>();
            RolPermissionEntities=new HashSet<RolPermissionEntity>();   
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Rol { get; set; }

        public IEnumerable<UserEntity> UserEntities { get; set; }
        public IEnumerable<RolPermissionEntity> RolPermissionEntities { get; set; }

    }
}

