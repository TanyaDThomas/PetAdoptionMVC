using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using PetAdoptionMVC.Services;
using PetAdoptionMVC.ViewModels;
using PetAdoptionsMVC.Service;

namespace PetAdoptionMVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteQueryService _queryService;
        private readonly INoteService _noteService;
        private readonly IAdopterQueryService _adopterQueryService;
        private readonly IAnimalQueryService _animalQueryService;

        public NoteController(INoteQueryService queryService, INoteService noteService, IAdopterQueryService adopterQueryService, IAnimalQueryService animalQueryService)
        {
            _queryService = queryService;
            _noteService = noteService;
            _adopterQueryService = adopterQueryService;
            _animalQueryService = animalQueryService;
        }
        public async Task<IActionResult> Index()
        {
            var notes = await _queryService.GetAllAsync();

            var viewModels = new List<NoteIndexViewModel>();

            foreach (var note in notes)
            {
                string entityName = "";

                if (note.EntityType == NoteEntityType.Animal)
                {
                    var animal = await _animalQueryService.GetByIdAsync(note.EntityId);
                    if (animal != null)
                        entityName = animal.Name;
                    else
                        entityName = "Unknown";
                }
                else
                {
                    var adopter = await _adopterQueryService.GetByIdAsync(note.EntityId);
                    if (adopter != null)
                        entityName = $"{adopter.FirstName} {adopter.LastName}";
                    else
                        entityName = "Unknown";
                }

                string contentPreview;
                if (note.Content.Length > 100)
                    contentPreview = note.Content.Substring(0, 100) + "...";
                else
                    contentPreview = note.Content;

                viewModels.Add(new NoteIndexViewModel
                {
                    Id = note.Id,
                    EntityDisplayName = entityName,
                    EntityType = note.EntityType,
                    Category = note.Category,
                    ContentPreview = contentPreview,
                    CreatedOn = note.CreatedOn,
                    CreatedBy = note.CreatedBy,
                    IsInternal = note.IsInternal
                });
            }
            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var note = await _queryService.GetByIdAsync(id);
            if (note == null) return NotFound();
            return View(note);
        }

        //GET Create Note
        public async Task<IActionResult> Create(NoteEntityType entityType, int entityId)
        {
            var viewModel = new NoteCreateViewModel
            {
                EntityType = entityType,
                EntityId = entityId,
            };

            if (entityType == NoteEntityType.Animal)
            {
                var animal = await _animalQueryService.GetByIdAsync(entityId);
                viewModel.EntityDisplayName = animal?.Name;
            }
            else
            {
                var adopter = await _adopterQueryService.GetByIdAsync(entityId);
                viewModel.EntityDisplayName = $"{adopter?.FirstName} {adopter?.LastName}";
            }

                        return View(viewModel);
        }

        //POST Create Note
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NoteCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var note = new Note
                {
                    EntityType = viewModel.EntityType,
                    EntityId = viewModel.EntityId,
                    Category = viewModel.Category,
                    Content = viewModel.Content,
                    IsInternal = viewModel.IsInternal
                };

                await _noteService.CreateAsync(note);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //GET Edit Note 5
        public async Task<IActionResult> Edit(int id)
        {
            var note = await _queryService.GetByIdAsync(id);
            if (note == null) return NotFound();

            var viewModel = new NoteEditViewModel
            {
                Id = id,
                Category = note.Category,
                Content = note.Content,
                IsInternal = note.IsInternal
            };

            return View(viewModel);
        }

        //POST Edit Note 6
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NoteEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var note = await _queryService.GetByIdAsync(viewModel.Id);
                if (note == null) return NotFound();

                note.Category = viewModel.Category;
                note.Content = viewModel.Content;
                note.IsInternal = viewModel.IsInternal;
                
                await _noteService.UpdateAsync(note);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        //GET Deactivate Note 6
        public async Task<IActionResult> Deactivate(int id)
        {
            await _noteService.DeactivateAsync(id);
            return RedirectToAction("Index");
        }
    }
}
