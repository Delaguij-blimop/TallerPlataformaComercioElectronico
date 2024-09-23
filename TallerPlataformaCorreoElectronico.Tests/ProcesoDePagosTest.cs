using TallerPlataformaComercioElectronico.Helpers;

namespace TallerPlataformaComercioElectronico.Tests.Tests
{
    public class ProcesoDePagosTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("4242424242424242", true)]
        [TestCase("1234123412341234", false)]
        [TestCase("", false)]
        public void ValidacionDeNumerosDeTarjeta(string numeroTarjeta, bool resultado)
        {
            //El número de tarjeta lo obtiene de los parametros (TestCase)

            //Realiza la accion
            var tarjetaValida = Utilities.CheckCreditCard(numeroTarjeta);

            //Verifica el resultado
            Assert.That(tarjetaValida, Is.EqualTo(resultado));

        }

        [TestCase("10/26", true)]
        [TestCase("10/23", false)]
        [TestCase("", false)]
        public void ValidacionDeFechaDeExpiracion(string fechaExpiracion, bool resultado)
        {
            //La fecha de expiración la obtiene de los parametros (TestCase)

            //Realiza la accion
            var tarjetaValida = Utilities.ExpirationDateIsValid(fechaExpiracion);

            //Verifica el resultado
            Assert.That(tarjetaValida, Is.EqualTo(resultado));

        }

        [TestCase("4110874160938350", "367", true)] //Visa (3 digitos Ok)
        [TestCase("5535269761057896", "412", true)] //Master (3 digitos Ok)
        [TestCase("377793356683248", "211", false)] //Amex (3 digitos Error)
        [TestCase("377793356683248", "2118", true)] //Amex (4 digitos Ok)
        public void ValidacionDeCVV(string numeroTarjeta, string CVV, bool resultado)
        {
            //El CVV lo obtiene de los parametros (TestCase)

            //Realiza la accion
            var cvvValido = Utilities.CVVIsValid(numeroTarjeta, CVV);

            //Verifica el resultado
            Assert.That(cvvValido, Is.EqualTo(resultado));

        }


    }
}