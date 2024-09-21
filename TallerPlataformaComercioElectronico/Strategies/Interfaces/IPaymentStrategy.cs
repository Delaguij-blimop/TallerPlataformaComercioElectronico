using TallerPlataformaComercioElectronico.Models;

namespace TallerPlataformaComercioElectronico.PaymentStrategies.Interfaces
{
    public interface IPaymentStrategy
    {
        Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest);
    }
}
