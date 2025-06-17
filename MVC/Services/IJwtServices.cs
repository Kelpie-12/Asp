using MVC.Model.DTO;

namespace MVC.Services
{
    public interface IJwtServices
    {
        public string GenerateToken(UserDTO user);
    }
}
