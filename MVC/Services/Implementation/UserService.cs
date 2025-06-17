﻿using MVC.Data;
using MVC.Data.Models;
using MVC.Model.DTO;

namespace MVC.Services.Implementation
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDbContext _database;
        private readonly IJwtServices _jwtServices;

        public UserService(ApplicationDbContext database, IJwtServices jwtServices)
        {
            _database = database;
            _jwtServices = jwtServices;
        }

        public User? GetUserById(long id)
        {
            return _database.User.FirstOrDefault();
        }

        public string Login(UserDTO userDTO)
        {
            var user = _database.User.Where(e => e.Email == userDTO.Email && e.Password == userDTO.Password);

            if (user != null)
            {
                return _jwtServices.GenerateToken(userDTO);
            }
            throw new Exception("ошибка ввода неверного пароля");

        }

        public void RegisterUser(UserDTO userDTO)
        {
            if (userDTO.Email == null)
                throw new ArgumentNullException("User email is not specified");

            if (userDTO.FirstName == null)
                throw new ArgumentNullException("User first name is not specified");

            if (userDTO.Password == null)
                throw new ArgumentNullException("User password is not specified");

            User user = new User()
            {
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Password = userDTO.Password
            };

            _database.User.Add(user);
            _database.SaveChanges();
        }
    }
}
