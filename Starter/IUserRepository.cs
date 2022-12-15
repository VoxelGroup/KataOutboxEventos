using System.Data;

namespace Starter
{
    public interface IUserRepository
    {
        void Save(User user, IDbTransaction dbTransaction);
    }
}