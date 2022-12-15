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

        public CreateUserShould()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _outBoxRepository = Substitute.For<IOutBoxRepository>();
            _idbConnection = Substitute.For<IDbConnection>();
            _createUser = new CreateUser(_userRepository, _outBoxRepository, _idbConnection);
        }
        
        [Fact]
        public void CreateUser()
        {
            var dbTransaction = Substitute.For<IDbTransaction>();
            _idbConnection.BeginTransaction().Returns(dbTransaction);
            
            _createUser.Execute();
            
            _userRepository.Received(1).SaveUser(Arg.Any<User>(), dbTransaction);
        }

        [Fact]
        public void Save()
        {
            var dbTransaction = Substitute.For<IDbTransaction>();
            _idbConnection.BeginTransaction().Returns(dbTransaction);
            
            _createUser.Execute();
            
            _outBoxRepository.Received(1).SaveEvent(Arg.Any<OutboxRecord>(), dbTransaction);
            dbTransaction.Received(1).Commit();
        }
        
    }
}