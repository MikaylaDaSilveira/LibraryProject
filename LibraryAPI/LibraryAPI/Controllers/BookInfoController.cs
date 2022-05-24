using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Services;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]//URL: http://localhost:5066/todo
    public class BookInfoController : ControllerBase
    {
        private readonly ICrudService<BookInfo, int> _BookInfoService;
        public BookInfoController(ICrudService<BookInfo, int> BookInfoService)
        {
            _BookInfoService = BookInfoService;
        }

        // GET all action
        [HttpGet] // auto returns data with a Content-Type of application/json
        public ActionResult<List<BookInfo>> GetAll() => _BookInfoService.GetAll().ToList();

        // GET by BookTitle action
        [HttpGet("{id}")]
        public ActionResult<BookInfo> Get(int id)
        {
            var BookTitle = _BookInfoService.Get(id);
            if (BookTitle is null) return NotFound();
            else return BookTitle;
        }
        
       /* // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<BookInfo> Get(int id)
        {
            var BookId = _BookInfoService.Get(id);
            if (BookId is null) return NotFound();
            else return BookId;
        }
        //Get an get error here not sure why? something to do with primary keys?
        */
        // POST action
        [HttpPost]
        public IActionResult Create(BookInfo BookInfo)
        {
            // Runs validation against model using data validation attributes
            //adds new row to database
            if (ModelState.IsValid)
            {
                _BookInfoService.Add(BookInfo);
                return base.CreatedAtAction(nameof(Create), new { id = BookInfo.BookId }, BookInfo);
            }
            return BadRequest();
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, BookInfo bookinfo)
        {
            var existingBookInfo = _BookInfoService.Get(id);
            if (existingBookInfo is null || existingBookInfo.BookId != id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _BookInfoService.Update(existingBookInfo, bookinfo);
                return NoContent();
            }
            return BadRequest();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookinfo = _BookInfoService.Get(id);
            if (bookinfo is null) return NotFound();
            _BookInfoService.Delete(id);
            return NoContent();
        }
    }
}

//need a controller for each table,