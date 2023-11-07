namespace WebApplication1.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            Author = string.Empty;
        }
    }
}
