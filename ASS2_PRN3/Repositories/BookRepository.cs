using ASS2_PRN3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ASS2_PRN3.Repositories
{
    public class BookRepository : CommonRepository<Book>
    {
        public BookRepository(ASS2Context context) : base(context) { }

        public override IEnumerable<Book> FindBy(Expression<Func<Book, bool>> predicate)
        {
            return context.Books.Include(x => x.Pub)
                .Include(x => x.BookAuthors).ThenInclude(auth => auth.Author)
                .Where(predicate).ToList();
        }

        public override Book Get(int id)
        {
            return context.Books.Include(x => x.Pub)
                .Include(x => x.BookAuthors).ThenInclude(auth => auth.Author)
                .FirstOrDefault(x => x.BookId == id);
        }

        public override IEnumerable<Book> GetAll()
        {
            return context.Books.Include(x => x.Pub)
                .Include(x => x.BookAuthors).ThenInclude(auth => auth.Author).ToList();
        }

        public override Book Add(Book entity)
        {
            entity.BookId = 0;
            return base.Add(entity);
        }

        public override Book Update(Book entity)
        {
            return base.Update(entity);
        }
        public override Book Delete(Book entity)
        {
            return base.Delete(entity);
        }

    }
}
