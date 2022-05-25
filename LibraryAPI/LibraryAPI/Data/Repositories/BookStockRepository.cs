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
            return _BookStockContext.BookStocks.Any(u => u.StockId == id);
        }
        public BookStock Get(int id)
        {
            return _BookStockContext.BookStocks.FirstOrDefault(u => u.StockId == id);
        }
        public IEnumerable<BookStock> GetAll()
        {
            return _BookStockContext.BookStocks.ToList();
        }

        /*
        public IEnumerable<string> GetJoinedData()
        {
            List<BookInfo> bookinfos = _LibraryAPIContext.BookInfo.ToList();
            List<BookStock> bookstocks = _LibraryAPIContext.BookStock.ToList();

            var result = from bookinfo in bookinfos
                         join bookstock in bookstocks
                         on bookinfo.BookTitle equals bookstock.BookTitle
                         select $"BookTitle: {bookinfo.BookTitle}, Bookstock:{bookstock.BookTitle}";

        }
        */



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
