using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/todo
    public class BookStockController : ControllerBase
    {
        private readonly ICrudService<BookStock, int> _BookStockService;
        public BookStockController(ICrudService<BookStock, int> BookStockService)
        {
            _BookStockService = BookStockService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<BookStock>> GetAll() => _BookStockService.GetAll().ToList();

        // GET by BookTitle action
        [HttpGet("{BookTitle}")]
        public ActionResult<BookInfo> Get(int id, ActionResult<BookInfo> bookTitle)
        {
            var BookTitle = _BookStockService.Get(id);
            if (BookTitle is null) return NotFound();
            else
            {
                return bookTitle;
            }
        }

        // GET by Id action
        [HttpGet("{BookId}")]
        public ActionResult<BookStock> Get(int id)
        {
            var BookId = _BookStockService.Get(id);
            if (BookId is null) return NotFound();
            else return BookId;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(BookStock BookStock)
        {
            // Runs validation against model using data validation attributes
            //adds new row to database
            if (ModelState.IsValid)
            {
                _BookStockService.Add(BookStock);
                return base.CreatedAtAction(nameof(Create), new { id = BookStock.BookId }, BookStock);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookStock bookstock)
        {
            var existingBookStock = _BookStockService.Get(id);
            if (existingBookStock is null || existingBookStock.BookId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _BookStockService.Update(existingBookStock, bookstock);
                return NoContent();
            }
            return BadRequest();
        }



        // PUT action for getting a book out
        /*
        [HttpPut("{id}")]
        public IActionResult Update(int id) //updating current values
        {
            var existingBookIn = _BookStockService.Get(id);
            if (existingBookIn == null)
            {
                return BadRequest("No more copies of this book are Available");
            }
            var BookStock = new BookStock();
            int BookIn = BookStock.BookIn - 1;
            int BookOut = BookStock.BookOut + 1;
            _BookStockService.Update(BookStock, existingBookIn);
            return NoContent();
        }

        */





        //if (existingBookIn.BookIn > 0)
        //{
        //    existingBookIn = existingBookTotal - existingBookOut //shows current state
        //    existingBookIn ++i,                                     //changing BookIn state to 1 less
        //    existingBookOut i++,                                    //changing BookOut state to 1 more

        //    _BookStockService.Update(existingBookIn, existingBookOut); //Update these new values into table
        //    return NoContent();  // want it to return "Your book reservation has been made"
        //}
        //return BadRequest();

        //checkoutmethod, put ^^

        // PUT action for returning book 
        //[HttpPut("{id}")]
        //public IActionResult Update(BookStock.BookOut, BookStock.BookIn, BookStock bookstock) //updating current values
        //{
        //    var existingBookOut = _BookStockService.Get(BookOut);
        //    if (existingBookOut == 0)
        //    {
        //        return BadRequest("All Books are available and none need returning");
        //    }
        //    if (existingBookOut <= 10)
        //    {
        //        existingBookOut = existingBookTotal - existingBookIn //shows current state
        //        existingBookOut ++i,                                     //changing BookOut state to 1 less
        //        existingBookIn i++,                                    //changing BookIn state to 1 more

        //        _BookStockService.Update(existingBookIn, existingBookOut); //Update these new values into table
        //        return NoContent();  // want it to return "Thank you for returning your book"
        //    }
        //    return BadRequest();
        //}
        //checkoutmethod, put ^^

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookstock = _BookStockService.Get(id);
            if (bookstock is null) return NotFound();
            _BookStockService.Delete(id);
            return NoContent();
        }
    }
}
