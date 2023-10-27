namespace LibraryAPI.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public double AverageRating { get; set; }
        public bool IsCheckedOut { get; set; }
    }
}
