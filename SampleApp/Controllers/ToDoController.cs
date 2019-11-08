using BIF4DotNetDemo.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BIF4DotNetDemo.Controllers
{
    [Route("api/todos")]
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext dbContext;

        public ToDoController(ToDoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateToDoItem([FromBody] ToDoItem toDoItem)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            toDoItem.Id = 0;
            dbContext.ToDoItems.Add(toDoItem);

            var claims = User.Claims;
            toDoItem.UserSubject = claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            toDoItem.Email = claims.FirstOrDefault(c => c.Type == "email")?.Value;
            toDoItem.Name = claims.FirstOrDefault(c => c.Type == "name")?.Value;

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<List<ToDoItem>> ListToDoItems()
        {
            var items = await dbContext.ToDoItems.ToListAsync();
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ToDoItem> GetToDoItem(int id)
        {
            return await dbContext.ToDoItems.FindAsync(id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await dbContext.ToDoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            dbContext.ToDoItems.Remove(item);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}