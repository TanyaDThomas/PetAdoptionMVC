using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;


namespace PetAdoptionMVC.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalQueryService queryService,
            IAnimalService animalService)
        {
            _queryService = queryService;
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetAllAsync();
            return View(animals);

        }

        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if (animal == null) return NotFound();

            return animal.AnimalType switch
            {
                AnimalType.Dog => RedirectToAction("Details", "Dog",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Cat => RedirectToAction("Details", "Cat",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Bird => RedirectToAction("Details", "Bird",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Fish => RedirectToAction("Details", "Fish",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Reptile => RedirectToAction("Details", "Reptile",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.SmallAnimal => RedirectToAction("Details", "SmallAnimal",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.FarmAnimal => RedirectToAction("Details", "FarmAnimal",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.ExoticAnimal => RedirectToAction("Details", "ExoticAnimal",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                _ => NotFound()
            };
        }

        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if (animal == null) return NotFound();

            return animal.AnimalType switch
            {
                AnimalType.Dog => RedirectToAction("Edit", "Dog",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Cat => RedirectToAction("Edit", "Cat",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Bird => RedirectToAction("Edit", "Bird",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Fish => RedirectToAction("Edit", "Fish",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.Reptile => RedirectToAction("Edit", "Reptile",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.SmallAnimal => RedirectToAction("Edit", "SmallAnimal",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.FarmAnimal => RedirectToAction("Edit", "FarmAnimal",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                AnimalType.ExoticAnimal => RedirectToAction("Edit", "ExoticAnimal",
                    new { id, returnUrl = returnUrl ?? "/Animal" }),
                _ => NotFound()
            };
        }

        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }

        //GET Select Animal
        public async Task<IActionResult> Select(string? name = null, AnimalType? type = null)
        {
            var filter = new AnimalSearchFilter
            {
                Name = name,
                Type = type,
                IsAvailable = true
            };

            var animals = string.IsNullOrEmpty(name) && !type.HasValue
                ? await _queryService.GetAllAvailableAsync()
                : await _queryService.SearchAsync(filter);

            return View(animals);

        }


    }
}

