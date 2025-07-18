using StalApi.Models;

namespace StalApi.Dtos.User
{
    public class CreateUserRequestDto
    {
        public string email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string password { get; set; } = string.Empty;
    }
}
