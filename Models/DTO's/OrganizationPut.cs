using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO_s
{
    public class OrganizationPut
    {
        [MaxLength(50)]
        [Required]
        public string oName { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string oDomain { get; set; }
    }
}
