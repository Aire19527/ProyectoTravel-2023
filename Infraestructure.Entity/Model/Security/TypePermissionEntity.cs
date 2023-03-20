using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Model.Security
{
    [Table("TypePermission", Schema = "Security")]
    public class TypePermissionEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string TypePermission { get; set; }

        public IEnumerable<PermissionEntity> PermissionEntities { get; set; }
    }
}
