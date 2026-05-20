using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BLL
{
    public class clsSeguridadBLL
    {
        public string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
        public bool VerificarPassword(string passwordIngresada, string hashGuardado)
        {
            string HashIngresado = HashPassword(passwordIngresada);

            return HashIngresado == hashGuardado;
        }
    }
}
