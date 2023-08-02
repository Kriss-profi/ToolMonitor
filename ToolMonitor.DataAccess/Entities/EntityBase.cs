using System.ComponentModel.DataAnnotations;

namespace ToolMonitor.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
