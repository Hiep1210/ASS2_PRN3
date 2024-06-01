using ASS2_PRN3.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASS2_PRN3.Repositories
{
    public class PublisherRepository : CommonRepository<Publisher>
    {
        public PublisherRepository(ASS2Context context) : base(context) { }

        public override IEnumerable<Publisher> FindBy(Expression<Func<Publisher, bool>> predicate)
        {
            return context.Publishers.Include(x => x.Books).Include(x => x.Users)
                .Where(predicate);
        }
        public override Publisher Add(Publisher entity)
        {
            entity.PubId = 0;
            return base.Add(entity);
        }
        public override Publisher Update(Publisher entity)
        {
            return base.Update(entity);
        }
        public override Publisher Delete(Publisher entity)
        {
            return base.Delete(entity);
        }

    }
}
