﻿using PG3302_Eksamen.Logic;

namespace PG3302_Eksamen.UI
{
    public class BookUI
    {


        public BookLogic bookLogic = new();
 

        public void BookMenu()
        {
            Console.WriteLine("Welcome to the book registry\n" +
                "Please Choose what you would like to do.\n" +
                "1. Display books.\n" +
                "2. Add a new book.\n" +
                "3. Edit existing book.\n" +
                "4. Delete a book.\n\n" +
                "--------------------------\n\n" +
                "9. Back to Main Menu\n" +
                "\nIf you would like to exit the program, please type 0.\n\n");

            Console.Write("Write your choice here: ");
            
            
            String? userInput = Console.ReadLine();
            int? userInputResult = Int32.Parse(userInput);

            switch (userInputResult)
            {
                
                case 1:
                    DisplayBooks();
                    break;

                case 2: AddBook();
                    break;

                case 3: EditBook();
                    break;

                case 4: DeleteBook();
                    break;

                case 9:
                    BackToMainMenu();
                    break;
                       

                case 0:
                    break;

                default: Console.WriteLine("Invalid input! (1,2,3,4,0)");
                        BookMenu();
                        break;
            } 
        }

        private void DisplayBooks()
        {
            Console.WriteLine("\n" +
                "------------------" +
                "\n");
            bookLogic.DisplayBooks();

            BookMenu();
        }

        private void AddBook()
        {
           
            Console.Write("Book title: ");
            string title = Console.ReadLine();
       
            Console.Write("Book Author: ");
            string author = Console.ReadLine();
          
            Console.Write("Release Year: ");
           
            int year = Int32.Parse(Console.ReadLine());

            Console.Write("Book Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Number of Pages: ");
            int pages = Int32.Parse(Console.ReadLine());

            bookLogic.AddBook(title, author, year, genre, pages);

            bookLogic.DisplayBooks();
            
            BookMenu();

        }


        private void EditBook()
        {
            Console.Write("Enter the title of the book you wish to edit: ");
            string? oldTitle = Console.ReadLine();
            Console.Write("Enter the new title. ");
            string? newTitle = Console.ReadLine();
            bookLogic.EditBookTitle(oldTitle, newTitle);
            BookMenu();
        }

        private void DeleteBook()
        {
            Console.Write("Enter the Title of the Book you wish to delete: ");
            string userInput = Console.ReadLine();
            bookLogic.RemoveBook(userInput);
            BookMenu();
        }

        private static void BackToMainMenu()
        {
                Console.Clear();
              ConsoleApp consoleApp = new();
              consoleApp.RunProgram();
        

        }
      
    }
}
