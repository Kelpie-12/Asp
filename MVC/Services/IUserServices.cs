using MVC.Data.Models;
using MVC.Model.DTO;

namespace MVC.Services
{
    public interface IUserServices
    {
        public User? GetUserById(long id);
        public void RegisterUser(UserDTO userDTO);
        public string Login(UserDTO userDTO);
    }
}
