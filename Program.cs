using MySql.Data.MySqlClient;

class Program
{
    static Transaction transaction = null!;

    static Book book = null!;

    static Order order = null!;

    static void Main()
    {
        List<Transaction> transactions = new List<Transaction>();

        book.TestMySQLConnection();

        DisplayMenu();
        string? userInput = Console.ReadLine();

        while (userInput != "0")
        {
            switch (userInput)
            {
                case "1":
                    NewTransaction();
                    break;
                case "2":

                    Console.WriteLine("\nSelect a book to view more details.\n");
                    ViewBooks();

                    string bookChoice = Console.ReadLine() ?? string.Empty;

                    while (bookChoice != "0")
                    {
                        BookDisplay(bookChoice);

                        Console.WriteLine("\nSelect a book to view more details.\n");
                        ViewBooks();

                        bookChoice = Console.ReadLine() ?? string.Empty;
                    }
                    break;
                case "3":
                    ViewStocks();
                    break;
                case "4":
                    AddStocks();
                    break;
                case "5":
                    AddBooks();
                    break;
                case "6":
                    ReduceStocks();
                    break;
                case "7":
                    RemoveBooks();
                    break;
                default:
                    Console.WriteLine("\nInvalid input. Please try again.");
                    break;
            }
            DisplayMenu();
            userInput = Console.ReadLine();
        }
    }

