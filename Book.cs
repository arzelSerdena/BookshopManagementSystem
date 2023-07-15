using MySql.Data.MySqlClient;

public class Book
{
    // public string Title { get; set; }
    // public string Author { get; set; }
    // public string Genre { get; set; }
    // public DateOnly PublicationDate { get; set; }
    // public string Publisher { get; set; }
    // public string ISBN { get; set; }
    // public double Price { get; set; }
    // public int Stock { get; set; }
    // public double TotalValue { get; set; }
    // public string ProductCode { get; set; }

    // public Book(string title, string author, string genre, DateOnly publicationDate, string publisher, string isbn, double price, int stock, double totalValue, string productCode)
    // {

    //     Title = title;
    //     Author = author;
    //     Genre = genre;
    //     PublicationDate = publicationDate;
    //     Publisher = publisher;
    //     ISBN = isbn;
    //     Price = price;
    //     Stock = stock;
    //     TotalValue = price * stock;
    //     ProductCode = productCode;
    // }

    MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;");

    public MySqlDataReader BookExists(string bookChoice)
    {
        connection.Open();
        string query = $"SELECT * FROM stocks WHERE BookID = {bookChoice}";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        return reader;
    }

    public void AddBook(string bookID, string title, string author, string genre, string publicationDate, string publisher, string isbn, double price, int stock, double totalValue)
    {
        connection.Open();

        string query = $"INSERT INTO stocks (BookID, Title, Author, Genre, Publication_Date, Publisher, ISBN, Price, Stock, Total_Value) VALUES ({bookID}, {title}, {author}, {genre}, {publicationDate}, {publisher}, {isbn}, {price}, {stock}, {totalValue});";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.ExecuteNonQuery();
    }

    public int AddStock(string bookChoice, int currentStock, int quantityToAdd)
    {
        connection.Open();

        int updatedStock = currentStock + quantityToAdd;

        string updateQuery = $"UPDATE stocks SET Stock = {updatedStock} WHERE BookID = {bookChoice}";
        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
        int rowsAffected = updateCommand.ExecuteNonQuery();

        return rowsAffected;
    }
    public int ReduceStock(string bookChoice, int currentStock, int quantityToRemove)
    {
        connection.Open();

        int updatedStock = currentStock - quantityToRemove;

        string updateQuery = $"UPDATE stocks SET Stock = {updatedStock} WHERE BookID = {bookChoice}";
        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
        int rowsAffected = updateCommand.ExecuteNonQuery();

        return rowsAffected;
    }

    public void RemoveBook(string bookChoice)
    {
        connection.Open();
        string query = $"DELETE FROM stocks WHERE BookID = {bookChoice}";
        MySqlCommand command = new MySqlCommand(query, connection);
        int rowsAffected = command.ExecuteNonQuery();

    }

    public void UpdateStockFromOrder(int stock, int orderQuantity, string bookChoice)
    {
        connection.Open();
        string updateQuery = $"UPDATE stocks SET Stock = {stock - orderQuantity} WHERE BookID = {bookChoice}";
        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
        int rowsAffected = updateCommand.ExecuteNonQuery();

    }

    public (string bookID, string title, string author, string genre, string publicationDate, string publisher, string isbn, double price, int stock, double totalValue) GetBookDetails()
    {
        connection.Open();
        string query = "SELECT BookID, Title, Author, Genre, Publication_Date, Publisher, ISBN, Price, Stock, Total_Value FROM stocks";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        string bookID = reader.GetString("BookID");
        string title = reader.GetString("Title");
        string author = reader.GetString("Author");
        string genre = reader.GetString("Genre");
        string publicationDate = reader.GetString("Publication_Date");
        string publisher = reader.GetString("Publisher");
        string isbn = reader.GetString("ISBN");
        double price = reader.GetDouble("Price");
        int stock = reader.GetInt32("Stock");
        double totalValue = reader.GetDouble("Total_Value");

        return (bookID, title, author, genre, publicationDate, publisher, isbn, price, stock, totalValue);
    }

    public string TestMySQLConnection()
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;");

        string message = " ";

        try
        {
            connection.Open();
            message = "Connected to MySQL!";
        }
        catch (Exception ex)
        {
            message = "Error: " + ex.Message;
        }

        return message;

    }

}