using System.Text;

namespace RandomPasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadCommands();
        }

        static void ReadCommands()
        {
            int passwordLength;
            string userInput;
            bool includeSymbols = false;
            bool includeNumbers = false;

            Console.Write("Write password length: "); 
            try
            {
                passwordLength = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                passwordLength = 0;
            }

            Console.Write("Password include symbols, Y or N: ");
            userInput = Console.ReadLine().ToUpper() ?? "";

            if (userInput == "Y")
            {
                includeSymbols = true;
            }

            // Clear user input
            userInput = "";

            Console.Write("Password include numbers, Y or N: ");
            userInput = Console.ReadLine().ToUpper();
           
            if (userInput == "Y")
            {
                includeNumbers = true;
            }

            Console.WriteLine("\nPress ENTER to generate password.\n");

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine(GeneratePassword(passwordLength, includeSymbols, includeNumbers));
                }
            }
        }

        static string GeneratePassword(int passwordLength, bool includeSymbols, bool includeNumbers)
        {
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string symbols = "!@#$%^&*()_+";
            string numbers = "0123456789";

            if (passwordLength <= 0)
            {
                Console.WriteLine("Password is less then 1.");

                return string.Empty;
            }

            if (includeSymbols)
            {
                letters += symbols;
            }
            if (includeNumbers)
            {
                letters += numbers;
            }

            Random random = new();
            StringBuilder password = new();

            for (int i = 0; i < passwordLength; i++)
            {
                int index = random.Next(letters.Length);
                password.Append(letters[index]);
            }

            return password.ToString();
        }
    }
}
