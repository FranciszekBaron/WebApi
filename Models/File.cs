namespace WebApplication1.Models
{
    public class File
    {
        public int fileID { get; set; }
        public  int teamID { get; set; }
        public string fileName { get; set; }
        public string fileExtension { get; set; }
        public int fileSize { get; set; }

        public virtual Team Team { get; set; }
    }
}
