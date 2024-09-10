using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerPlataformaComercioElectronico.Models
{
    public class PaymentMethod
    {
        public string Type { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public string CardholderName { get; set; }
    }
}
