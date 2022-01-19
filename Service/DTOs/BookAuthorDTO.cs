using Infrastructure.Entities;


namespace Service.DTOs
{
    public class BookAuthorDTO
    {
        public int bookId { get; set; }
        public int authorId { get; set; }
        public Book book { get; set; }
        public Author author { get; set; }
    }
}
