using System.Data;

namespace Starter
{
    public interface IUserRepository
    {
        void SaveUser(User user, IDbTransaction dbTransaction);
    }
}