using Microsoft.EntityFrameworkCore;
using Lesson_Entity_FrameWork.DAL.Ef;

namespace Lesson_Entity_FrameWork.DAL.Ef

{
    public class WebAppDbContex : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;

        public WebAppDbContex(DbContextOptions<WebAppDbContex> dbContextOptions): base(dbContextOptions)
        {
            Database.EnsureCreated();
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                new Book { Id=1, Name="Tom", Author = "me"},
                new Book { Id=2, Name="Alice", Author = "me"},
                new Book { Id=3, Name="Sam", Author = "me"}
                });
        }

    }

}
