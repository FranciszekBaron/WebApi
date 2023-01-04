namespace WebApplication1.Models
{
    public class Team
    {
        public int teamID { get; set; }
        public int oID { get; set; }
        public string teamName { get; set; }

        public string teamDescription { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual IEnumerable<File> Files { get; set; }

        public virtual IEnumerable<Membership> Memberships { get; set; }
    }
}
