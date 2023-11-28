using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.UI;
using PG3302_Eksamen.User;

namespace PG3302_Eksamen.Renting
{
    public class RentMediaUI
    {
        public RentMediaUI()
        {

        }

        public void RentMediaMenu(SystemUser user)
        {
            Console.WriteLine("What would you like to rent?");
            Console.WriteLine("1. Book");
            Console.WriteLine("2. Movie");
            Console.WriteLine("3. Music");
            Console.WriteLine("4. Game");
            Console.WriteLine("\n5. Return media");
            Console.WriteLine("\n0. Back to main menu");

            Console.Write("Write your choice here: ");
            string? userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    RentBook(user);
                    break;
                case "2":
                    RentMovie(user);
                    break;
                case "3":
                    RentMusic(user);
                    break;
                case "4":
                    RentGame(user);
                    break;
                case "5":
                    ReturnMedia(user);
                    break;
                case "0":
                    Console.Clear();
                    MainMenu(user);
                    break;
                default:
                    Console.WriteLine("Invalid input! (1,2,3,4,5)");
                    RentMediaMenu(user);
                    break;
            }

        }

        private void ReturnMedia(SystemUser user)
        {
            DbLogicBook dbLogic = new();

            RentMediaDbLogic rentMediaDbLogic = new(user);
            List<RentedMedia> rentedMedia = rentMediaDbLogic.GetRentedMedia();
            ArrayList books = dbLogic.GetAllBooks();

            Console.Clear();
            Console.WriteLine("What media would you like to return?");

            if(rentedMedia.Count == 0)
            {
                Console.WriteLine("You have no rented media!");
                RentMediaMenu(user);
                return;
            }

            for (int i = 0; i < rentedMedia.Count; i++)
            {
                if (rentedMedia[i].Media == "Book")
                {
                    foreach (Book b in books)
                    {
                        if(b.Id == rentedMedia[i].MediaId)
                        {
                            string bookTitle = b.Title;
                            Console.WriteLine(i + 1 + ". " + bookTitle);
                        }
                    }
                }
            }

            Console.Write("Enter ID of media to return (Back: 0): ");

            try
            {
                int? userInput = Int32.Parse(Console.ReadLine());

                if(userInput == 0)
                {
                    Console.Clear();
                    RentMediaMenu(user);
                    return;
                }

                RentedMedia rentedMediaToReturn = rentedMedia[userInput.Value - 1];
                rentMediaDbLogic.ReturnMedia(rentedMediaToReturn);

                Console.Clear();
                Console.WriteLine("Media returned!");
                RentMediaMenu(user);

            }catch (Exception e)
            {
                Console.WriteLine("Invalid input!");
                ReturnMedia(user);
            }
            

        }

        private void MainMenu(SystemUser user)
        {
            ConsoleApp mainMenu = new();
            mainMenu.MainMenu(user);
        }

        private void RentGame(SystemUser user)
        {
            throw new NotImplementedException();
        }

        private void RentMusic(SystemUser user)
        {
            throw new NotImplementedException();
        }

        private void RentMovie(SystemUser user)
        {
            throw new NotImplementedException();
        }

        private void RentBook(SystemUser user)
        {
            RentBookUI rentBookUI = new(user);
            rentBookUI.RentBookMenu(user);
        }
    }
}
