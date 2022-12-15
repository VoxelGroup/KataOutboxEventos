using System;
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

        public CreateUserShould()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _createUser = new CreateUser(_userRepository);
        }
        
        [Fact]
        public void CreateUser()
        {
            _createUser.Execute();
            _userRepository.Received(1).SaveUser(Arg.Any<User>());
        }

        [Fact]
        public void SaveEvent()
        {
            _outBoxRepository.Received(1).SaveEvent(Arg.Any<OutboxRecord>());
        }
    }

    public interface IOutBoxRepository
    {
    }
}