namespace DesignProject.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int User { get; set; }
        public string Owner { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int PhotoID { get; set; }
    }
}
