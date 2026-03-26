using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.ViewModels;

namespace PetAdoptionMVC.Controllers
{
    public class BirdController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;
        private readonly INoteQueryService _noteQueryService;

        public BirdController(IAnimalQueryService queryService, IAnimalService animalService, INoteQueryService noteQueryService)
        {
            _queryService = queryService;   
            _animalService = animalService;
            _noteQueryService = noteQueryService;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(AnimalType.Bird);
            var birds = animals.OfType<Bird>();
            ViewBag.ReturnUrl = "/Bird";

            return View(birds);
        }


        // GET Details Bird 5
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if (animal == null) return NotFound();

            var bird = animal as Bird;
            if (bird == null) return NotFound();

            var viewModel = new BirdDetailsViewModel
            {
                Bird = bird,
                ReturnUrl = returnUrl ?? "/Bird",
                RecentNotes = await _noteQueryService
                    .GetRecentByEntityAsync(NoteEntityType.Animal, id, 3)
            };

            return View(viewModel);
        }

        //GET Create Bird
        public IActionResult Create()
        {
            return View();
        }

        //POST Create bird
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bird bird)
        {
            if(ModelState.IsValid)
            {
                bird.AnimalType = AnimalType.Bird;
                await _animalService.CreateAnimalAsync(bird);
                return RedirectToAction("Index");
            }
            return View(bird);
        }

        //GET Edit Bird 5
        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var bird = animal as Bird;
            if (bird == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/Bird";
            return View(bird);
        }

        //POST Edit Bird 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Bird bird)
        {
            if (ModelState.IsValid)
            {
                bird.AnimalType = AnimalType.Bird;
                await _animalService.UpdateAsync(bird);
                return RedirectToAction("Index");
            }
            return View(bird);
        }

        //POST Bird 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }


    }

}
