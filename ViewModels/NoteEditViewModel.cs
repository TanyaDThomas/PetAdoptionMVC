using Microsoft.AspNetCore.Mvc.Rendering;
using PetAdoptionMVC.Models.Enums;

namespace PetAdoptionMVC.ViewModels
{
    public class NoteEditViewModel
    {
        public int Id { get; set; }
        public NoteCategory Category { get; set; }
        public string Content { get; set; } = "";
        public bool IsInternal { get; set; } = false;
        public DateTime UpdatedOn { get; set; }

        // Dropdown ENUM Category List
        public IEnumerable<SelectListItem> CategoryOptions =>
           Enum.GetValues<NoteCategory>()
               .Select(c => new SelectListItem
               {
                   Value = c.ToString(),
                   Text = c.ToString()
               });
    }
}
