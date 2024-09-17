using TallerPlataformaComercioElectronico.Entities;

namespace TallerPlataformaComercioElectronico.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> Insert(Order order);
    }
}
