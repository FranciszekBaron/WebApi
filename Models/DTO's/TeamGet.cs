namespace WebApplication1.Models.DTO_s
{
    public class TeamGet
    {
        public int teamID { get; set; }
        public int oID { get; set; }
        public string teamName { get; set; }

        public string teamDescription { get; set; }

        public IEnumerable<TeamGetMembers> members { get; set; }
    }

    public class TeamGetMembers
    {
        public int memberID { get; set; }

        public string name { get; set; }

        public DateTime membershipDate { get; set; }




    }
}
