﻿using System.Text;

namespace TallerPlataformaComercioElectronico.Helpers
{
    public class Utilities
    {
        private static Random random = new Random();

        public static string convertirBase64(string ruta)
        {
            byte[] bytes = File.ReadAllBytes(ruta);
            string file = Convert.ToBase64String(bytes);
            return file;
        }

        public static bool CheckCreditCard(string creditCardNumber)
        {
            StringBuilder digitsOnly = new StringBuilder();

            foreach (char c in creditCardNumber.Where(c => char.IsDigit(c)))
            {
                digitsOnly.Append(c);
            }

            if (digitsOnly.Length > 18 || digitsOnly.Length < 15) return false;

            int sum = 0;
            int digit = 0;
            int addend = 0;
            bool timesTwo = false;

            for (int i = digitsOnly.Length - 1; i >= 0; i--)
            {
                digit = Int32.Parse(digitsOnly.ToString(i, 1));
                if (timesTwo)
                {
                    addend = digit * 2;
                    if (addend > 9)
                        addend -= 9;
                }
                else
                    addend = digit;

                sum += addend;

                timesTwo = !timesTwo;

            }
            return (sum % 10) == 0;
        }

        public static bool ExpirationDateIsValid(string expirationDate)
        {
            DateTime fechaVencimiento = ParseExpirationDate(expirationDate);
            if (fechaVencimiento.Year < DateTime.Today.Year ||
                (fechaVencimiento.Year == DateTime.Today.Year && fechaVencimiento.Month < DateTime.Today.Month))
                return false;
            else
                return true;
        }

        public static DateTime ParseExpirationDate(string expirationDate)
        {
            if (string.IsNullOrEmpty(expirationDate))
                return DateTime.MinValue;

            int mes;
            if(!int.TryParse(expirationDate.Substring(0, 2), out mes))
                return DateTime.MinValue;

            int anio;
            if (!int.TryParse(expirationDate.Substring(3, 2), out anio))
                return DateTime.MinValue;
            else
                anio += 2000;

            var fechaVencimiento = anio.ToString() + "-" + mes.ToString("00") + "-01";
            return DateTime.Parse(fechaVencimiento);
        }

        public static bool CVVIsValid(string creditCardNumber, string CVV)
        {
            if (string.IsNullOrEmpty(CVV))
                return false;
            else
            {
                if (creditCardNumber.Substring(0, 1) == "3")
                    return CVV.Length == 4;
                else
                    return CVV.Length == 3;
            }
        }

        public static Dictionary<string, string> PaymentRandomResponse(int? forcedResult = null)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();
            int numero = forcedResult != null ? (int)forcedResult : random.Next(2);
            if (numero == 0) {
                //Success
                response.Add("Code", "Payment_success");
                response.Add("Description", "Pago procesado con éxito.");
            }
            else
            {
                //Error
                int numeroError = random.Next(2);
                switch (numeroError)
                {
                    case 0:
                        response.Add("Code", "Insufficient_funds");
                        response.Add("Description", "Los fondos son insuficientes.");
                        break;
                    case 1:
                        response.Add("Code", "Blocked_card");
                        response.Add("Description", "La Tarjeta está bloqueada.");
                        break;
                    default:
                        break;
                }
            }
            return response;
        }
    }
}
