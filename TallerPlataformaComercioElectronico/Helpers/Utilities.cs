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
    }
}
