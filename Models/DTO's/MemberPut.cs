using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO_s
{
    public class MemberPut
    {


        [Required]
        public int oID { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string memberName { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string memberSurname { get; set; }

        [MaxLength(50)]
        [Required]
        public string memberNickname { get; set; }

        public int teamID { get; set; }


    }
}
