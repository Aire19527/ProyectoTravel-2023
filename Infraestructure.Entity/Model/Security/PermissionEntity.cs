using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Entity.Model.Security
{
    [Table("Permission", Schema = "Security")]
    public class PermissionEntity
    {
        public PermissionEntity()
        {
            RolPermissionEntities = new HashSet<RolPermissionEntity>();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Permission { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }

        [ForeignKey("TypePermissionEntity")]
        public int IdTypePermission { get; set; }

        public TypePermissionEntity TypePermissionEntity { get; set; }

        public IEnumerable<RolPermissionEntity> RolPermissionEntities { get; set; }
    }
}
