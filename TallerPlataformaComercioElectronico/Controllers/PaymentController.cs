using Microsoft.AspNetCore.Mvc;
using TallerPlataformaComercioElectronico.Models;
using TallerPlataformaComercioElectronico.PaymentStrategies.Context;
using TallerPlataformaComercioElectronico.PaymentStrategies.Implementations;
using TallerPlataformaComercioElectronico.PaymentStrategies.Interfaces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<JsonResult> ProcessPayment(PaymentRequest payment)
        {
            IPaymentStrategy paymentStrategy;
            ApiResponse apiResponse = new ApiResponse();

            switch (payment.PaymentMethod.Type)
            {
                case PaymentMethodType.CreditCard:
                    paymentStrategy = new CreditCardPaymentStrategy(_paymentService);
                    break;
                case PaymentMethodType.PayPal:
                    paymentStrategy = new PayPalPaymentStrategy(_paymentService);
                    break;
                default:
                    throw new NotSupportedException("Método de pago no soportado");
            }
            var paymentContext = new PaymentContext(paymentStrategy);
            var paymentResponse = await paymentContext.ProcessPayment(payment);
            return Json(new { result = paymentResponse });
        }
    }
}
