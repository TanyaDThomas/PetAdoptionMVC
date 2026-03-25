
using Microsoft.AspNetCore.Mvc;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;


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
            return View(payments);
        }

        //GET Create Payment
        public IActionResult Ceate()
        {
            return View();
        }

        //POST Create Payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(PaymentRequest request)
        {
            if (ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                var payment = await _paymentService.ProcessPaymentAsync(request);

                if (payment.Status == PaymentStatus.Completed)
                {
                    return RedirectToAction("Details", new { id = payment.Id });
                }

                // Payment failed

                string errorMessage;
                if (payment.Notes != null)
                {
                    errorMessage = $"Payment failed: {payment.FailureReason}";
                }
                else
                {
                    errorMessage = "Payment failed: Unknown reason";
                }

                ModelState.AddModelError("", errorMessage);
                return View(request);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty,
                    $"An error occurred while processing your payment: {ex.Message}");

                return View(request);
            }

        }

        //GET Payment Details 5
        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentQueryService.GetByIdAsync(id); // from your query service
            if (payment == null) return NotFound();

            return View(payment);
        }


    }
}
