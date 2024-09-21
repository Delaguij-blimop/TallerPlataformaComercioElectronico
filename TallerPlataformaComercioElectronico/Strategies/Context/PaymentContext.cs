using TallerPlataformaComercioElectronico.Models;
using TallerPlataformaComercioElectronico.PaymentStrategies.Interfaces;

namespace TallerPlataformaComercioElectronico.PaymentStrategies.Context
{
    public class PaymentContext
    {
        private readonly IPaymentStrategy _paymentStrategy;

        public PaymentContext(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public Task<PaymentResponse> ProcessPayment(PaymentRequest payment)
        {
            return _paymentStrategy.ProcessPayment(payment);
        }
    }
}
