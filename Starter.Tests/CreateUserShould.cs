using System;
using NSubstitute;
using Xunit;

namespace Starter.Tests
{
    public class CreateUserShould
    {
        private IUserRepository _userRepository;
        private CreateUser _createUser;

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
    }
}