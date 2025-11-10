using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CinemaContext repositoryContext)
            : base(repositoryContext) 
        {
        }
    }
}
