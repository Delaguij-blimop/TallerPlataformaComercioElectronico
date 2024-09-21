using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> GetById(int id);
        Task<bool> Insert(Payment payment);
        Task<bool> Delete(int id);
    }
}
