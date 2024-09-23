using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Helpers;
using TallerPlataformaComercioElectronico.Models;
using TallerPlataformaComercioElectronico.PaymentStrategies.Interfaces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.PaymentStrategies.Implementations
{
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        private readonly IPaymentService _paymentService;
        public CreditCardPaymentStrategy(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
        {
            //Validar Numero de Tarjeta
            if (!Utilities.CheckCreditCard(paymentRequest.PaymentMethod.CardNumber))
            {
                return new PaymentResponse
                {
                    Status = "failure",
                    ErrorCode = "invalid_card",
                    Message = "El número de tarjeta no es válido."
                };
            }

            //Validar Vencimiento
            if (!Utilities.ExpirationDateIsValid(paymentRequest.PaymentMethod.ExpirationDate))
            {
                 return new PaymentResponse
                 {
                     Status = "failure",
                     ErrorCode = "card_expired",
                     Message = "La tarjeta de crédito está vencida."
                 };
            }

            Payment payment = new Payment
            {
                OrderId = int.Parse(paymentRequest.OrderId),
                PaymentMethodId = (int)paymentRequest.PaymentMethod.Type,
                CardNumber = paymentRequest.PaymentMethod.CardNumber,
                CardHolderName = paymentRequest.PaymentMethod.CardholderName,
                ExpirationDate = Utilities.ParseExpirationDate(paymentRequest.PaymentMethod.ExpirationDate),
                CVV = paymentRequest.PaymentMethod.CVV,
                Amount = paymentRequest.Amount,
                BillingAddress = new Address {
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
                Message = response == true ? "Credit Card Payment processed successfully." : "There was an error processing the payment."
            };

        }
    }
}
