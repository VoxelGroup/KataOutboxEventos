using System;
using System.Data;
using NSubstitute;
using Starter.SampleModels;
using Xunit;

namespace Starter.Tests
{
    public class CreateUserShould
    {
        private IUserRepository _userRepository;
        private CreateUser _createUser;
        private IOutBoxRepository _outBoxRepository;
        private IDbConnection _idbConnection;
        private IDbTransaction _dbTransaction;

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
            
            _userRepository.Received(1).SaveUser(Arg.Any<User>(), _dbTransaction);
        }

        [Fact]
        public void Save()
        {
            _idbConnection.BeginTransaction().Returns(_dbTransaction);
            
            _createUser.Execute();
            
            _outBoxRepository.Received(1).SaveEvent(Arg.Any<OutboxRecord>(), _dbTransaction);
            _dbTransaction.Received(1).Commit();
        }
        
    }
}