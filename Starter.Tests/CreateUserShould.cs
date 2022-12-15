using System.Data;
using NSubstitute;
using Starter.SampleModels;
using Xunit;

namespace Starter.Tests
{
    public class CreateUserShould
    {
        private readonly IUserRepository _userRepository;
        private readonly CreateUser _createUser;
        private readonly IOutBoxRepository _outBoxRepository;
        private readonly IDbConnection _idbConnection;
        private readonly IDbTransaction _dbTransaction;

        public CreateUserShould()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _outBoxRepository = Substitute.For<IOutBoxRepository>();
            _idbConnection = Substitute.For<IDbConnection>();
            _dbTransaction = Substitute.For<IDbTransaction>();
            _createUser = new CreateUser(_userRepository, _outBoxRepository, _idbConnection);
        }
        
        [Fact]
        public void CreateUser()
        {
            _idbConnection.BeginTransaction().Returns(_dbTransaction);
            
            _createUser.Execute();
            
            _userRepository.Received(1).Save(Arg.Any<User>(), _dbTransaction);
        }

        [Fact]
        public void Save()
        {
            _idbConnection.BeginTransaction().Returns(_dbTransaction);
            
            _createUser.Execute();
            
            _outBoxRepository.Received(1).Save(Arg.Any<OutboxRecord>(), _dbTransaction);
            _dbTransaction.Received(1).Commit();
        }
        
    }
}