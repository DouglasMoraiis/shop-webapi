using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

namespace Backoffice.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var employee = new User { Id = 1, Username = "Doug", Password = "123", Role = "employee" };
            var manager = new User { Id = 2, Username = "Jan", Password = "123", Role = "manager" };
            var category = new Category { Id = 1, Title = "Comida"};
            var product = new Product { Id = 1, Title = "Feijao", Price = 200, Description = "É bom demais", Category = category};
            context.Users.Add(employee);
            context.Users.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados configurados"
            });
        }
    }
}