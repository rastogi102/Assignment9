using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssignment9
{
    // Custom exception for validation errors
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegisterUser();
                Console.WriteLine("User Registration Successful!!!");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error Occurred: {ex.Message}");
            }
        }

        static void RegisterUser()
        {
            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Your Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Your Password: ");
            string password = Console.ReadLine();

            ValidateUserInput(name, email, password);

            // If all validations pass, you can insert the user data into the database or perform other operations here.
            // For simplicity, let's just display the entered data.
            Console.WriteLine("User Data:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Password: {password}");
        }

        static void ValidateUserInput(string name, string email, string password)
        {
            bool hasError = false;
            string errorMessage = "Errors:";

            if (string.IsNullOrEmpty(name) || name.Length < 6 || ContainsNumber(name))
            {
                errorMessage += "\n- Name must have at least 6 characters and cannot contain numbers.";
                hasError = true;
            }

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                errorMessage += "\n- Invalid Email Format.";
                hasError = true;
            }

            if (string.IsNullOrEmpty(password) || password.Length < 8)
            {
                errorMessage += "\n- Password must have at least 8 characters.";
                hasError = true;
            }

            if (hasError)
            {
                throw new ValidationException(errorMessage);
            }
        }

        static bool ContainsNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
    }

  
    
}

