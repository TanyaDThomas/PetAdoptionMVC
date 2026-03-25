using Microsoft.EntityFrameworkCore;
using PetAdoptionMVC.Contracts;
using PetAdoptionMVC.Data;
using PetAdoptionMVC.Models;
using PetAdoptionMVC.Models.Enums;
using PetAdoptionMVC.SearchFilters;
using System.Data;

namespace PetAdoptionMVC.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PetAdoptionDbContext _context;
        private readonly IPaymentProcessor _paymentProcessor;
        public PaymentService(PetAdoptionDbContext context, IPaymentProcessor paymentProcessor)
        {
            _context = context;
            _paymentProcessor = paymentProcessor;
        }

        // PAYMENT CRUD OPERATIONS

        public async Task<Payment> ProcessPaymentAsync(PaymentRequest request)
        {
            var result = await _paymentProcessor.ProcessAsync(request);

            var payment = new Payment
            {
                Amount = request.Amount,
                Type = request.Type,
                Status = result.Status,
                PaymentDate = DateTime.UtcNow,
                PaymentToken = request.PaymentToken,
                ReceiptNumber = result.TransactionId,
                Notes = request.Notes,
                AdopterId = request.AdopterId,
                AdoptionId = request.AdoptionId,
                CreatedOn = DateTime.UtcNow

            };

            _context.Set<Payment>().Add(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<bool> RefundAsync(int paymentId)
        {
            var payment = await _context.Set<Payment>().FindAsync(paymentId);
            if (payment == null || payment.Status != PaymentStatus.Completed)
            {
                return false;
            }

            payment.Status = PaymentStatus.Refunded;
            payment.RefundedAmount = payment.Amount;
            payment.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> VoidPaymentAsync(int paymentId)
        {
            var payment = await _context.Set<Payment>().FindAsync(paymentId);
            if (payment == null || payment.Status != PaymentStatus.Pending)
            {
                return false;
            }

            payment.Status = PaymentStatus.Voided;
            payment.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PartialRefundAsync(int paymentId, decimal amount)
        {
            var payment = await _context.Set<Payment>().FindAsync(paymentId);
            if (payment == null || payment.Status != PaymentStatus.Completed || amount <= 0 || amount > payment.Amount)
                return false;

            payment.RefundedAmount += amount;

            // Update status
            payment.Status = payment.RefundedAmount == payment.Amount
                ? PaymentStatus.Refunded
                : PaymentStatus.PartiallyRefunded;

            payment.UpdatedOn = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }








    }
}










