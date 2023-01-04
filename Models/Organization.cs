namespace WebApplication1.Models
{
    public class Organization
    {
        public int oID { get; set; }
        public string oName { get; set; }
        public string oDomain{ get; set; }

        public virtual IEnumerable<Team> teams { get; set; }

        public virtual IEnumerable<Member> members { get; set; }
    }
}
