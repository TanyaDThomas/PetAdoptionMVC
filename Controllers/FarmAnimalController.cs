using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;


namespace PetAdoptionMVC.Controllers
{
    public class FarmAnimalController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;

        public FarmAnimalController(IAnimalQueryService queryService, IAnimalService animalService)
        {
            _queryService = queryService;
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(AnimalType.FarmAnimal);
            var farmAnimals = animals.OfType<FarmAnimal>();
            ViewBag.ReturnUrl = "/FarmAnimal";
            return View(farmAnimals);
        }

        //GET farm animal 5
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var farmAnimal = animal as FarmAnimal;
            if (farmAnimal == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/FarmAnimal";
            return View(farmAnimal);
        }

        //GET Create farm animal form
        public IActionResult Create()
        {
            return View();
        }

        //POST Create farm animal submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FarmAnimal farmAnimal)
        {
            if (ModelState.IsValid)
            {
                farmAnimal.AnimalType = AnimalType.FarmAnimal;
                await _animalService.CreateAnimalAsync(farmAnimal);
                return RedirectToAction("Index");
            }
            return View(farmAnimal);
        }

        //GET Edit farm animal 
        public async Task<IActionResult> Edit(int id, string? returnUrl= null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var farmAnimal = animal as FarmAnimal;
            if (farmAnimal == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/FarmAnimal";
            return View(farmAnimal);
        }

        //POST Edit animal 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FarmAnimal farmAnimal)
        {
            if (ModelState.IsValid)
            {
                farmAnimal.AnimalType = AnimalType.FarmAnimal;
                await _animalService.UpdateAsync(farmAnimal);
                return RedirectToAction("Index");

            }
            return View(farmAnimal);
        }

        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }
        
    }
}
