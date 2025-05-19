using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodosController : Controller
    {
        private readonly AppDbContext _context;

        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string status)
        {
            var todos = from t in _context.Todos select t;
            if (!string.IsNullOrEmpty(status) && Enum.TryParse<TodoStatus>(status, ignoreCase: true, out var parsedStatus))
            {
                todos = todos.Where(t => t.Status == parsedStatus);
            }
            ViewBag.StatusFilter = status;
            return View(await todos.ToListAsync());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Todo todo)
        {
            //if (ModelState.IsValid)
            //{
                todo.Id = Guid.NewGuid();
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(todo);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            return todo == null ? NotFound() : View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Todo todo)
        {
            if (id != todo.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var todo = await _context.Todos.FindAsync(id);
        //    return todo == null ? NotFound() : View(todo);
        //}


        public async Task<IActionResult> Delete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> MarkAsCompleted(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return NotFound();
            todo.Status = TodoStatus.Completed;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}