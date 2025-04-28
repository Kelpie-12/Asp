using Restoran.Models;

namespace Restoran.Services.Implementation
{
    public class MenuItemServices : IMenuItemServices
    {
        public List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>()
            {
                new MenuItem(){Id=1,Name="Краспбургер",Price=12,Desc="Какое-то крутое описание"},
                new MenuItem(){Id=2,Name="Кола",Price=4,Desc="Какое-то крутое описание"}
            };
        }
    }
}
