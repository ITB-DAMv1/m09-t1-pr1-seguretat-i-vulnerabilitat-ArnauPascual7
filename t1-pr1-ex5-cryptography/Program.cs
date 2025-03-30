using System.Security.Cryptography;
using System.Text;

namespace t1_pr1_ex5_cryptography
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DisplayMenu();
        }

        private static string? Username { get; set; }
        private static string? Password { get; set; }

        public static void DisplayMenu()
        {
            const string Menu = "Menú:" +
                "\n[1] Registre" +
                "\n[2] Verificació de dades" +
                "\n[3] Encriptació i desencriptació amb RSA" +
                "\n[ex] Sortir" +
                "\n";

            Console.WriteLine(Menu);

            string? option = Console.ReadLine();
            bool exit = false;

            Console.Clear();

            switch (option)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Verify();
                    break;
                case "3":
                    EncryptDecryptRSA();
                    break;
                case "ex" or "Ex" or "EX":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opció incorrecte");
                    break;
            }

            if (!exit)
            {
                Console.Write("\nPrem ENTER per a retorna al menú");
                Console.ReadLine();
                Console.Clear();

                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Fi del programa");
            }
        }
        public static void Register()
        {
            const string MsgUsernameInput = "Introdueix un nom d'usuari:";
            const string MsgPasswordInput = "Introdueix una contrasenya:";
            const string MsgRegisterResult = "Username: {0}, Password: {1}";

            Console.WriteLine(MsgUsernameInput);
            Username = Console.ReadLine();

            Console.WriteLine(MsgPasswordInput);
            Password = GetHashedPassword();

            Console.WriteLine(MsgRegisterResult, Username, Password);
        }
        public static void Verify()
        {
            const string MsgUsernameInput = "Introdueix el teu nom d'usuari:";
            const string MsgPasswordInput = "Introdueix la teva contrasenya:";
            const string MsgVerifyCorrect = "Verificació correcte";
            const string MsgVerifyIncorrect = "Verificació incorrecte";

            Console.WriteLine(MsgUsernameInput);
            string? username = Console.ReadLine();

            Console.WriteLine(MsgPasswordInput);
            string password = GetHashedPassword();

            if (username == Username && password == Password)
            {
                Console.WriteLine(MsgVerifyCorrect);
            }
            else
            {
                Console.WriteLine(MsgVerifyIncorrect);
            }
        }
        public static void EncryptDecryptRSA()
        {
            const string MsgEncryptTextInput = "Introdueix un text:";
            const string MsgEncryptText = "Text Encriptat: {0}";
            const string MsgDecryptText = "Text Desencriptat: {0}";

            RSA rsa = RSA.Create();

            Console.WriteLine(MsgEncryptTextInput);
            string input = Console.ReadLine();

            byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(input), RSAEncryptionPadding.OaepSHA256);
            string encryptedText = Convert.ToBase64String(encryptedData);
            Console.WriteLine(MsgEncryptText, encryptedText);

            byte[] decryptedData = rsa.Decrypt(encryptedData, RSAEncryptionPadding.OaepSHA256);
            string decryptedText = Encoding.UTF8.GetString(decryptedData);
            Console.WriteLine(MsgDecryptText, decryptedText);
        }
        public static string GetHashedPassword()
        {
            string password = "";
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Console.ReadLine()));
                password = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
            return password;
        }
    }
}
