using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HashPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash hash = new Hash();
            InteractWithFile interactWithFile = new InteractWithFile();
            Gui gui = new Gui();

            bool start = false;
            while (!start)
            {
                Console.Clear();
                gui.Menu();
                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Please enter your Username you want to login with : ");
                        string userName = Console.ReadLine();
                        Console.Clear();
                        Console.Write("Please enter the password that you want to login with :");
                        string userPassword = Console.ReadLine();
                        string password = hash.GenerateSha256Password(userPassword);
                        Console.WriteLine("Saving username and password...");
                        Thread.Sleep(2000);
                        interactWithFile.SaveUserCredentialsToFile(userName, password);
                        Console.Clear();
                        Thread.Sleep(1000);
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Username :");
                        userName = Console.ReadLine();
                        Console.Write("Enter Password :");
                        string userEnterPassword = Console.ReadLine();
                        List<string> passwordFromFile = interactWithFile.ReadPasswordFromFile(userName);
                        string hashedPassword = hash.GenerateSha256Password(userEnterPassword);
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine("Trying to login...");
                        Thread.Sleep(2000);
                        Console.Clear();
                        foreach (string pwd in passwordFromFile)
                        {
                            if (hashedPassword == pwd)
                            {
                                Console.WriteLine("You are logged in");
                                Thread.Sleep(2000);
                                start = true;
                            }
                            else
                            {
                                Console.WriteLine("Wrong password try again");
                            }
                        }

                        break;

                    default:
                        start = true;
                        break;
                }
            }
        }
    }
}