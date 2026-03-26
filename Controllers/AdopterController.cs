using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using PetAdoptionMVC.ViewModels;

namespace PetAdoptionMVC.Controllers
{
    public class AdopterController : Controller
    {
        private readonly IAdopterQueryService _queryService;
        private readonly IAdopterService _adopterService;
        private readonly INoteQueryService _noteQueryService;

        public AdopterController(IAdopterQueryService queryService, IAdopterService adopterService, INoteQueryService noteQueryService)
        {
            _queryService = queryService;
            _adopterService = adopterService;
            _noteQueryService = noteQueryService;
        }

        public async Task<IActionResult> Index()
        {
            var adopters = await _queryService.GetAllAsync();
            return View(adopters);
        }

        //GET Details Adopter 3
        public async Task<IActionResult> Details(int id, string? returnUrl = null)
        {
            var adopter = await _queryService.GetByIdAsync(id);
            if (adopter == null) return NotFound();

            var viewModel = new AdopterDetailsViewModel
            {
                Adopter = adopter,
                ReturnUrl = returnUrl ?? "/Adopter",
                RecentNotes = await _noteQueryService
                    .GetRecentByEntityAsync(NoteEntityType.Adopter, id, 3)
             };

            return View(viewModel);
        }

        //GET Create Adopter
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Adopter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adopter adopter)
        {
            if(ModelState.IsValid)
            {
                await _adopterService.CreateAsync(adopter);
                return RedirectToAction("Index");
            }
            return View(adopter);
        }

        //GET Edit Adopter 2
        public async Task<IActionResult> Edit(int id)
        {
            var adopter = await _queryService.GetByIdAsync(id);
            if (adopter == null) return NotFound();
            return View(adopter);
        }

        //POST Edit Adopter 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Adopter adopter)
        {
            if(ModelState.IsValid)
            {
                await _adopterService.UpdateAsync(adopter);
                return RedirectToAction("Index");
            }
            return View(adopter);
        }

        //POST Deactivate Adopter 3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _adopterService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }

        //GET Select Adopter 4

        public async Task<IActionResult> Select(string? name = null, string? returnUrl = null)
        {
            // Don't load anyone until staff searches
            var adopters = new List<Adopter>();

            if (!string.IsNullOrEmpty(name))
            {
                adopters = (await _queryService.SearchAsync(
                    new AdopterSearchFilter { Name = name })).ToList();
            }

            ViewBag.ReturnUrl = returnUrl;
            ViewBag.SearchName = name;
            return View(adopters);
        }

    }
}
