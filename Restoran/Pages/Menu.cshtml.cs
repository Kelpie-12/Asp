using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restoran.Models;
using Restoran.Services;

namespace Restoran.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IMenuItemServices _menuItem;

        public List<MenuItem> MenuModels { get; private set; }
        public MenuModel(IMenuItemServices menu)
        {
            _menuItem = menu;
        }
        public void OnGet()
        {
            MenuModels = _menuItem.GetMenuItems();
        }
    }
}
