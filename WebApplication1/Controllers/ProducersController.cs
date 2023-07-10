using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDBContext _context;

        public ProducersController(AppDBContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            var allProducers = await _context.Producers.ToListAsync();
            return View(allProducers);
        }
    }
}
