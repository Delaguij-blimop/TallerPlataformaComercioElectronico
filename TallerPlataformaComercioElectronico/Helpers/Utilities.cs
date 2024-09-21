using System.Text;

namespace TallerPlataformaComercioElectronico.Helpers
{
    public class Utilities
    {
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
    }
}
