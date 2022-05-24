using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class BookInfo 
    {   //Column Book ID and Book Title
        [Key] 
        public int BookId { get; internal set; } //every key has to be unique no duplicates //This is represents adding to a coloumn in the table

        [Required(ErrorMessage = "Book Title is required")] //can use this to allow users add books to the system
        [MaxLength(64, ErrorMessage = "Length of Book Title cannot be greater than 64 characters")] //Type book title max length set
        [MinLength(2, ErrorMessage = "Length of Book Title cannot be less than 2 characters")]  //min book title set
        public string? BookTitle { get; set; }

        

        //Column Book Author
        [Required(ErrorMessage = "Book Author is required")] //can use this to allow users add books to the system
        [MaxLength(30, ErrorMessage = "Book Author name cannot be greater than 30 characters")] //Type book title max length set
        [MinLength(2, ErrorMessage = "Book Author name cannot be less than 2 characters")]  //min book title set
        public string? BookAuthor { get; set; }

       

        //Column Book Year
       // [Required(ErrorMessage = "Year of release is required")] 
      //  [MaxLength(4, ErrorMessage = "Year of release cannot be greater than 4 numbers")] // max book year characters
      //  [MinLength(2, ErrorMessage = "Year of release cannot be less than than 3 numbers")]  //min book year chracters
        public int BookYear { get; set; }

    }
}
//can create a database for you using this if there is no database with the name BookInfo, if it does not exist it will create an empty table for me in SQL.

// I will need to popculate this table with 10 default rows to start with