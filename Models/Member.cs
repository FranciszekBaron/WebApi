namespace WebApplication1.Models
{
    public class Member
    {
        public int memberID { get; set; }
        public int oID { get; set; }
        public string memberName { get; set; }
        public string memberSurname { get; set; }
        
        public string memberNickname { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual IEnumerable<Membership> Memberships { get; set; }
        

    }
}
