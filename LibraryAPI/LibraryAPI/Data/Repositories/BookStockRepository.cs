using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Data.Repositories
{ //change TodoRepository with name of table class
    public class BookStockRepository : ICrudRepository<BookStock, int>
    {
        private readonly LibraryAPIContext _BookStockContext;
        public BookStockRepository(LibraryAPIContext LibraryAPIContext, LibraryAPIContext BookStockContext)
        {
            _BookStockContext = BookStockContext ?? throw new
            ArgumentNullException(nameof(LibraryAPIContext));
        }
        public void Add(BookStock bookstock) //can call it bookinfo
        {
            // bookinfo.
            _BookStockContext.BookStocks.Add(bookstock);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _BookStockContext.BookStocks.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _BookStockContext.BookStocks.Any(u => u.BookId == id);
        }
        public BookStock Get(int id)
        {
            return _BookStockContext.BookStocks.FirstOrDefault(u => u.BookId == id);
        }
        public IEnumerable<BookStock> GetAll()
        {
            return _BookStockContext.BookStocks.ToList();
        }
        public bool Save()
        {
            return _BookStockContext.SaveChanges() > 0;
        }
        public void Update(BookStock element)
        {
            _BookStockContext.Update(element);
        }
    }
}
