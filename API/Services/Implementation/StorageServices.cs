using API.Data;
using API.Data.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Services.Implementation
{
    public class StorageServices : IStorageServices
    {
        private readonly ApplicationDbContext _database;
        private const int PRODUCTS_PER_PAGE = 10;

        public StorageServices(ApplicationDbContext database)
        {
            _database = database;
        }
        public string GetValue(string key)
        {
            return _database.Storege.Find(key).Value;
        }

        public void SetValue(string key, string value)
        {
            UserData user = new UserData() { Key = key, Value = value };
            _database.Storege.Add(user);
            _database.SaveChanges();

        }
    }
}
