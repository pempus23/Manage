using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
