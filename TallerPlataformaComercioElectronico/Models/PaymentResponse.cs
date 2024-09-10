using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerPlataformaComercioElectronico.Models
{
    public class PaymentResponse
    {
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string OrderId { get; set; }
        public string Message { get; set; }
    }
}
