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
            var mes = int.Parse(paymentRequest.PaymentMethod.ExpirationDate.Substring(0, 2));
            var anio = int.Parse(paymentRequest.PaymentMethod.ExpirationDate.Substring(3, 2)) + 2000;
            var fechaVencimiento = anio.ToString() + "-" + mes.ToString("00") + "-01";
            if (DateTime.Parse(fechaVencimiento).Year < DateTime.Today.Year ||
                (DateTime.Parse(fechaVencimiento).Year == DateTime.Today.Year && DateTime.Parse(fechaVencimiento).Month < DateTime.Today.Month))
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
                ExpirationDate = DateTime.Parse(fechaVencimiento),
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
