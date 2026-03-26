
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using PetAdoptionMVC.Services;
using PetAdoptionMVC.ViewModels;


namespace PetAdoptionMVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentQueryService _paymentQueryService;
        public PaymentController(IPaymentService paymentService, IPaymentQueryService paymentQueryService   )
        {
            _paymentService = paymentService;
            _paymentQueryService = paymentQueryService;
        }
  

        public async Task<IActionResult> Index(PaymentSearchFilter filter)
        {
            var payments = await _paymentQueryService.SearchAsync(filter);

            var viewModel = payments.Select(p => new PaymentListViewModel
            {
                Id = p.Id,
                Amount = p.Amount,
                Type = p.Type.ToString(),
                Status = p.Status.ToString(),
                PaymentDate = p.PaymentDate,
                AdopterId = p.AdopterId,
                ReceiptNumber = p.ReceiptNumber
            });

            return View(viewModel);
        }


        // GET: Payment/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentQueryService.GetByIdAsync(id);
            if (payment == null) return NotFound();

            var viewModel = new PaymentDetailsViewModel
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Type = payment.Type,
                Status = payment.Status,
                PaymentDate = payment.PaymentDate,
                AdopterId = payment.AdopterId,
                AdoptionId = payment.AdoptionId,
                Notes = payment.Notes
            };
            return View(viewModel);
        }


        //GET Create Payment
        [HttpGet]
        public IActionResult Create(int? adoptionId = null, int? adopterId = null)
        {
            var viewModel = new PaymentCreateViewModel
            {
                AdoptionId = adoptionId,
                AdopterId = adopterId
            };
            return View(viewModel);
        }

        //POST Create Payment 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            try
            {
                var request = new PaymentRequest
                {
                    Amount = viewModel.Amount,
                    Type = viewModel.Type,
                    AdoptionId = viewModel.AdoptionId,
                    AdopterId = viewModel.AdopterId,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    LastFourDigits = viewModel.LastFourDigits,
                    BankName = viewModel.BankName,
                    CheckNumber = viewModel.CheckNumber,
                    PaypalEmail = viewModel.PaypalEmail,
                    Notes = viewModel.Notes
                };

                var payment = await _paymentService.ProcessPaymentAsync(request);

                if (payment.Status == PaymentStatus.Completed)
                {
                    return RedirectToAction("Details", new { id = payment.Id });
                }

                // If Payment Failed
                ModelState.AddModelError("",
                    payment.FailureReason ?? "Payment failed: Unknown reason");
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",
                    $"An error occurred while processing your payment: {ex.Message}");
                return View(viewModel);
            }
        }



        // GET: Payment/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _paymentQueryService.GetByIdAsync(id);
            if (payment == null) return NotFound();


            var viewModel = new PaymentEditViewModel
            {
                Id = payment.Id,
                Amount = payment.Amount,
                Type = payment.Type,
                AdopterId = payment.AdopterId,
                AdoptionId = payment.AdoptionId,
                LastFourDigits = payment.LastFourDigits,
                BankName = payment.BankName,
                CheckNumber = payment.CheckNumber,
                PaypalEmail = payment.PaypalEmail,
                Notes = payment.Notes
            };
            return View(viewModel);
        }

        // POST: Payment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PaymentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var payment = await _paymentQueryService.GetByIdAsync(viewModel.Id);
                if (payment == null) return NotFound();

                payment.Amount = viewModel.Amount;
                payment.Type = viewModel.Type;
                payment.AdopterId = viewModel.AdopterId;
                payment.AdoptionId = viewModel.AdoptionId;
                payment.LastFourDigits = viewModel.LastFourDigits;
                payment.BankName = viewModel.BankName;
                payment.CheckNumber = viewModel.CheckNumber;
                payment.PaypalEmail = viewModel.PaypalEmail;
                payment.Notes = viewModel.Notes;

                await _paymentService.UpdateAsync(payment);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        //POST Deactivate payment 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deactivate(int id)
        {
            var payment = await _paymentQueryService.GetByIdAsync(id);
            if (payment == null) return NotFound();

            payment.IsActive = false;
            payment.UpdatedOn = DateTime.UtcNow;
            await _paymentService.UpdateAsync(payment);

            return RedirectToAction("Index");
        }


    }
}
