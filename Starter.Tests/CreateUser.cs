namespace Starter.Tests
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;

        public CreateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }

        public void Execute()   
        {
            throw new System.NotImplementedException();
        }
    }
}