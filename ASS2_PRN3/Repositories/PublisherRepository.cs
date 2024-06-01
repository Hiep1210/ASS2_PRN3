using ASS2_PRN3.Models;
using System.Linq.Expressions;

namespace ASS2_PRN3.Repositories
{
    public class PublisherRepository : CommonRepository<Publisher>
    {
        public PublisherRepository(ASS2Context context) : base(context) { }
        
    }
}
