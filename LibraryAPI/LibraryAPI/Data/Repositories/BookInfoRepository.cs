using LibraryAPI.Data;
using LibraryAPI.Models;

namespace LibraryAPI.Data.Repositories
{ //change TodoRepository with name of table class
    public class BookInfoRepository : ICrudRepository<BookInfo, int>
    {
        private readonly LibraryAPIContext _BookInfoContext;
        public BookInfoRepository(LibraryAPIContext LibraryAPIContext, LibraryAPIContext bookInfoContext)
        {
            _BookInfoContext = bookInfoContext ?? throw new
            ArgumentNullException(nameof(LibraryAPIContext));
        }
        public void Add(BookInfo bookinfo) //can call it bookinfo
        {
           // bookinfo.
            _BookInfoContext.BookInfos.Add(bookinfo);
        }
        public void Delete(int id)
        {
            var item = Get(id);
            if (item is not null) _BookInfoContext.BookInfos.Remove(Get(id));
        }
        public bool Exists(int id)
        {
            return _BookInfoContext.BookInfos.Any(u => u.BookId == id);
        }
        public BookInfo Get(int id)
        {
            return _BookInfoContext.BookInfos.FirstOrDefault(u => u.BookId == id);
        }
        public IEnumerable<BookInfo> GetAll()
        {
            return _BookInfoContext.BookInfos.ToList();
        }
        public bool Save()
        {
            return _BookInfoContext.SaveChanges() > 0;
        }
        public void Update(BookInfo element)
        {
            _BookInfoContext.Update(element);
        }
    }
}
//Think I need this page explained again 

//make a repository for bookstock