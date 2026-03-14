using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.Controllers
{
    public class SmallAnimalController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;

        public SmallAnimalController(IAnimalQueryService queryService, IAnimalService animalService)
        {
            _queryService = queryService;
            _animalService = animalService;
        }
        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(Models.Enums.AnimalType.SmallAnimal);
            var smallAnimals = animals.OfType<SmallAnimal>().ToList();
            ViewBag.ReturnUrl = "/SmallAnimal";
            return View(smallAnimals);
        }

        //GET Details Small Animal 4
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var smallAnimal = animal as SmallAnimal;
            if (smallAnimal == null) return NotFound(); 
            ViewBag.ReturnUrl = returnUrl ?? "/SmallAnimal";
            return View(smallAnimal);
        }

        //GET Create Small Animal
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Small Animal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SmallAnimal smallAnimal)
        {
            if(ModelState.IsValid)
            {
                smallAnimal.AnimalType = AnimalType.SmallAnimal;
                await _animalService.CreateAnimalAsync(smallAnimal);
                return RedirectToAction("Index");
            }
            return View(smallAnimal);
        }

        //GET Edit Small Animal 4
        public async Task<IActionResult> Edit(int id, string? returnUrl=null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var smallAnimal = animal as SmallAnimal;
            if(smallAnimal == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/SmallAnimal";
            return View(smallAnimal);
        }

        //POST Edit Small Animal 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SmallAnimal smallAnimal)
        {
            if(ModelState.IsValid)
            {
                smallAnimal.AnimalType = AnimalType.SmallAnimal;
                await _animalService.UpdateAsync(smallAnimal);
                return RedirectToAction("Index");
            }
            return View(smallAnimal);
        }

        //GET Deactivate animal 4
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }
    }
}
