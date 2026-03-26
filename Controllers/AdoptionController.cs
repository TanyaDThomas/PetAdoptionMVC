using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using PetAdoptionMVC.ViewModels;

namespace PetAdoptionMVC.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IAdoptionQueryService _queryService;
        private readonly IAdoptionService _adoptionService;
        private readonly IAdopterQueryService _adopterQueryService;
        private readonly IAnimalQueryService _animalQueryService;
        private readonly IAnimalService _animalService;

        public AdoptionController(
            IAdoptionQueryService queryService,
            IAdoptionService adoptionService,
            IAdopterQueryService adopterQueryService,
            IAnimalQueryService animalQueryService,
            IAnimalService animalService)
        {
            _queryService = queryService;
            _adoptionService = adoptionService;
            _adopterQueryService = adopterQueryService;
            _animalQueryService = animalQueryService;
            _animalService = animalService;
        }

        // GET: /Adoption
        public async Task<IActionResult> Index()
        {
            var adoptions = await _queryService.GetAllAsync();

            // Flatten each adoption into IndexViewModel
            var viewModels = new List<AdoptionIndexViewModel>();

            foreach (var adoption in adoptions)
            {
                var animal = await _animalQueryService
                    .GetByIdAsync(adoption.AnimalId);

                viewModels.Add(new AdoptionIndexViewModel
                {
                    Id = adoption.Id,
                    AdopterFullName = adoption.Adopter != null
                        ? $"{adoption.Adopter.FirstName} {adoption.Adopter.LastName}"
                        : "Unknown",
                    AnimalName = animal?.Name ?? "Unknown",
                    AnimalType = adoption.AnimalType,
                    AdoptionDate = adoption.AdoptionDate,
                    Status = adoption.Status,
                    AdoptionFee = adoption.AdoptionFee
                });
            }

            return View(viewModels);
        }

        // GET: /Adoption/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var adoption = await _queryService.GetByIdAsync(id);
            if (adoption == null) return NotFound();

            var animal = await _animalQueryService
                .GetByIdAsync(adoption.AnimalId);

            var viewModel = new AdoptionDetailsViewModel
            {
                // Adoption fields
                Id = adoption.Id,
                AdoptionDate = adoption.AdoptionDate,
                Status = adoption.Status,
                AdoptionFee = adoption.AdoptionFee,
                AnimalType = adoption.AnimalType,
                IsActive = adoption.IsActive,
                CreatedOn = adoption.CreatedOn,
                CreatedBy = adoption.CreatedBy,
                UpdatedOn = adoption.UpdatedOn,
                UpdatedBy = adoption.UpdatedBy,

                // Adopter fields — flattened
                AdopterId = adoption.AdopterId,
                AdopterFirstName = adoption.Adopter?.FirstName ?? "",
                AdopterLastName = adoption.Adopter?.LastName ?? "",
                AdopterPhone = adoption.Adopter?.PhoneNumber ?? "",
                AdopterEmail = adoption.Adopter?.Email ?? "",
                AdopterCity = adoption.Adopter?.City ?? "",
                AdopterState = adoption.Adopter?.State ?? "",

                // Animal fields — flattened
                AnimalId = adoption.AnimalId,
                AnimalName = animal?.Name ?? "Unknown",
                AnimalAge = animal?.Age ?? 0,
                AnimalColor = animal?.Color ?? ""
            };

            return View(viewModel);
        }

        // GET: /Adoption/Create
        public async Task<IActionResult> Create(int? adopterId = null,
            int? animalId = null)
        {
            var viewModel = new AdoptionCreateViewModel
            {
                AdoptionDate = DateTime.Now,
                Status = AdoptionStatus.Pending
            };

            if (adopterId.HasValue)
            {
                var adopter = await _adopterQueryService
                    .GetByIdAsync(adopterId.Value);
                if (adopter != null)
                {
                    viewModel.AdopterId = adopter.Id;
                    viewModel.AdopterName =
                        $"{adopter.FirstName} {adopter.LastName}";
                }
            }

            if (animalId.HasValue)
            {
                var animal = await _animalQueryService
                    .GetByIdAsync(animalId.Value);
                if (animal != null)
                {
                    viewModel.AnimalId = animal.Id;
                    viewModel.AnimalName = animal.Name;
                    viewModel.AdoptionFee = animal.AdoptionFee;
                    viewModel.AnimalType = animal.AnimalType;
                }
            }

            // For SelectList Dropdown
            var adopters = await _adopterQueryService.GetAllAsync();
            viewModel.AdopterList = new SelectList(
                adopters.Select(a => new { a.Id, FullName = $"{a.FirstName} {a.LastName}" }),
                "Id",
                "FullName"
            );

            viewModel.AnimalTypeList = new SelectList(
                Enum.GetValues(typeof(AnimalType))
                    .Cast<AnimalType>()
                    .Select(a => new { Value = (int)a, Text = a.ToString() }),
                "Value",
                "Text"
            );

            var animals = await _animalQueryService.GetAllAvailableAsync();
            viewModel.AnimalList = new SelectList(
                animals.Select(a => new { a.Id, a.Name }),
                "Id",
                "Name"
            );


            return View(viewModel);
        }

        // POST: /Adoption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdoptionCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Map ViewModel back to Adoption model
                var adoption = new Adoption
                {
                    AdopterId = viewModel.AdopterId!.Value,
                    AnimalId = viewModel.AnimalId!.Value,
                    AdoptionDate = viewModel.AdoptionDate,
                    Status = AdoptionStatus.Pending,
                    AdoptionFee = viewModel.AdoptionFee,
                    AnimalType = viewModel.AnimalType!.Value
                };

                await _adoptionService.CreateAsync(adoption);

                // Mark animal as adopted
                var animal = await _animalQueryService
                    .GetByIdAsync(adoption.AnimalId);
                if (animal != null)
                {
                    animal.IsAdopted = true;
                    await _animalService.UpdateAsync(animal);
                }

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: /Adoption/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var adoption = await _queryService.GetByIdAsync(id);
            if (adoption == null) return NotFound();

            var animal = await _animalQueryService
                .GetByIdAsync(adoption.AnimalId);

            var viewModel = new AdoptionEditViewModel
            {
                Id = adoption.Id,
                AdopterId = adoption.AdopterId,
                AnimalId = adoption.AnimalId,
                AdoptionDate = adoption.AdoptionDate,
                Status = adoption.Status,
                AdoptionFee = adoption.AdoptionFee,
                AnimalType = adoption.AnimalType,
                AdopterName = adoption.Adopter != null
                    ? $"{adoption.Adopter.FirstName} {adoption.Adopter.LastName}"
                    : "Unknown",
                AnimalName = animal?.Name ?? "Unknown"
            };

            return View(viewModel);
        }

        // POST: /Adoption/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdoptionEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Get existing adoption
                var adoption = await _queryService
                    .GetByIdAsync(viewModel.Id);
                if (adoption == null) return NotFound();

                // Only update allowed fields
                adoption.AdoptionDate = viewModel.AdoptionDate;
                adoption.Status = viewModel.Status;
                adoption.AdoptionFee = viewModel.AdoptionFee;
                adoption.UpdatedOn = DateTime.Now;

                // If Returned, mark animal as available 
         
                if (viewModel.Status == AdoptionStatus.Returned)
                {
                    var animal = await _animalQueryService
                        .GetByIdAsync(adoption.AnimalId);
                    if (animal != null)
                    {
                        animal.IsAdopted = false;
                        await _animalService.UpdateAsync(animal);
                    }
                }

                await _adoptionService.UpdateAsync(adoption);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // POST: /Adoption/Deactivate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            await _adoptionService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }
    }
}