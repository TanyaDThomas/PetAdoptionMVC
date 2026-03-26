using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.ViewModels;

namespace PetAdoptionMVC.Controllers
{
    public class ReptileController : Controller
    {
        private readonly IAnimalQueryService _queryService;
        private readonly IAnimalService _animalService;
        private readonly INoteQueryService _noteQueryService;

        public ReptileController(IAnimalQueryService queryService, IAnimalService animalService, INoteQueryService noteQueryService )
        {
            _queryService = queryService;
            _animalService = animalService;
            _noteQueryService = noteQueryService;
        }

        public async Task<IActionResult> Index()
        {
            var animals = await _queryService.GetByTypeAsync(Models.Enums.AnimalType.Reptile);
            var reptiles = animals.OfType<Reptile>();
            ViewBag.ReturnUrl = "/Reptile";
            return View(reptiles);
        }

        //GET Details Reptile 4
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);

            var reptile = animal as Reptile;
            if (reptile == null) return NotFound();

            var viewModel = new ReptileDetailsViewModel
            {
                Reptile = reptile,
                ReturnUrl = returnUrl ?? "/Reptile",
                RecentNotes = await _noteQueryService.GetRecentByEntityAsync(NoteEntityType.Animal, id, 3)
            };

            ViewBag.ReturnUrl = returnUrl ?? "/Reptile";
            return View(viewModel);
        }

        //GET Create Reptile
        public IActionResult Create()
        {
            return View();
        }

        //POST Create reptile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reptile reptile)
        {
            if(ModelState.IsValid)
            {
                reptile.AnimalType = AnimalType.Reptile;
                await _animalService.CreateAnimalAsync(reptile);
                return RedirectToAction("Index");
            }
            return View(reptile);
        }

        //GET Edit Reptile 4
        public async Task<IActionResult> Edit(int id, string? returnUrl = null)
        {
            var animal = await _queryService.GetByIdAsync(id);
            var reptile = animal as Reptile;
            if(reptile == null) return NotFound();
            ViewBag.ReturnUrl = returnUrl = "/Reptile";
            return View(reptile);
        }

        //POST Edit Reptile 4
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Reptile reptile)
        {
            if (ModelState.IsValid)
            {
                reptile.AnimalType = AnimalType.Reptile;
                await _animalService.UpdateAsync(reptile);
                return RedirectToAction("Index");
            }
            return View(reptile);
        }


        //POST Deactive Reptile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _animalService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }

    }
}
