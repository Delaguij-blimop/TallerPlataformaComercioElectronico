using TallerPlataformaComercioElectronico.Entities;
using TallerPlataformaComercioElectronico.Repositories.Interfaeces;
using TallerPlataformaComercioElectronico.Services.Interfaces;

namespace TallerPlataformaComercioElectronico.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentRepository;

        public PaymentService(IGenericRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {

            try
            {
                var brandsList = await _paymentRepository.GetAllAsync();
                return brandsList;

            }
            catch (Exception ex)
            {
                return new List<Payment>();
            }
        }

        public async Task<Payment> GetById(int id)
        {
            Payment payment = new Payment();
            try
            {
                payment = await _paymentRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                payment = new Payment();
            }
            return payment;
        }

        public async Task<bool> Insert(Payment payment)
        {
            bool response = true;
            try
            {
                //Genera un numero random para la transaccion
                Random rnd = new Random();
                string transactionId = "tx" + rnd.Next(10000, 99999).ToString() + rnd.Next(10000, 99999).ToString();
                payment.TransactionId = transactionId;

                await _paymentRepository.InsertAsync(payment);
                await _paymentRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public async Task<bool> Delete(int id)
        {
            bool response = true;
            try
            {
                await _paymentRepository.DeleteAsync(id);
                await _paymentRepository.SaveAsync();
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
    }
}
