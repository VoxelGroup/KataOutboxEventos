using System;

namespace Starter.SampleModels
{
    public class UserCreated
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}