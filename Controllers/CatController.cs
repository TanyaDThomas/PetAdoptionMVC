using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.ViewModels;

namespace PetAdoptionMVC.Controllers
{
    public class CatController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;
        private readonly INoteQueryService _noteQueryService;

        public CatController(IAnimalQueryService queryService, IAnimalService animalService, INoteQueryService noteQueryService)
        {
            _queryService = queryService;
            _animalService = animalService;
            _noteQueryService = noteQueryService;
        }

        //GET Cat
        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(AnimalType.Cat);
            var cats = animals.OfType<Cat>();
            ViewBag.ReturnUrl = "/Cat";
            return View(cats);
        }

        //GET Cat  details 5

        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            var cat = animal as Cat;
            if (cat == null) return NotFound();

            var viewModel = new CatDetailsViewModel
            {
                Cat = cat,
                ReturnUrl = returnUrl ?? "/Cat",
                RecentNotes = await _noteQueryService
                    .GetRecentByEntityAsync(NoteEntityType.Animal, id, 3)
            };


            return View(viewModel);

        }

        //GET Cat Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Cat Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cat cat)
        {
            if(ModelState.IsValid)
            {
                cat.AnimalType = AnimalType.Cat;
                await _animalService.CreateAnimalAsync(cat);
                return RedirectToAction("Index");
            }
            return View(cat);
        }

        // GET cat Edit 5
        public async Task<IActionResult> Edit(int id, string? returnUrl=null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            if (animal == null) return NotFound();
            var cat = animal as Cat;
            if (cat == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl ?? "/Cat";
            return View(cat);
        
        }

        //POST edit cat 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cat cat)
        {
            if(ModelState.IsValid)
            {
                cat.AnimalType = AnimalType.Cat;
                await _animalService.UpdateAsync(cat);
                return RedirectToAction("Index");
            }
            return View(cat);
        }


        //POST Deactivate Cat 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }

    }
}
