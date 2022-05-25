using LibraryAPI.Data.Repositories;
using LibraryAPI.Models;
using LibraryAPI.Services;

namespace LibraryAPI.Services
{
    public class BookStockService : ICrudService<BookStock, int>
    {
        private readonly ICrudRepository<BookStock, int> _BookStockRepository;
        public BookStockService(ICrudRepository<BookStock, int> BookStockRepository)
        {
            _BookStockRepository = BookStockRepository;
        }
        public void Add(BookStock element)
        {
            _BookStockRepository.Add(element);
            _BookStockRepository.Save();
        }
        public void Delete(int BookID)
        {
            _BookStockRepository.Delete(BookID);
            _BookStockRepository.Save();
        }
        public BookStock Get(int BookID)
        {
            return _BookStockRepository.Get(BookID);
        }
        public IEnumerable<BookStock> GetAll()
        {
            return _BookStockRepository.GetAll();
        }

        public void Update(BookStock oldElement, BookStock newElement)
        {
            oldElement.BookTotal = newElement.BookTotal;
            oldElement.BookOut = newElement.BookOut;
            oldElement.BookIn = newElement.BookIn;
            _BookStockRepository.Update(oldElement);
            _BookStockRepository.Save(); ;
        }
    }
}

//I need to make a bookstock service, check out the employee example previously
