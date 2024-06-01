using ASS2_PRN3.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASS2_PRN3.Repositories
{
    public class AuthorRepository : CommonRepository<Author>
    {
        public AuthorRepository(ASS2Context context) : base(context) { }
        public override Author Get(int id)
        {
            return context.Authors.Include(x => x.BookAuthors).ThenInclude(book => book.Book)
                .FirstOrDefault(x => x.AuthorId == id);
        }
        public override Author Add(Author entity)
        {
            entity.AuthorId = 0;
            return base.Add(entity);
        }
        public override Author Delete(Author entity)
        {
            return base.Delete(entity);
        }
        public override Author Update(Author entity)
        {
            return base.Update(entity);
        }
        public override IEnumerable<Author> FindBy(Expression<Func<Author, bool>> predicate)
        {
            return context.Authors.Include(x => x.BookAuthors).ThenInclude(book => book.Book)
                .Where(predicate);
        }

    }
}
