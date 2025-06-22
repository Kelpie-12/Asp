using API.Data;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageServices _storageServices;
        public StorageController(IStorageServices storageServices)
        {
            _storageServices = storageServices;
        }
        [HttpGet]
        [Route("{key}")]
        public IActionResult? GetValueByKey(string? key)
        {
            // return new UserData() { Key = "Key", Value = "Test" };
            string? value = _storageServices.GetValue(key);
            if (value == null)
            {
                return NotFound();
            }
            return Content(value);
        }
        [HttpPut]
        [Route("{key}")]
        public void PutValueByKey(string key, [FromForm] string value)
        {
            _storageServices.SetValue(key, value);
        }
    }
}
