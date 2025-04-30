using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restoran.Models;
using Restoran.Services;

namespace Restoran.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeesServices _employeesServices;

        public List<Employe> Employes { get; private set; }
        public EmployeesModel(IEmployeesServices employeesServices)
        {
            _employeesServices = employeesServices;
        }
        public void OnGet()
        {
            Employes = _employeesServices.GetEmployes();
        }
    }
}
