using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.ViewModels;

namespace PetAdoptionMVC.Controllers
{
    public class DogController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;
        private readonly INoteQueryService _noteQueryService;
        public DogController(IAnimalQueryService queryService, IAnimalService animalService, INoteQueryService noteQueryService )
        {
            _queryService = queryService;
            _animalService = animalService;
            _noteQueryService = noteQueryService;
        }

        //GET Dog
        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(AnimalType.Dog);
            var dogs = animals.OfType<Dog>();
            ViewBag.ReturnUrl = "/Dog";
            return View(dogs);
        }


        //GET Dog details 5
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if(animal == null)
            {
                return NotFound();
            }
            var dog = animal as Dog;
            if (dog == null) return NotFound();

            var viewModel = new DogDetailsViewModel
            {
                Dog = dog,
                ReturnUrl = returnUrl ?? "/Dog",
                RecentNotes = await _noteQueryService
                    .GetRecentByEntityAsync(NoteEntityType.Animal, id, 3)
            };

          
            return View(viewModel);

        }

        // GET: /Dog/Create
        public IActionResult Create()
        {
            return View();
        }


        //POST dog Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                dog.AnimalType = AnimalType.Dog;
                await _animalService.CreateAnimalAsync(dog);
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        // GET dog Edit 5
        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if (animal == null) return NotFound();
            var dog = animal as Dog;
            if (dog == null) NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/Dog";
            return View(dog);
        }

        //POST dog Edit 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Dog dog)
        {
            if(ModelState.IsValid)
            {
                dog.AnimalType = AnimalType.Dog;
                await _animalService.UpdateAsync(dog);
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        //POST Deactivate Dog 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }

    }
}
