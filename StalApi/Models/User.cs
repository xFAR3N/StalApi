using Microsoft.AspNetCore.Identity;

namespace StalApi.Models
{
    public enum UserRole 
    {  
        Client,
        Supplier 
    }
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        //public List<Order> Orders { get; set; } = new();
    }
}
