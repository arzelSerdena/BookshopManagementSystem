using MySql.Data.MySqlClient;

class Program
{
    static Transaction transaction = null!;

    static void Main()
    {
        List<Transaction> transactions = new List<Transaction>();

        string connectionString = "server=localhost;database=bookshop_management_system;user=root;password= ;";
        MySqlConnection connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Connected to MySQL!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        DisplayMenu();
        string? userInput = Console.ReadLine();

        while (userInput != "0")
        {
            switch (userInput)
            {
                case "1":
                    NewTransaction(transactions, connectionString);
                    break;
                case "2":

                    Console.WriteLine("\nSelect a book to view more details.\n");
                    ViewBooks(connectionString);


                    string bookChoice = Console.ReadLine() ?? string.Empty;



                    while (bookChoice != "0")
                    {
                        BookDisplay(connectionString, bookChoice);

                        Console.WriteLine("\nSelect a book to view more details.\n");
                        ViewBooks(connectionString);


                        bookChoice = Console.ReadLine() ?? string.Empty;
                    }
                    break;
                case "3":
                    ViewStocks(connectionString);
                    break;
                case "4":
                    AddStocks(connectionString);
                    break;
                case "5":
                    AddBooks(connectionString);
                    break;
                case "6":
                    ReduceStocks(connectionString);
                    break;
                case "7":
                    RemoveBooks(connectionString);
                    break;
                default:
                    Console.WriteLine("\nInvalid input. Please try again.");
                    break;
            }
            DisplayMenu();
            userInput = Console.ReadLine();
        }
    }

    static void NewTransaction(List<Transaction> transactions, string connectionString)
    {
        transaction = new Transaction();
        List<BookPurchase> purchases = new List<BookPurchase>();

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            bool run = true;
            int userInput = 0;

            while (run == true)
            {
                Console.Write("\nEnter BookID or Press 0 to Exit: ");
                string? bookID = Console.ReadLine();

                if (bookID == "0")
                {
                    run = false;
                }


                string query = $"SELECT * FROM booksDirectory WHERE BookID = {bookID}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    bookID = reader.GetString("BookID");
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
                            string updateQuery = $"UPDATE booksDirectory SET Stock = {stock - orderQuantity} WHERE BookID = {bookID}";
                            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            purchases.Add(new BookPurchase(title, price, orderQuantity, orderQuantity * price));

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
                                double amountDue = transaction.GetAmountDue(purchases);
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
                                int transactionNumber = transactions.Count + 1;

                                transactions.Add(new Transaction(transaction.GetDate(), transactionNumber, transaction.GetNumberOfItems(purchases), amountDue, amountOfCashPayment, changeDue));

                                int index = transactions.FindIndex(transaction => transaction.TransactionNumber == transactionNumber);

                                PrintReceipt(purchases, transactions, index);




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

    static void ViewBooks(string connectionString)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT BookID, Title FROM booksDirectory";
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

    static void ViewStocks(string connectionString)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT BookID, Title, Stock FROM booksDirectory";
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

    static void AddStocks(string connectionString)
    {
        Console.WriteLine("\nChoose a book to add stock to.\n");
        ViewBooks(connectionString);
        string bookChoice = Console.ReadLine() ?? string.Empty;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                while (bookChoice != "0")
                {
                    Console.Write("Enter the number of stock to add: ");
                    int quantityToAdd = Convert.ToInt32(Console.ReadLine());

                    string selectQuery = $"SELECT * FROM booksDirectory WHERE BookID = {bookChoice}";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int currentStock = reader.GetInt32("Stock");
                        reader.Close();

                        int updatedStock = currentStock + quantityToAdd;

                        string updateQuery = $"UPDATE booksDirectory SET Stock = {updatedStock} WHERE BookID = {bookChoice}";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        int rowsAffected = updateCommand.ExecuteNonQuery();

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
                    ViewBooks(connectionString);
                    bookChoice = Console.ReadLine() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void AddBooks(string connectionString)
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

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO booksDirectory (BookID, Title, Author, Genre, Publication_Date, Publisher, ISBN, Price, Stock, Total_Value) VALUES ({bookID}, {title}, {author}, {genre}, {publicationDate}, {publisher}, {isbn}, {price}, {stock}, {totalValue});";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }

        Console.WriteLine("\nBook successfully added!");
    }

    static void ReduceStocks(string connectionString)
    {
        Console.WriteLine("\nChoose a book to reduce stock.\n");
        ViewBooks(connectionString);
        string bookChoice = Console.ReadLine() ?? string.Empty;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                while (bookChoice != "0")
                {
                    Console.Write("Enter the number of stock to deduct: ");
                    int quantityToRemove = Convert.ToInt32(Console.ReadLine());

                    string selectQuery = $"SELECT * FROM booksDirectory WHERE BookID = {bookChoice}";
                    MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                    MySqlDataReader reader = selectCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        int currentStock = reader.GetInt32("Stock");
                        reader.Close();

                        int updatedStock = currentStock - quantityToRemove;

                        string updateQuery = $"UPDATE booksDirectory SET Stock = {updatedStock} WHERE BookID = {bookChoice}";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        int rowsAffected = updateCommand.ExecuteNonQuery();

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
                    ViewBooks(connectionString);
                    bookChoice = Console.ReadLine() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void RemoveBooks(string connectionString)
    {
        Console.WriteLine("\nChoose a book to remove.\n");
        ViewBooks(connectionString);
        string bookChoice = Console.ReadLine() ?? string.Empty;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {

            try
            {
                while (bookChoice != "0")
                {
                    connection.Open();
                    string query = $"DELETE FROM booksDirectory WHERE BookID = {bookChoice}";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine("\nBook list has been successfully updated!");

                    Console.WriteLine("\nChoose a book to remove.\n");
                    ViewBooks(connectionString);
                    bookChoice = Console.ReadLine() ?? string.Empty;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static void BookDisplay(string connectionString, string bookChoice)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = $"SELECT * FROM booksDirectory WHERE BookID = {bookChoice}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string bookId = reader.GetString("BookID");
                    string title = reader.GetString("Title");
                    string author = reader.GetString("Author");
                    string genre = reader.GetString("Genre");
                    string publicationDate = reader.GetString("Publication_Date");
                    string publisher = reader.GetString("Publisher");
                    string isbn = reader.GetString("ISBN");
                    double price = reader.GetDouble("Price");
                    int stock = reader.GetInt32("Stock");
                    double totalValue = reader.GetDouble("Total_Value");

                    Console.WriteLine($"\nBook ID           : {bookId}");
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

    static void PrintReceipt(List<BookPurchase> purchases, List<Transaction> transactions, int i)
    {
        Transaction transaction = new Transaction();


        Console.WriteLine("\n-----------------------------------------------------");
        Console.WriteLine($"\nDate: {transactions[i].Date}");
        Console.WriteLine($"Transaction Number: XXXXXXXX{transactions[i].TransactionNumber}");
        Console.WriteLine($"\nQuantity     Title         Price");
        foreach (var purchase in purchases)
        {
            Console.WriteLine($"  {purchase.OrderQuantity}     {purchase.Title}     {purchase.Price}");
        }

        Console.WriteLine($"\nNumber of Items: {transactions[i].NumberOfItems}");
        Console.WriteLine($"Amount Due: {transactions[i].AmountDue}");
        Console.WriteLine($"Cash: {transactions[i].AmountOfCashPayment}");
        Console.WriteLine($"Change Due: {transactions[i].ChangeDue}");
        Console.WriteLine("\n-----------------------------------------------------");


    }

}
