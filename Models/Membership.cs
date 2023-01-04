namespace WebApplication1.Models
{
    public class Membership
    {
        public int memberID { get; set; }
        public int teamID { get; set; }
        public DateTime MembershipDate { get; set; }
       

        public virtual Member Member { get; set; }

        public virtual Team Team { get; set; }


    }
}
