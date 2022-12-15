namespace Starter
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
            var user = new User();
            _userRepository.SaveUser(user);
        }
    }
}