    static void NewTransaction()
    {
        int transactionNumber = transaction.GetTransactionNumber();

        string date = transaction.GetDate();

        bool run = true;
        int userInput = 0;

        while (run == true)
        {
            Console.Write("\nEnter BookID or Press 0 to Exit: ");
            string bookChoice = Console.ReadLine() ?? string.Empty;

            if (bookChoice == "0")
            {
                run = false;
            }

            MySqlDataReader reader = book.BookExists(bookChoice);

            if (reader.Read())
            {
                bookChoice = reader.GetString("BookID");
                string title = reader.GetString("Title");
                double price = reader.GetDouble("Price");
                int stock = reader.GetInt32("Stock");

                reader.Close();

                if (stock == 0)
                {
                    Console.WriteLine("Books is out of stock. Please pick another book.");
                }
                else
                {
                    Console.Write("\nEnter quantity to order: ");
                    int orderQuantity = Convert.ToInt32(Console.ReadLine());

                    if (orderQuantity > stock)
                    {
                        Console.WriteLine($"\nBook insufficient stock. Stock available is {stock} only.");
                    }
                    else
                    {
                        book.UpdateStockFromOrder(stock, orderQuantity, bookChoice);

                        double orderAmount = price * orderQuantity;

                        int orderID = order.GetOrderID();

                        order.SendOrderToMySQL(transactionNumber, date, bookChoice, title, price, orderQuantity, orderAmount);

                        Console.WriteLine("\nChoose what to do next.");
                        Console.WriteLine("1. Add more orders.");
                        Console.WriteLine("2. Proceed to checkout.");
                        Console.WriteLine("Press 0 to cancel this transaction.\n");
                        Console.Write("\nEnter your choice: ");
                        userInput = Convert.ToInt32(Console.ReadLine());

                        if (userInput == 0)
                        {
                            run = false;
                        }
                        else if (userInput == 2)
                        {
                            double amountDue = transaction.GetAmountDue(transactionNumber);

                            Console.WriteLine($"\nAmount Due: {amountDue}");
                            Console.Write("\nEnter cash amount: ");
                            double amountOfCashPayment = Convert.ToInt32(Console.ReadLine());

                            while (amountOfCashPayment < amountDue)
                            {
                                Console.WriteLine($"\nInsufficient cash. Your amount due is {amountDue}.");
                                Console.Write("\nEnter cash amount: ");
                                amountOfCashPayment = Convert.ToInt32(Console.ReadLine());
                            }

                            double changeDue = amountOfCashPayment - amountDue;

                            int totalQuantity = transaction.GetTotalQuantity(transactionNumber);

                            string orders = transaction.GetOrdersList(transactionNumber, reader);

                            transaction.SendTransactionToMySQL(transactionNumber, date, orders, totalQuantity, amountDue, amountOfCashPayment, changeDue);


                            PrintReceipt(transactionNumber);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nBook not found. Please check BookID.");

            }

            reader.Close();
        }



    }

    static void DisplayMenu()
    {
        int count = 1;

        string[] menu = new string[7] { "New Transactions", "View Books", "View Stock", "Add Stocks", "Add Books", "Reduce Stock", "Remove Books" };

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

    static void ViewBooks()
    {
        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();
                string query = "SELECT BookID, Title FROM stocks";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string bookID = reader.GetString("BookID");
                    string title = reader.GetString("Title");

                    Console.WriteLine(bookID + ". " + title);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        Console.WriteLine("\nPress 0 to Exit");
        Console.Write("\nEnter your choice: ");
    }

    static void ViewStocks()
    {
        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();
                string query = "SELECT BookID, Title, Stock FROM stocks";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine(" ");

                while (reader.Read())
                {
                    string bookID = reader.GetString("BookID");
                    string title = reader.GetString("Title");
                    int stock = reader.GetInt32("Stock");

                    Console.WriteLine(bookID + ". " + title + " - " + stock);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void AddStocks()
    {

        Console.WriteLine("\nChoose a book to add stock to.\n");
        ViewBooks();
        string bookChoice = Console.ReadLine() ?? string.Empty;

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();
                while (bookChoice != "0")
                {
                    Console.Write("Enter the number of stock to add: ");
                    int quantityToAdd = Convert.ToInt32(Console.ReadLine());

                    MySqlDataReader reader = book.BookExists(bookChoice);

                    if (reader.Read())
                    {
                        int currentStock = reader.GetInt32("Stock");

                        int rowsAffected = book.AddStock(bookChoice, currentStock, quantityToAdd);

                        if (rowsAffected != currentStock)
                        {
                            Console.WriteLine("\nBook stock has been successfully updated!");
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to update book stock.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid book ID. Please choose a valid book.");
                    }

                    Console.WriteLine("\nChoose a book to add stock to.\n");
                    ViewBooks();
                    bookChoice = Console.ReadLine() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void AddBooks()
    {
        Console.WriteLine("\nEnter the following information for the new book.");
        Console.Write("\nBook ID: ");
        string bookID = Console.ReadLine() ?? string.Empty;
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? string.Empty;
        Console.Write("Author: ");
        string author = Console.ReadLine() ?? string.Empty;
        Console.Write("Genre: ");
        string genre = Console.ReadLine() ?? string.Empty;
        Console.Write("Publication Date (YYYY-MM-DD): ");
        string publicationDate = Console.ReadLine() ?? string.Empty;
        Console.Write("Publisher: ");
        string publisher = Console.ReadLine() ?? string.Empty;
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine() ?? string.Empty;
        Console.Write("Price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        Console.Write("Stock: ");
        int stock = Convert.ToInt32(Console.ReadLine());
        double totalValue = Convert.ToDouble(Console.ReadLine());

        book.AddBook(bookID, title, author, genre, publicationDate, publisher, isbn, price, stock, totalValue);

        Console.WriteLine("\nBook successfully added!");
    }

    static void ReduceStocks()
    {
        Console.WriteLine("\nChoose a book to reduce stock.\n");
        ViewBooks();
        string bookChoice = Console.ReadLine() ?? string.Empty;

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();
                while (bookChoice != "0")
                {
                    Console.Write("Enter the number of stock to deduct: ");
                    int quantityToRemove = Convert.ToInt32(Console.ReadLine());

                    MySqlDataReader reader = book.BookExists(bookChoice);

                    if (reader.Read())
                    {
                        int currentStock = reader.GetInt32("Stock");

                        int rowsAffected = book.ReduceStock(bookChoice, currentStock, quantityToRemove);

                        if (rowsAffected != currentStock)
                        {
                            Console.WriteLine("\nBook stock has been successfully updated!");
                        }
                        else
                        {
                            Console.WriteLine("\nFailed to update book stock.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid book ID. Please choose a valid book.");
                    }

                    Console.WriteLine("\nChoose a book to reduce stock.\n");
                    ViewBooks();
                    bookChoice = Console.ReadLine() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void RemoveBooks()
    {
        Console.WriteLine("\nChoose a book to remove.\n");
        ViewBooks();
        string bookChoice = Console.ReadLine() ?? string.Empty;

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {

            try
            {
                while (bookChoice != "0")
                {
                    book.RemoveBook(bookChoice);

                    Console.WriteLine("\nBook list has been successfully updated!");

                    Console.WriteLine("\nChoose a book to remove.\n");
                    ViewBooks();
                    bookChoice = Console.ReadLine() ?? string.Empty;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void BookDisplay(string bookChoice)
    {
        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                MySqlDataReader reader = book.BookExists(bookChoice);

                if (reader.Read())
                {
                    (string bookID, string title, string author, string genre, string publicationDate, string publisher, string isbn, double price, int stock, double totalValue) = book.GetBookDetails();

                    Console.WriteLine($"\nBook ID           : {bookID}");
                    Console.WriteLine($"Title             : {title}");
                    Console.WriteLine($"Author            : {author}");
                    Console.WriteLine($"Genre             : {genre}");
                    Console.WriteLine($"Publication Date  : {publicationDate}");
                    Console.WriteLine($"Publisher         : {publisher}");
                    Console.WriteLine($"ISBN              : {isbn}");
                    Console.WriteLine($"Price             : {price}");
                    Console.WriteLine($"Stock             : {stock}");
                    Console.WriteLine($"Total Value       : {totalValue}");
                }
                else
                {
                    Console.WriteLine($"Row with ID {bookChoice} not found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void PrintReceipt(int transactionNumber)
    {
        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                MySqlDataReader reader = transaction.TransactionExists(transactionNumber);

                if (reader.Read())
                {
                    (string date, int totalQuantity, double amountDue, double amountOfCashPayment, double changeDue) = transaction.GetTransactionDetails();

                    Console.WriteLine("\n-----------------------------------------------------");
                    Console.WriteLine($"\nDate: {date}");
                    Console.WriteLine($"Transaction Number: XXXXXXXX{transactionNumber}");
                    Console.WriteLine($"\nQuantity     Title         Price");

                    try
                    {
                        connection.Open();
                        string query = $"SELECT Title, Price, Quantity, TotalAmount FROM orders WHERE TransactionNumber = {transactionNumber}";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        int i = 1;

                        while (reader.Read())
                        {
                            string title = reader.GetString("Title");
                            double price = reader.GetDouble("Price");
                            int quantity = reader.GetInt32("Quantity");
                            double totalAmount = reader.GetDouble("TotalAmount");

                            Console.WriteLine($"\n{i}. Title");
                            Console.WriteLine($"   {quantity}   {price}   {totalAmount}");
                            i++;
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    Console.WriteLine($"\nNumber of Items: {totalQuantity}");
                    Console.WriteLine($"Amount Due: {amountDue}");
                    Console.WriteLine($"Cash: {amountOfCashPayment}");
                    Console.WriteLine($"Change Due: {changeDue}");
                    Console.WriteLine("\n-----------------------------------------------------");
                }
                else
                {
                    Console.WriteLine($"Row with Transaction Number {transactionNumber} not found.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}