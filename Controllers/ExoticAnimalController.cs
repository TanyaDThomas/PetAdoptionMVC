using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Controllers
{
    public class ExoticAnimalController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;

        public ExoticAnimalController(IAnimalQueryService queryService, IAnimalService animalService)
        {
            _queryService = queryService;
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(AnimalType.ExoticAnimal);
            var exoticAnimals = animals.OfType<ExoticAnimal>();
            ViewBag.ReturnUrl = "/ExoticAnimal";
            return View(exoticAnimals);
        }

        //GET Details ExoticAnimal 5
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var exoticAnimal = animal as ExoticAnimal;
            if (exoticAnimal == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/ExoticAnimal";
            return View(exoticAnimal);
        }

        //GET Create Exotic Animal
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //POST Create Exotic Animal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExoticAnimal exoticAnimal)
        {
            if(ModelState.IsValid)
            {
                exoticAnimal.AnimalType = AnimalType.ExoticAnimal;
                await _animalService.CreateAnimalAsync(exoticAnimal);
                return RedirectToAction("Index");
            }
            return View(exoticAnimal);
        }


        //GET Edit Exotic Animal
        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var exoticAnimal = animal as ExoticAnimal;
            if (exoticAnimal == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/ExoticAnimal";
            return View(exoticAnimal);
        }

        //POST Edit Exotic Animal 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExoticAnimal exoticAnimal)
        {
            if(ModelState.IsValid)
            {
                exoticAnimal.AnimalType = AnimalType.ExoticAnimal;
                await _animalService.UpdateAsync(exoticAnimal);
                return RedirectToAction("Index");
            }
            return View(exoticAnimal);
        }

        //GET Deactivate Exotic Animal
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }
    }
}
