using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO_s
{
    public class TeamPut
    {
        [Required]
        public int oID { get; set; }

        [MaxLength(50)]
        [Required]
        public string teamName { get; set; }

        [MaxLength(50)]
        [Required]
        public string teamDescription { get; set; }
    
    }
}
