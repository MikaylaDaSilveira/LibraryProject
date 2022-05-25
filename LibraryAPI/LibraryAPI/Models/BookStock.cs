using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class BookStock
    {   //Column Book ID and Book Title
        [Key]//Different book Id key for this table? 
        public int StockId { get; internal set; } //every key has to be unique no duplicates //This is represents adding to a coloumn in the table
        
        //Column Book Total
        //  [Required(ErrorMessage = "Enter total number of copies")]
        //  [MaxLength(2, ErrorMessage = "Cannot have more than 99 copies")] // max book copies characters
        public int BookTotal { get; set; } = 10;

        //Column Book Out
      //  [Required(ErrorMessage = "Enter number of copies currently being borrowed")]
      //  [MaxLength(2, ErrorMessage = "Cannot have that many copies out")] // max book copies characters
        public int BookOut { get; set; }

        //Column Book In
      //  [Required(ErrorMessage = "Enter number of copies currently in the library")]
      //  [MaxLength(2, ErrorMessage = "The library cannot hold that many copies")] 
        public int BookIn { get; set; }
    }
}
//can create a database for you using this if there is no database with the name BookInfo, if it does not exist it will create an empty table for me in SQL.

// I will need to popculate this table with 10 default rows to start with
