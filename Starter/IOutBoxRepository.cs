using System.Data;
using Starter.SampleModels;

namespace Starter
{
    public interface IOutBoxRepository
    {
        void SaveEvent(OutboxRecord any, IDbTransaction dbTransaction);
    }
}