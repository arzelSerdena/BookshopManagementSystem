// menu options: View Books, View Stock, Add Stocks, Add Books, Reduce Stock, Remove Books
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

    public int AddStock(int quantity)
    {
        Stock += quantity;
        return Stock;
    }
    public int ReduceStock(int quantity)
    {
        Stock -= quantity;
        return Stock;
    }

    public override string ToString()
    {
        return $"BookID: {BookID}, Title: {Title}, Author: {Author}, Description: {Description}, Publication: {Publication}, ISBN: {ISBN}, Stock: {Stock}";
    }
}

class Program
{
    static void Main()
    {

        List<Book> books = new List<Book>();

        books.Add(new Book("001", "Code Complete", "Steve McConnell", "A guide to writing high-quality software code.", "2004", "978-0735619678", 84));
        books.Add(new Book("002", "The Pragmatic Programmer", "Andrew Hunt and David Thomas", "A guide to practical programming techniques.", "1999", "978-0201616224", 63));
        books.Add(new Book("003", "The Mythical Man-Month", "Frederick P. Brooks Jr.", "Discussion on project management and team organization.", "1995", "978-0201835953", 57));
        books.Add(new Book("004", "Clean Code", "Robert C. Martin", "A guide to writing clean, maintainable, and efficient code.", "2008", "978-0132350884", 91));
        books.Add(new Book("005", "Object-Oriented Software", "Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides", "A classic book on software design patterns.", "1994", "978-0201633610", 83));

        DisplayMenu();
        string? userInput = Console.ReadLine();

        while (userInput != "0")
        {
            switch (userInput)
            {
                case "1":

                    Console.WriteLine("\nSelect a book to view more details.\n");
                    ViewBooks(books);
                    int bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;

                    while (bookChoice >= 0 && bookChoice < books.Count)
                    {
                        BookDisplay(books, bookChoice);

                        Console.WriteLine("\nSelect a book to view more details.\n");
                        ViewBooks(books);
                        bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;
                    }

                    break;
                case "2":
                    ViewStocks(books);
                    break;
                case "3":
                    AddStocks(books);
                    break;
                case "4":
                    AddBooks(books);
                    break;
                case "5":
                    ReduceStocks(books);
                    break;
                case "6":
                    RemoveBooks(books);
                    break;
                default:
                    Console.WriteLine("\nInvalid input. Please try again.");
                    break;
            }
            DisplayMenu();
            userInput = Console.ReadLine();
        }
    }

    static void DisplayMenu()
    {
        int count = 1;

        string[] menu = new string[6] { "View Books", "View Stock", "Add Stocks", "Add Books", "Reduce Stock", "Remove Books" };

        Console.WriteLine("\n ------------------------------ ");
        Console.WriteLine("|  BOOKSHOP MANAGEMENT SYSTEM  |");
        Console.WriteLine(" ------------------------------ ");
        Console.WriteLine("\nMENU");

        foreach (string option in menu)
        {
            Console.WriteLine($"{count}. {option}");
            count++;
        }

        Console.WriteLine("Press 0 to Exit.");

        Console.Write("\nEnter your choice: ");
    }

    static void ViewBooks(List<Book> books)
    {
        int count = 1;

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine(count + ". " + books[i].Title);
            count++;
        }
        Console.WriteLine("Press 0 to go back to Menu.");

        Console.Write("\nEnter your choice: ");
    }

    static void ViewStocks(List<Book> books)
    {
        Console.WriteLine("\n ---------------------------------------------------------------");
        Console.WriteLine("| BOOK ID |    BOOK TITLE                           |   STOCK   |");
        Console.WriteLine(" ---------------------------------------------------------------");
        Console.WriteLine($"|   {books[0].BookID}   |  {books[0].Title}                          |     {books[0].Stock}    |");
        Console.WriteLine($"|   {books[1].BookID}   |  {books[1].Title}               |     {books[1].Stock}    |");
        Console.WriteLine($"|   {books[2].BookID}   |  {books[2].Title}                 |     {books[2].Stock}    |");
        Console.WriteLine($"|   {books[3].BookID}   |  {books[3].Title}                             |     {books[3].Stock}    |");
        Console.WriteLine($"|   {books[4].BookID}   |  {books[4].Title}               |     {books[4].Stock}    |");
        Console.WriteLine(" ---------------------------------------------------------------");
    }

    static void AddStocks(List<Book> books)
    {
        Console.WriteLine("\nChoose a book to add stock to.\n");
        ViewBooks(books);
        int bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;

        while (bookChoice >= 0 && bookChoice < books.Count)
        {
            Console.Write("Enter the number of stock to add: ");
            int quantity = (Convert.ToInt32(Console.ReadLine())) - 1;

            Console.WriteLine("Book stock has been successfully updated!");
            Console.WriteLine($"Book ID {books[bookChoice].BookID}: {books[bookChoice].Title} now has {books[bookChoice].AddStock(quantity)} stocks.");

            Console.WriteLine("\nChoose a book to add stock to.\n");
            ViewBooks(books);
            bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;
        }
    }

    static void AddBooks(List<Book> books)
    {
        Console.WriteLine("\nEnter the following information for the new book.");
        Console.Write("\nBook ID: ");
        string bookID = Console.ReadLine() ?? string.Empty;
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? string.Empty;
        Console.Write("Author: ");
        string author = Console.ReadLine() ?? string.Empty;
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? string.Empty;
        Console.Write("Publication: ");
        string publication = Console.ReadLine() ?? string.Empty;
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine() ?? string.Empty;
        Console.Write("Stock: ");
        int stock = (Convert.ToInt32(Console.ReadLine())) - 1;

        books.Add(new Book(bookID, title, author, description, publication, isbn, stock));

        Console.WriteLine("\nBook successfully added!");
    }

    static void ReduceStocks(List<Book> books)
    {
        Console.WriteLine("\nChoose a book to reduce stock.\n");
        ViewBooks(books);
        int bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;

        while (bookChoice >= 0 && bookChoice < books.Count)
        {
            Console.Write("Enter the number of stock to deduct: ");
            int quantity = (Convert.ToInt32(Console.ReadLine())) - 1;

            Console.WriteLine("\nBook stock has been successfully updated!");
            Console.WriteLine($"Book ID {books[bookChoice].BookID}: {books[bookChoice].Title} now has {books[bookChoice].ReduceStock(quantity)} stocks.");

            Console.WriteLine("\nChoose a book to reduce stock.\n");
            ViewBooks(books);
            bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;
        }
    }

    static void RemoveBooks(List<Book> books)
    {
        Console.WriteLine("\nChoose a book to remove.\n");
        ViewBooks(books);
        int bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;

        while (bookChoice >= 0 && bookChoice < books.Count)
        {

            books.RemoveAt(bookChoice);

            Console.WriteLine("\nBook list has been successfully updated!");

            Console.WriteLine("\nChoose a book to remove.\n");
            ViewBooks(books);
            bookChoice = (Convert.ToInt32(Console.ReadLine())) - 1;

        }
    }

    static void BookDisplay(List<Book> books, int bookChoice)
    {
        Console.WriteLine($"\nBook ID     : {books[bookChoice].BookID}");
        Console.WriteLine($"Title       : {books[bookChoice].Title}");
        Console.WriteLine($"Author      : {books[bookChoice].Author}");
        Console.WriteLine($"Description : {books[bookChoice].Description}");
        Console.WriteLine($"Publication : {books[bookChoice].Publication}");
        Console.WriteLine($"ISBN        : {books[bookChoice].ISBN}");
    }
}