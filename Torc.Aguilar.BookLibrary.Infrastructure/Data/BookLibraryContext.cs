using Microsoft.EntityFrameworkCore;
using Torc.Aguilar.BookLibrary.Core.Entities;

namespace Torc.Aguilar.BookLibrary.Infrastructure.Data
{
    public partial class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>(b =>
            {
                b.Property(b => b.TotalCopies).HasDefaultValue(0);
                b.Property(b => b.CopiesInUse).HasDefaultValue(0);
            });
        }
    }
}
