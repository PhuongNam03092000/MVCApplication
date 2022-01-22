using Infrastructure.Entities;


namespace Service.DTOs
{
    public class BookAuthorDTO
    {
        public int bookId { get; set; }
        public int authorId { get; set; }
        public BookDTO book { get; set; }
        public AuthorDTO author { get; set; }
    }
}
