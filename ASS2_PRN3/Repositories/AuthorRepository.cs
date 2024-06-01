using ASS2_PRN3.Models;

namespace ASS2_PRN3.Repositories
{
    public class AuthorRepository : CommonRepository<Author>
    {
        public AuthorRepository(ASS2Context context) : base(context) { }
        
    }
}
