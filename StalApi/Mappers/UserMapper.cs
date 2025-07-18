using StalApi.Dtos.User;
using StalApi.Models;
using System.Runtime.CompilerServices;

namespace StalApi.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userDto)
        {
            return new UserDto
            {
                Id = userDto.Id,
                email = userDto.email,
                Role = userDto.Role.ToString()
            };
        }
        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                email = userDto.email,
                Role = userDto.Role,
                password = userDto.password
            };
        }
    }
}
