using System.Data;
using Starter.SampleModels;

namespace Starter
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IOutBoxRepository _outBoxRepository;
        private readonly IDbConnection _idbConnection;

        public CreateUser(IUserRepository userRepository, IOutBoxRepository outBoxRepository, IDbConnection idbConnection)
        {
            _userRepository = userRepository;
            _outBoxRepository = outBoxRepository;
            _idbConnection = idbConnection;
        }

        public void Execute()
        {
            var user = new User();
            var outboxRecord = new OutboxRecord();

            using (var transaction = _idbConnection.BeginTransaction())
            {
                _userRepository.SaveUser(user, transaction);
                _outBoxRepository.SaveEvent(outboxRecord, transaction);
                
                transaction.Commit();
            }
            
        }
    }
}