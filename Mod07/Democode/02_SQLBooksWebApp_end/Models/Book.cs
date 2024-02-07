namespace SQLBooksWebApp.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int Published { get; set; }
        public virtual Author? Author { get; set; }
    }
}
