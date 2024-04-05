using Leilao.Applicarion.Entities;

namespace Leilao.Applicarion.Repositories.Contracts
{
    public interface IUserRepository
    {
        bool ExisteUserWithEmail(string email);
        User GetUserByEmail(string email);
    }
}
