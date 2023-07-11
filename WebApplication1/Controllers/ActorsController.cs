using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
			_service = service;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _service.getAllAsync());
        }

        //Get: Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName, ProfilePicUrl, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));

        }

        //get Actors Details
        public async Task<IActionResult> Detail(int id)
        {
            var actorDetails = await _service.getByIdAsync(id);

            if (actorDetails == null)
                return View("Not Found");
            return View(actorDetails);
        }


        //Get & Edit Actor
		public async Task<IActionResult> Edit(int id)
		{
			var actorDetails = await _service.getByIdAsync(id);

			if (actorDetails == null)
				return View("Not Found");
			return View(actorDetails);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("FullName, ProfilePicUrl, Bio")] Actor actor)
		{
			if (!ModelState.IsValid)
			{
				return View(actor);  
			}
			actor.Id = id;
			await _service.UpdateAsync(id, actor);
			return RedirectToAction(nameof(Index));

		}

		//Get & Delete Actor
		public async Task<IActionResult> Delete(int id)
		{
			var actorDetails = await _service.getByIdAsync(id);

			if (actorDetails == null)
				return View("Not Found");
			return View(actorDetails);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var actorDetails = await _service.getByIdAsync(id);
			if (actorDetails == null)
				return View("Not Found");
	
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));

		}
	}
}
