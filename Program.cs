public class Book
{
    public string BookID { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string Publication { get; set; }
    public string ISBN { get; set; }
    public int Stock { get; set; }

    public Book(string bookID, string title, string author, string description, string publication, string isbn, int stock)
    {
        BookID = bookID;
        Title = title;
        Author = author;
        Description = description;
        Publication = publication;
        ISBN = isbn;
        Stock = stock;
    }

    public override string ToString()
    {
        return $"BookID: {BookID}, Title: {Title}, Author: {Author}, Description: {Description}, Publication: {Publication}, ISBN: {ISBN}, Stock: {Stock}";
    }
}

public class Bookshop
{
    public List<Book> inventory;

    public Bookshop()
    {
        inventory = new List<Book>();
    }

    public void AddBook(Book book)
    {
        inventory.Add(book);
    }

    public void RemoveBook(Book book)
    {
        inventory.Remove(book);
    }
}
class Program
{
    static void Main()
    {
        int book001 = 84;
        int book002 = 63;
        int book003 = 57;
        int book004 = 91;
        int book005 = 83;

        int index;

        Menu();

        Bookshop bookshop = new Bookshop();

        bookshop.AddBook(new Book("001", "Code Complete", "Steve McConnell", "A guide to writing high-quality software code.", "2004", "978-0735619678", 84));
        bookshop.AddBook(new Book("002", "The Pragmatic Programmer", "Andrew Hunt and David Thomas", "A guide to practical programming techniques.", "1999", "978-0201616224", 63));
        bookshop.AddBook(new Book("003", "The Mythical Man-Month", "Frederick P. Brooks Jr.", "Discussion on project management and team organization.", "1995", "978-0201835953", 57));
        bookshop.AddBook(new Book("004", "Clean Code", "Robert C. Martin", "A guide to writing clean, maintainable, and efficient code.", "2008", "978-0132350884", 91));
        bookshop.AddBook(new Book("005", "Object-Oriented Software", "Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides", "A classic book on software design patterns.", "1994", "978-0201633610", 83));


        Console.Write("\nEnter your choice: ");
        string? userInput = Console.ReadLine();

        while (userInput != "0")
        {
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("\nSelect a book to view more details.\n");
                    ViewBooks(bookshop);

                    string? bookChoice = Console.ReadLine();

                    while (bookChoice != "0")
                    {
                        switch (bookChoice)
                        {
                            case "1":
                                index = 0;

                                BookDisplay(bookshop, index);
                                ViewBooks(bookshop);

                                bookChoice = Console.ReadLine();

                                break;

                            case "2":

                                index = 1;

                                BookDisplay(bookshop, index);
                                ViewBooks(bookshop);

                                bookChoice = Console.ReadLine();
                                break;

                            case "3":

                                index = 2;

                                BookDisplay(bookshop, index);
                                ViewBooks(bookshop);

                                bookChoice = Console.ReadLine();
                                break;

                            case "4":

                                index = 3;

                                BookDisplay(bookshop, index);
                                ViewBooks(bookshop);

                                bookChoice = Console.ReadLine();
                                break;

                            case "5":

                                index = 4;

                                BookDisplay(bookshop, index);
                                ViewBooks(bookshop);

                                bookChoice = Console.ReadLine();
                                break;


                            default:
                                Console.WriteLine("\nInvalid input. Please try again.");
                                Console.WriteLine("\nSelect a book to view more details.\n");
                                ViewBooks(bookshop);

                                bookChoice = Console.ReadLine();
                                break;
                        }
                    }

                    Menu();

                    Console.Write("\nEnter your choice: ");
                    userInput = Console.ReadLine();
                    break;

                case "2":
                    ViewStocks(bookshop);

                    Menu();

                    Console.Write("\nEnter your choice: ");
                    userInput = Console.ReadLine();
                    break;

                case "3":
                    Console.WriteLine("\nChoose a book to add stock.\n");
                    ViewBooks(bookshop);

                    string? bookChoice2 = Console.ReadLine();

                    while (bookChoice2 != "0")
                    {
                        switch (bookChoice2)
                        {
                            case "1":
                                Console.Write("Enter number of stock/s to add: ");
                                int addStocks = Console.Read();

                                book001 += addStocks;

                                Console.WriteLine("\nBook stock has been successfully updated!");

                                Console.WriteLine("\nChoose a book to add stock.\n");
                                ViewBooks(bookshop);

                                bookChoice2 = Console.ReadLine();
                                break;

                            case "2":
                                Console.Write("Enter number of stock/s to add: ");
                                addStocks = Console.Read();

                                book002 += addStocks;
                                Console.WriteLine("\nBook stock has been successfully updated!");

                                Console.WriteLine("\nChoose a book to add stock.\n");
                                ViewBooks(bookshop);

                                bookChoice2 = Console.ReadLine();
                                break;
                            case "3":
                                Console.Write("Enter number of stock/s to add: ");
                                addStocks = Console.Read();

                                book003 += addStocks;
                                Console.WriteLine("\nBook stock has been successfully updated!");

                                Console.WriteLine("\nChoose a book to add stock.\n");
                                ViewBooks(bookshop);

                                bookChoice2 = Console.ReadLine();
                                break;
                            case "4":
                                Console.Write("Enter number of stock/s to add: ");
                                addStocks = Console.Read();

                                book004 += addStocks;
                                Console.WriteLine("\nBook stock has been successfully updated!");

                                Console.WriteLine("\nChoose a book to add stock.\n");
                                ViewBooks(bookshop);

                                bookChoice2 = Console.ReadLine();
                                break;
                            case "5":
                                Console.Write("Enter number of stock/s to add: ");
                                addStocks = Console.Read();

                                book005 += addStocks;
                                Console.WriteLine("\nBook stock has been successfully updated!");

                                ViewBooks(bookshop);

                                bookChoice2 = Console.ReadLine();
                                break;

                            default:
                                Console.WriteLine("\nInvalid input. Please try again.");

                                ViewBooks(bookshop);

                                bookChoice2 = Console.ReadLine();
                                break;
                        }
                    }

                    Menu();

                    Console.Write("\nEnter your choice: ");
                    userInput = Console.ReadLine();


                    break;

                default:
                    Console.WriteLine("\nInvalid input. Please try again.");

                    Menu();

                    Console.Write("\nEnter your choice: ");
                    userInput = Console.ReadLine();
                    break;



            }
        }
    }

    static void Menu()
    {
        Console.WriteLine("\n ------------------------------ ");
        Console.WriteLine("|  BOOKSHOP MANAGEMENT SYSTEM  |");
        Console.WriteLine(" ------------------------------ ");
        Console.WriteLine("\nMENU");
        Console.WriteLine("1. View Books");
        Console.WriteLine("2. View Stocks");
        Console.WriteLine("3. Add Stocks");
        Console.WriteLine("Press 0 to Exit.");

    }

    static void ViewBooks(Bookshop bookshop)
    {
        Console.WriteLine($"1. {bookshop.inventory[0].Title}");
        Console.WriteLine($"2. {bookshop.inventory[1].Title}");
        Console.WriteLine($"3. {bookshop.inventory[2].Title}");
        Console.WriteLine($"4. {bookshop.inventory[3].Title}");
        Console.WriteLine($"5. {bookshop.inventory[4].Title}");
        Console.WriteLine("Press 0 to go back to Menu.");

        Console.Write("\nEnter your choice: ");

    }

    static void ViewStocks(Bookshop bookshop)
    {
        Console.WriteLine("\n ---------------------------------------------------------------");
        Console.WriteLine("| BOOK ID |    BOOK TITLE               |   STOCK   |");
        Console.WriteLine(" ---------------------------------------------------------------");
        Console.WriteLine($"|   {bookshop.inventory[0].BookID}   |  {bookshop.inventory[0].Title}                          |      {bookshop.inventory[0].Stock}    |");
        Console.WriteLine($"|   {bookshop.inventory[1].BookID}   |  {bookshop.inventory[1].Title}               |      {bookshop.inventory[1].Stock}    |");
        Console.WriteLine($"|   {bookshop.inventory[2].BookID}   |  {bookshop.inventory[2].Title}                 |      {bookshop.inventory[2].Stock}    |");
        Console.WriteLine($"|   {bookshop.inventory[3].BookID}   |  {bookshop.inventory[3].Title}                             |      {bookshop.inventory[3].Stock}    |");
        Console.WriteLine($"|   {bookshop.inventory[4].BookID}   |  {bookshop.inventory[4].Title}               |      {bookshop.inventory[4].Stock}    |");
        Console.WriteLine(" ---------------------------------------------------------------");
    }

    static void BookDisplay(Bookshop bookshop, int index)
    {
        Console.WriteLine($"\nBook ID     : {bookshop.inventory[index].BookID}");
        Console.WriteLine($"Title       : {bookshop.inventory[index].Title}");
        Console.WriteLine($"Author      : {bookshop.inventory[index].Author}");
        Console.WriteLine($"Description : {bookshop.inventory[index].Description}");
        Console.WriteLine($"Publication : {bookshop.inventory[index].Publication}");
        Console.WriteLine($"ISBN        : {bookshop.inventory[index].ISBN}");

        Console.WriteLine("\nSelect a book to view more details.\n");
    }
}
