using StalApi.Models;

namespace StalApi.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
