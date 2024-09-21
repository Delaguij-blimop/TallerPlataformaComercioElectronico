using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Models;
using TallerPlataformaComercioElectronico.PaymentStrategies.Interfaces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.PaymentStrategies.Implementations
{
    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        private readonly IPaymentService _paymentService;
        public PayPalPaymentStrategy(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
        {
            Payment payment = new Payment
            {
                OrderId = int.Parse(paymentRequest.OrderId),
                PaymentMethodId = (int)paymentRequest.PaymentMethod.Type,
                Correo = paymentRequest.PaymentMethod.Email,
                Amount = paymentRequest.Amount,
                BillingAddress = new Address
                {
                    Name = paymentRequest.BillingAddress.Name,
                    Street = paymentRequest.BillingAddress.Street,
                    PostalCode = paymentRequest.BillingAddress.PostalCode,
                    Type = AddressType.Billing,
                    CityId = paymentRequest.BillingAddress.CityId
                }
            };

            var response = await _paymentService.Insert(payment);
            return new PaymentResponse
            {
                Status = response == true ? "success" : "failure",
                TransactionId = payment.TransactionId,
                Amount = payment.Amount,
                Currency = paymentRequest.Currency,
                OrderId = payment.OrderId.ToString("000000"),
                Message = response == true ? "Paypal Payment processed successfully." : "There was an error processing the payment."
            };
        }
    }
}
