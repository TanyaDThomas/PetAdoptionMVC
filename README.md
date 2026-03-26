# Forever Home Rescue Network
### A Pet Adoption Management System built with ASP.NET Core MVC

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-blue)
![EF Core](https://img.shields.io/badge/EF%20Core-SQL%20Server-orange)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-purple)
![Status](https://img.shields.io/badge/Status-In%20Development-yellow)

---

## About This Project

Forever Home Rescue Network is a full-stack pet adoption management system built with ASP.NET Core MVC. It is designed to manage the complete lifecycle of a pet adoption, from animal intake and adopter registration through to adoption processing, payments, and post-adoption notes and warnings.

This project is being built as a portfolio piece while learning ASP.NET Core MVC, Entity Framework Core, and SQL Server. It is intentionally scoped to grow over time as new skills are learned, including Identity/authentication, JavaScript, and React.

---

## Screenshots

### Animal List
![Animal List](Screenshots/AnimalsList.png)

### Animal Details
![Animal Details](Screenshots/AnimalDetails.png)

### Edit Animal
![Edit Animal](Screenshots/AnimalEdit.png)

---

## Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Frontend | Razor Views, Bootstrap 5 |
| Architecture | MVC with Service Layer and Repository Pattern |
| Version Control | Git / GitHub |

---

## Architecture

The project follows a clean layered architecture:

- **Models** — Pure data classes representing database entities
- **ViewModels** — Shaped data objects for passing between controllers and views
- **Contracts** — Interface definitions (read/write split per service)
- **Services** — Business logic and database operations
- **Controllers** — HTTP request handling and orchestration
- **Views** — Razor pages for the user interface

Services are split into query (read) and command (write) interfaces, keeping responsibilities clean and making the codebase easier to maintain and test.

### ViewModel Philosophy

Every View has a dedicated ViewModel. Rather than passing model objects directly to Views or using ViewBag for display data, each page has a purpose-built ViewModel that contains exactly what that page needs — no more, no less. This keeps Views decoupled from the database layer and makes the codebase easier to maintain as it grows.

Where multiple pages share common data, base ViewModels are used with inheritance. For example, `AnimalDetailsViewModel` is a base class that all animal type detail ViewModels inherit from, ensuring the embedded notes section is consistently available across all animal types without code duplication.

---

## Features

### Animals
- Full animal management with inheritance-based type system
- Supported types: Dogs, Cats, Birds, Fish, Reptiles, Small Animals, Farm Animals, Exotic Animals
- Each animal type has type-specific attributes (breed for dogs/cats, species for reptiles etc.)
- Active/inactive status with soft delete pattern
- Adoption status tracking (IsAdopted flag)
- Embedded notes section on each animal detail page

### Adopters
- Full adopter registration and management
- Search and filter by name, phone, email, city, state
- Household information tracking (children, other pets)
- Adoption history per adopter

### Adoptions
- Complete adoption workflow from creation to completion
- Multi-step adoption creation with adopter and animal selection
- Automatic adoption fee population from animal record
- Adoption status management (Pending, Approved, Returned etc.)
- Automatic animal status update on adoption and return
- Return count tracking per animal and adopter
- Advanced search and filtering
- Soft deactivation preserving historical records

### Notes
- Full notes system supporting both Animal and Adopter records
- Polymorphic association — one Note class serves both entity types using EntityType and EntityId
- Notes categorized by type: Medical, Behavior, Vaccination, Training, Special Care, Special Diet, Internal, General, Adoption Flag
- Internal flag for staff-only notes
- Recent notes (latest 3) embedded on animal and adopter detail pages
- Standalone notes index with filtering by entity, category, date range, and created by
- View All Notes link from detail pages filters to that specific entity's notes
- Soft deactivation preserving note history
- CreatedBy and UpdatedBy audit fields (currently "System", will be wired to Identity)

### Payments
- Fully implemented payment module with service layer abstraction
- Mock payment processor designed to be replaceable with Stripe or another provider
- Supports multiple payment types (Card, Cash, Check, PayPal)
- Tracks payment status (Pending, Completed, Failed, Refunded, Voided)
- Failure handling with user-facing messages
- Receipt and transaction tracking
- Supports adoption payments, donations, and general services
- Designed to separate payment processing logic from controller logic

### Dashboard & Layout
- Professional responsive dashboard layout (coming soon)
- Custom branding — Forever Home Rescue Network
- Collapsible sidebar navigation with mobile hamburger menu
- Flyout submenu for animal type navigation
- Role-based navigation ready (pending Identity implementation)

---

## Project Structure

```
PetAdoptionMVC/
├── Contracts/              # Interface definitions (read/write split)
│   ├── IAnimalService.cs
│   ├── IAdopterService.cs
│   ├── IAdoptionService.cs
│   ├── INoteService.cs
│   └── ...
├── Controllers/            # HTTP request handling
│   ├── AnimalController.cs
│   ├── AdopterController.cs
│   ├── AdoptionController.cs
│   ├── NoteController.cs
│   └── ...
├── Data/                   # DbContext and database configuration
│   └── PetAdoptionDbContext.cs
├── Models/                 # Data classes
│   ├── Animal.cs
│   ├── Adopter.cs
│   ├── Adoption.cs
│   ├── Note.cs
│   └── Enums/              # Enum definitions
│       ├── AnimalType.cs
│       ├── AdoptionStatus.cs
│       ├── NoteCategory.cs
│       ├── NoteEntityType.cs
│       └── ...
├── SearchFilters/          # Search filter classes
│   ├── AdopterSearchFilter.cs
│   ├── AdoptionSearchFilter.cs
│   ├── AnimalSearchFilter.cs
│   ├── NoteSearchFilter.cs
│   └── ...
├── Services/               # Business logic and database operations
│   ├── AnimalService.cs
│   ├── AdopterService.cs
│   ├── AdoptionService.cs
│   ├── NoteService.cs
│   └── ...
├── ViewModels/             # View data objects (one per View)
│   ├── AdoptionCreateViewModel.cs
│   ├── AdoptionEditViewModel.cs
│   ├── AnimalDetailsViewModel.cs  # Base class for all animal detail ViewModels
│   ├── DogDetailsViewModel.cs     # Inherits from AnimalDetailsViewModel
│   ├── NoteCreateViewModel.cs
│   ├── NoteEditViewModel.cs
│   ├── NoteIndexViewModel.cs
│   ├── NoteDetailsViewModel.cs
│   └── ...
├── Views/                  # Razor pages
│   ├── Adoption/
│   ├── Adopter/
│   ├── Animal/
│   ├── Note/
│   └── Shared/
│       ├── _Layout.cshtml
│       └── ...
├── Screenshots/            # Project screenshots for README
└── wwwroot/                # Static assets
    └── css/
        └── forever-home.css
```

---

## Current Development Status

### Completed
- [x] Animal module (all types with inheritance)
- [x] Adopter module (full CRUD with search and filtering)
- [x] Adoption module (full CRUD with business logic)
- [x] Notes module (full CRUD, embedded on animal detail pages, standalone index with filtering)
- [x] Payment module with mock processor and failure handling
- [x] Professional responsive dashboard layout
- [x] Custom CSS design system (Forever Home brand)
- [x] Mobile responsive sidebar with hamburger menu
- [x] Flyout submenu navigation

### In Progress
- [ ] Warnings module
- [ ] Identity & Roles
- [ ] Add CreatedOn, CreatedBy, UpdatedOn, UpdatedBy, and IsActive to base class
- [ ] May add payments notes to note system (haven't decided yet)

---

## Architectural Decisions

### ViewModels Over ViewBag

During development of the Notes embedded section on animal detail pages, a deliberate decision was made to refactor the animal detail controllers to use proper ViewModels rather than using ViewBag to pass notes data to the Views.

ViewBag would have been the quicker solution — a single line per controller action would have passed the notes list without any structural changes. However ViewBag is not strongly typed, offers no IntelliSense support, and makes the code harder to maintain as the project grows.

Instead a base `AnimalDetailsViewModel` was created that all animal type detail ViewModels inherit from. This ensures every animal detail page automatically has access to RecentNotes, ReturnUrl, and EntityType through inheritance, with no code duplication. The Dog detail page was refactored first to establish the pattern, and the remaining animal types will follow.

This decision adds short term work but results in a more maintainable, type-safe codebase — the right choice for a project intended to grow significantly over time.

### Polymorphic Notes Association

Notes use a polymorphic association pattern — a single Note class serves both Animal and Adopter records using `EntityType` (an enum) and `EntityId` (an integer) rather than separate foreign keys for each entity type. This keeps the Notes table clean and makes it straightforward to extend notes to additional entity types in the future without schema changes.

The tradeoff is that queries always require both EntityType and EntityId together — searching by EntityId alone would return notes from multiple entity types, which would be incorrect. This constraint is enforced throughout the service layer.

### Payment Abstraction

The payment system uses a processor abstraction. This allows the current mock implementation to be replaced with a real provider such as Stripe without changing controller logic.

---

## Roadmap

### Phase 2 — Core Business Logic (Next)
- Complete Notes embedded section for remaining animal types
- Warnings system (adopter flags, animal flags, compatibility checks, auto-generation on adoption creation)
- Payment processing module

### Phase 3 — Authentication and Authorization
- ASP.NET Core Identity implementation
- Role based access control
  - Owner — full system access
  - Manager — location management, reports, staff scheduling
  - Staff — adoption processing, animal management
  - Volunteer — schedule viewing, task management
- CreatedBy / UpdatedBy fields wired to logged in user
- Role based navigation (show/hide based on user role)

### Phase 4 — JavaScript Enhancements
- Adoption Create: AnimalType dropdown filters Animal dropdown dynamically
- Adoption Create: Adoption fee auto-populates when animal is selected
- Adoption Create: Replace dropdowns with inline search modal for adopter and animal selection
- Notes: Collapsible note cards on detail pages showing category and count
- Dynamic search across all modules

### Phase 5 — Expanded Features
- Multiple location support
  - Animals assigned to locations
  - Staff assigned to locations
  - Managers oversee specific locations
- Volunteer portal
  - Schedule viewing and management
  - Task assignments
  - Messaging system
- Manager features
  - Staff scheduling
  - Location reports
  - Performance metrics
- Reporting and analytics dashboard

### Phase 6 — Public Facing Website
- Separate public website pulling available animals
- Location based animal browsing
- Online adoption inquiry submission
- Online donation payments (mock)
- React frontend (planned)

---

## Known Limitations

### Pending JavaScript Implementation
- Adoption Create: Animal dropdown does not filter by selected AnimalType. Planned for JavaScript phase.
- Adoption Create: Adoption fee does not auto-populate when animal is selected from dropdown. Planned for JavaScript AJAX implementation.
- Adoption Create/Edit: Dropdown selection will be replaced with inline search modal once JavaScript is learned.
- Notes: Detail pages currently show full note content. Collapsible cards planned for JavaScript phase.

### Pending Identity Implementation
- CreatedBy and UpdatedBy fields currently default to "System" placeholder
- All navigation is currently visible regardless of role
- No authentication on any routes

### Planned Refactoring
- Animal and Adopter modules currently pass model objects directly to some Views rather than using dedicated ViewModels. Will be refactored for consistency once core modules are complete.
- Animal navigation property missing from Adoption model — requires extra database queries in some controller actions. Will be added in a future migration.

---

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Setup
1. Clone the repository
```bash
git clone https://github.com/TanyaDThomas/PetAdoptionMVC.git
```

2. Update the connection string in `appsettings.json`
```json
"ConnectionStrings": {
  "DefaultConnection": "your-connection-string-here"
}
```

3. Run migrations
```bash
dotnet ef database update
```

4. Run the project
```bash
dotnet run
```

---

## Learning Notes

This project is being built while learning ASP.NET Core MVC. Some architectural decisions reflect the learning process and will be improved over time. Areas planned for refactoring include:

- Adding Animal navigation property to Adoption model to simplify queries
- Implementing proper unit tests once testing patterns are learned
- Adding FluentValidation for model validation
- Implementing proper error handling and logging
- Completing ViewModel refactor for Animal and Adopter modules

---

## Author

**Tanya Thomas**
- GitHub: [@TanyaDThomas](https://github.com/TanyaDThomas)

---

*This project is part of a portfolio being built while learning full-stack .NET development. It is actively developed and expanded as new skills are acquired.*
