using Lesson_Entity_FrameWork.DAL.Ef;
using Lesson_Entity_FrameWork.Models;

namespace Lesson_Entity_FrameWork.Services
{
    public interface IBookService
    {
        public IEnumerable<Lesson_Entity_FrameWork.Models.Book> GetAll();

        public void Add(string name, string author);

        public void Delete(int id);
    }



    public class DBMyBookService : IBookService
    {
        private readonly WebAppDbContex? _context;

        public DBMyBookService(WebAppDbContex context)
        {
            _context = context;
        }

        public IEnumerable<Models.Book> GetAll()
        {
            return _context.Books.Select(x => new Models.Book()
            {
                Name = x.Name,
                Id = x.Id,
                Author = x.Author
            });
        }

        public void Add(string name, string autor)
        {
            _context.Books.Add(new DAL.Ef.Book() { Name = name, Author = autor });
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var bookToDelete = new DAL.Ef.Book() { Id = id };
            _context.Books.Attach(bookToDelete);
            _context.Books.Remove(bookToDelete);
            _context.SaveChanges();
        }


    }
}
