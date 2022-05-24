using LibraryAPI.Data.Repositories;
using LibraryAPI.Models;

namespace LibraryAPI.Services
{
    public class BookInfoService : ICrudService<BookInfo, int>
    {
        private readonly ICrudRepository<BookInfo, int> _BookInfoRepository;
        public BookInfoService(ICrudRepository<BookInfo, int> BookInfoRepository)
        {
            _BookInfoRepository = BookInfoRepository;
        }
        public void Add(BookInfo element)
        {
            _BookInfoRepository.Add(element);
            _BookInfoRepository.Save();
        }
        public void Delete(int BookID)
        {
            _BookInfoRepository.Delete(BookID);
            _BookInfoRepository.Save();
        }
        public BookInfo Get(int BookID)
        {
            return _BookInfoRepository.Get(BookID);
        }
        public IEnumerable<BookInfo> GetAll()
        {
            return _BookInfoRepository.GetAll();
        }
        public void Update(BookInfo old, BookInfo newT)
        {
            old.BookTitle = newT.BookTitle;
            old.BookAuthor = newT.BookAuthor;
            old.BookYear = newT.BookYear;
            _BookInfoRepository.Update(old);
            _BookInfoRepository.Save();
        }
    }
}

//I need to make a bookstock service, check out the employee example previously
