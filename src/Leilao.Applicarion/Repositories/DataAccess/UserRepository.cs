using Leilao.Applicarion.Entities;
using Leilao.Applicarion.Repositories.Contexts;
using Leilao.Applicarion.Repositories.Contracts;

namespace Leilao.Applicarion.Repositories.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly LeilaoDbContext _context;
        public UserRepository(LeilaoDbContext context) => _context = context;
        public bool ExisteUserWithEmail(string email) => _context.Users.Any(user => user.Email.Equals(email));

        public User GetUserByEmail(string email) => _context.Users.First(user => user.Email.Equals(email));

    }
}
