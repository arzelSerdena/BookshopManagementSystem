using MySql.Data.MySqlClient;

class Program
{
    static Transaction transaction = null!;
    static Book book = null!;
    static Order order = null!;

    static void Main()
    {
        Book book = new Book();

        Console.WriteLine(book.TestMySQLConnection());

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

                    int bookID = Convert.ToInt32(Console.ReadLine());

                    while (bookID != 0)
                    {
                        BookDisplay(bookID);

                        Console.WriteLine("\nSelect a book to view more details.\n");
                        ViewBooks();

                        bookID = Convert.ToInt32(Console.ReadLine());
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
        Book book = new Book();

        Transaction transaction = new Transaction();

        Order order = new Order();

        bool run = true;
        int userInput = 0;

        while (run == true)
        {
            Console.Write("\nEnter BookID or Press 0 to Exit: ");
            int bookID = Convert.ToInt32(Console.ReadLine());

            if (bookID == 0)
            {
                run = false;
            }

            bool exists = new Book().BookExists(bookID);

            if (exists == true)
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;");
                connection.Open();
                string query = $"SELECT BookID, Title, Price, Stock FROM stocks where BookID = {bookID}";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bookID = reader.GetInt32("BookID");
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
                                book.UpdateStockFromOrder(stock, orderQuantity, bookID);

                                double orderAmount = price * orderQuantity;
                                int orderID = order.GetOrderID();
                                int transactionNumber = transaction.GetTransactionNumber();
                                string date = transaction.GetDate();

                                order.SendOrderToMySQL(transactionNumber, orderID, date, bookID, title, price, orderQuantity, orderAmount);

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
                                    double payment = Convert.ToInt32(Console.ReadLine());

                                    while (payment < amountDue)
                                    {
                                        Console.WriteLine($"\nInsufficient cash. Your amount due is {amountDue}.");
                                        Console.Write("\nEnter cash amount: ");
                                        payment = Convert.ToInt32(Console.ReadLine());
                                    }

                                    double changeDue = payment - amountDue;
                                    int totalQuantity = transaction.GetTotalQuantity(transactionNumber);
                                    string orders = transaction.GetOrdersList(transactionNumber);
                                    transaction.SendTransactionToMySQL(transactionNumber, date, orders, totalQuantity, amountDue, payment, changeDue);

                                    PrintReceipt(transactionNumber);




                                }
                            }
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("\nBook not found. Please check BookID.");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n ------------------------------ ");
        Console.WriteLine("|  BOOKSHOP MANAGEMENT SYSTEM  |");
        Console.WriteLine(" ------------------------------ ");
        Console.WriteLine("\nMENU");
        Console.WriteLine("1. New Transactions");
        Console.WriteLine("2. View Books");
        Console.WriteLine("3. View Stock");
        Console.WriteLine("4. Add Stocks");
        Console.WriteLine("5. Add Books");
        Console.WriteLine("6. Reduce Stock");
        Console.WriteLine("7. Remove Books");

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
                    int bookID = reader.GetInt32("BookID");
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
                    int bookID = reader.GetInt32("BookID");
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
        Book book = new Book();

        Console.WriteLine("\nChoose a book to add stock to.\n");
        ViewBooks();
        int bookID = Convert.ToInt32(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();
                while (bookID != 0)
                {
                    Console.Write("Enter the number of stock to add: ");
                    int quantityToAdd = Convert.ToInt32(Console.ReadLine());

                    bool exists = book.BookExists(bookID);

                    if (exists == true)
                    {
                        string query = "SELECT Stock FROM stocks";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int currentStock = reader.GetInt32("Stock");
                                int rowsAffected = book.AddStock(bookID, currentStock, quantityToAdd);

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
                                throw new Exception("No book found.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid book ID. Please choose a valid book.");
                    }

                    Console.WriteLine("\nChoose a book to add stock to.\n");
                    ViewBooks();
                    bookID = Convert.ToInt32(Console.ReadLine());
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
        Book book = new Book();

        Console.WriteLine("\nEnter the following information for the new book.");
        Console.Write("\nBook ID: ");
        int bookID = Convert.ToInt32(Console.ReadLine());
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? string.Empty;
        Console.Write("Author: ");
        string author = Console.ReadLine() ?? string.Empty;
        Console.Write("Genre: ");
        string genre = Console.ReadLine() ?? string.Empty;
        Console.Write("Year Published: ");
        string yearPublished = Console.ReadLine() ?? string.Empty;
        Console.Write("Publisher: ");
        string publisher = Console.ReadLine() ?? string.Empty;
        Console.Write("ISBN: ");
        string isbn = Console.ReadLine() ?? string.Empty;
        Console.Write("Price: ");
        double price = Convert.ToDouble(Console.ReadLine());
        Console.Write("Stock: ");
        int stock = Convert.ToInt32(Console.ReadLine());
        double value = price * stock;

        book.AddBook(bookID, title, author, genre, yearPublished, publisher, isbn, price, stock, value);

        Console.WriteLine("\nBook successfully added!");
    }

    static void ReduceStocks()
    {
        Book book = new Book();

        Console.WriteLine("\nChoose a book to reduce stock.\n");
        ViewBooks();
        int bookID = Convert.ToInt32(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();
                while (bookID != 0)
                {
                    Console.Write("Enter the number of stock to deduct: ");
                    int quantityToRemove = Convert.ToInt32(Console.ReadLine());

                    bool exists = book.BookExists(bookID);

                    if (exists == true)
                    {
                        string query = "SELECT Stock FROM stocks";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int currentStock = reader.GetInt32("Stock");

                                int rowsAffected = book.ReduceStock(bookID, currentStock, quantityToRemove);

                                if (rowsAffected != currentStock)
                                {
                                    Console.WriteLine("\nBook stock has been successfully updated!");
                                }
                                else
                                {
                                    Console.WriteLine("\nFailed to update book stock.");
                                }
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("\nInvalid book ID. Please choose a valid book.");
                    }

                    Console.WriteLine("\nChoose a book to reduce stock.\n");
                    ViewBooks();
                    bookID = Convert.ToInt32(Console.ReadLine());
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
        Book book = new Book();

        Console.WriteLine("\nChoose a book to remove.\n");
        ViewBooks();
        int bookID = Convert.ToInt32(Console.ReadLine());

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                while (bookID != 0)
                {
                    book.RemoveBook(bookID);

                    Console.WriteLine("\nBook list has been successfully updated!");

                    Console.WriteLine("\nChoose a book to remove.\n");
                    ViewBooks();
                    bookID = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void BookDisplay(int bookID)
    {
        Book book = new Book();

        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                connection.Open();

                bool exists = book.BookExists(bookID);

                if (exists == true)
                {
                    (bookID, string title, string author, string genre, string yearPublished, string publisher, string isbn, double price, int stock, double value) = book.GetBookDetails();

                    Console.WriteLine($"\nBook ID           : {bookID}");
                    Console.WriteLine($"Title             : {title}");
                    Console.WriteLine($"Author            : {author}");
                    Console.WriteLine($"Genre             : {genre}");
                    Console.WriteLine($"Year Published    : {yearPublished}");
                    Console.WriteLine($"Publisher         : {publisher}");
                    Console.WriteLine($"ISBN              : {isbn}");
                    Console.WriteLine($"Price             : {price}");
                    Console.WriteLine($"Stock             : {stock}");
                    Console.WriteLine($"Value             : {value}");
                }
                else
                {
                    Console.WriteLine($"Row with ID {bookID} not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void PrintReceipt(int transactionNumber)
    {
        Transaction transaction = new Transaction();
        using (MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;"))
        {
            try
            {
                (string date, int totalQuantity, double amountDue, double payment, double changeDue) = transaction.GetTransactionDetails(transactionNumber);

                Console.WriteLine("\n-----------------------------------------------------");
                Console.WriteLine($"\nDate: {date}");
                Console.WriteLine($"Transaction Number: XXXXXXXX{transactionNumber}");

                try
                {
                    connection.Open();
                    string query = $"SELECT Title, Price, Quantity, TotalAmount FROM orders WHERE TransactionNumber = {transactionNumber}";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string title = reader.GetString("Title");
                            double price = reader.GetDouble("Price");
                            int quantity = reader.GetInt32("Quantity");
                            double totalAmount = reader.GetDouble("TotalAmount");

                            Console.WriteLine($"\n{title}");
                            Console.WriteLine($"  {quantity}   {price}   {totalAmount}");
                        }

                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

                Console.WriteLine($"\nNumber of Items: {totalQuantity}");
                Console.WriteLine($"Amount Due: {amountDue}");
                Console.WriteLine($"Cash: {payment}");
                Console.WriteLine($"Change Due: {changeDue}");
                Console.WriteLine("\n-----------------------------------------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}