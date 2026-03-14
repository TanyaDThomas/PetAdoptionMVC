using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Controllers
{

    public class FishController : Controller
    {

        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;

        public FishController(IAnimalQueryService queryService, IAnimalService animalService)
        {
            _queryService = queryService;
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(Models.Enums.AnimalType.Fish);
            var fishes = animals.OfType<Fish>();
            ViewBag.ReturnUrl = "/Fish";
            return View(fishes);
        }


        // GET Details Fish 5
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var fish = animal as Fish;
            if (fish == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/Fish";
            return View(fish);

        }

        //GET Create Fish 
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Fish 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fish fish)
        {
            if(ModelState.IsValid)
            {
                fish.AnimalType = AnimalType.Fish;
                await _animalService.CreateAnimalAsync(fish);
                return RedirectToAction("Index");
            }
            return View(fish);
        }

        //GET Edit Fish
        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var fish = animal as Fish;
            if (fish == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/Fish";
            return View(fish);
        }

        //POST Edit Fish
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Fish fish)
        {
            if(ModelState.IsValid)
            {
                fish.AnimalType = AnimalType.Fish;
                await _animalService.UpdateAsync(fish);
                return RedirectToAction("Index");
            }
            return View(fish);
        }

        //GET Deactivate fish
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");

        }

    }
}
