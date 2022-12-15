using System.Data;
using Starter.SampleModels;

namespace Starter
{
    public interface IOutBoxRepository
    {
        void Save(OutboxRecord any, IDbTransaction dbTransaction);
    }
}