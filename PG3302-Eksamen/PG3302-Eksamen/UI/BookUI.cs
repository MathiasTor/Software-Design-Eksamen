using PG3302_Eksamen.Logic;
using PG3302_Eksamen.Media;
using PG3302_Eksamen.User;
using System.Collections;

namespace PG3302_Eksamen.UI
{
    public class BookUI
    {


        public BookLogic bookLogic = new(new DbLogicBook());
        private DbLogicBook _dbLogic = new();
        SystemUser user;
 
        public BookUI(SystemUser user)
        {
            this.user = user;
        }

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

            switch (userInput)
            {
                
                case "1":
                    DisplayBooks();
                    break;

                case "2": 
                    AddBook();
                    break;

                case "3": 
                    EditBook();
                    break;

                case "4": 
                    DeleteBook();
                    break;

                case "9":
                    BackToMainMenu();
                    break;
                       

                case "0":
                    break;

                default: Console.WriteLine("Invalid input! (1,2,3,4,0,9)");
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
            Console.WriteLine("\n" +
                "------------------" +
                "\n");

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
            
            BookMenu();

        }


        private void EditBook()
        {
            Console.WriteLine("Enter title of book to edit");
            String? titleToEdit = Console.ReadLine();
            int counter = 0;
            Book bookToEdit = new();

            ArrayList booksWithSameTitle = _dbLogic.getAllBooksWithSameName(titleToEdit);
            Console.WriteLine("\n");

            if (booksWithSameTitle.Count > 1)
            {
                printBooksWithSameTitle(booksWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple books with the same title!");
                Console.WriteLine("Enter ID of book to edit: ");

                try {
                    int bookIdToEdit = Int32.Parse(Console.ReadLine());
                    bookToEdit = (Book)booksWithSameTitle[bookIdToEdit - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                    EditBook();
                }
                
            }
            else if (booksWithSameTitle.Count == 1)
            {
                bookToEdit = (Book)booksWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No books with that title found!");
                BookMenu();
                return;
            }

            EditBook(bookToEdit);
            
        }

        private void printBooksWithSameTitle(ArrayList booksWithSameTitle)
        {
            int counter = 0;
            foreach (Book book in booksWithSameTitle)
            {
                counter++;
                Console.WriteLine($"{counter} - {book}");
            }
        }

        private void DeleteBook()
        {
            Console.Write("Enter the Title of the Book you wish to delete: ");
            string titleToDelete = Console.ReadLine();
            ArrayList booksWithSameTitle = _dbLogic.getAllBooksWithSameName(titleToDelete);
            int counter = 0;

            Book bookToDelete = new();

            if(booksWithSameTitle.Count > 1)
            {
                printBooksWithSameTitle(booksWithSameTitle);

                Console.WriteLine("\n");
                Console.WriteLine("Found multiple books with the same title!");
                Console.WriteLine("Enter ID of book to delete: ");

                try
                {
                    int bookIdToDelete = Int32.Parse(Console.ReadLine());
                    bookToDelete = (Book)booksWithSameTitle[bookIdToDelete - 1];
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input!");
                    DeleteBook();
                }
                
                
            }else if (booksWithSameTitle.Count == 1)
            {
                bookToDelete = (Book)booksWithSameTitle[0];
            }
            else
            {
                Console.WriteLine("No books with that title found!");
                BookMenu();
                return;
            }
            DeleteBook(bookToDelete);
        }

        private void DeleteBook(Book book)
        {
            bookLogic.RemoveBook(book);
            Console.WriteLine("Book deleted!");
            Console.WriteLine("Delete more? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                DeleteBook();
            }
            else
            {
                Console.Clear();
                BookMenu();
            }
        }

        //Edit book
        public void EditBook(Book book)
        {
            Console.Clear();
            Console.WriteLine("Book to edit:");
            Console.WriteLine(book + "\n");

            Console.WriteLine("What would you like to edit? \n" +
                                   "1: Title \n" +
                                   "2: Author \n" +
                                   "3: Release Year \n" +
                                   "4. Genre \n" +
                                   "5. Number of pages \n" +
                                   "6. Exit editing \n");

            try
            {
                Console.Write("Write your choice here: ");
                int choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new title: ");
                        string newTitle = Console.ReadLine();
                        bookLogic.EditBookTitle(book, newTitle);
                        break;
                    case 2:
                        Console.WriteLine("Enter new author: ");
                        string newAuthor = Console.ReadLine();
                        bookLogic.EditBookAuthor(book, newAuthor);
                        break;
                    case 3:
                        Console.WriteLine("Enter new release year: ");
                        int newReleaseYear = Int32.Parse(Console.ReadLine());
                        bookLogic.EditBookReleaseYear(book, newReleaseYear);
                        break;
                    case 4:
                        Console.WriteLine("Enter new genre: ");
                        string newGenre = Console.ReadLine();
                        bookLogic.EditBookGenre(book, newGenre);
                        break;
                    case 5:
                        Console.WriteLine("Enter new number of pages: ");
                        int newPages = Int32.Parse(Console.ReadLine());
                        bookLogic.EditBookPages(book, newPages);
                        break;
                    case 6:
                        Console.Clear();
                        BookMenu();
                        return;
                    default:
                        Console.WriteLine("Invalid input! (1,2,3,4,5)");
                        EditBook(book);
                        break;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid input!");
                EditBook(book);
                return;
            }
            
            Console.WriteLine("Book edited!");
            Console.WriteLine("Edit more? Y/N");
            string answer = Console.ReadLine();
            if (answer == "Y" || answer == "y")
            {
                EditBook(book);
            }
            else
            {
                Console.Clear();
                BookMenu();
            }

        }

        private void BackToMainMenu()
        {
              Console.Clear();
              ConsoleApp consoleApp = new();
              consoleApp.MainMenu(user);
        }
      
    }
}
