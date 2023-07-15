using MySql.Data.MySqlClient;

public class Book
{
    public string connectionString = "server=localhost;database=bookshop_management_system;user=root;password= ;";
    // public string Title { get; set; }
    // public string Author { get; set; }
    // public string Genre { get; set; }
    // public DateOnly YearPublished { get; set; }
    // public string Publisher { get; set; }
    // public string ISBN { get; set; }
    // public double Price { get; set; }
    // public int Stock { get; set; }
    // public double Value { get; set; }
    // public string ProductCode { get; set; }

    // public Book(string title, string author, string genre, DateOnly yearPublished, string publisher, string isbn, double price, int stock, double value, string productCode)
    // {

    //     Title = title;
    //     Author = author;
    //     Genre = genre;
    //     YearPublished = yearPublished;
    //     Publisher = publisher;
    //     ISBN = isbn;
    //     Price = price;
    //     Stock = stock;
    //     Value = price * stock;
    //     ProductCode = productCode;
    // }

    public bool BookExists(int bookID)
    {
        bool exists = false;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT * FROM stocks WHERE BookID = {bookID}";
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            if (count > 0)
            {
                exists = true;
            }
        }
        return exists;
    }

    public void AddBook(int bookID, string title, string author, string genre, string yearPublished, string publisher, string isbn, double price, int stock, double value)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO stocks (BookID, Title, Author, Genre, YearPublished, Publisher, ISBN, Price, Stock, Value) VALUES ({bookID}, '{title}', '{author}', '{genre}', '{yearPublished}', '{publisher}', '{isbn}', {price}, {stock}, {value});";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }

    public int AddStock(int bookID, int currentStock, int quantityToAdd)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            int updatedStock = currentStock + quantityToAdd;

            string updateQuery = $"UPDATE stocks SET Stock = {updatedStock} WHERE BookID = {bookID}";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
            int rowsAffected = updateCommand.ExecuteNonQuery();

            return rowsAffected;
        }
    }

    public int ReduceStock(int bookID, int currentStock, int quantityToRemove)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            int updatedStock = currentStock - quantityToRemove;

            string updateQuery = $"UPDATE stocks SET Stock = {updatedStock} WHERE BookID = {bookID}";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
            int rowsAffected = updateCommand.ExecuteNonQuery();

            return rowsAffected;
        }
    }

    public void RemoveBook(int bookID)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"DELETE FROM stocks WHERE BookID = {bookID}";
            MySqlCommand command = new MySqlCommand(query, connection);
            int rowsAffected = command.ExecuteNonQuery();
        }
    }

    public void UpdateStockFromOrder(int stock, int orderQuantity, int bookID)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string updateQuery = $"UPDATE stocks SET Stock = {stock - orderQuantity} WHERE BookID = {bookID}";
            MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
            int rowsAffected = updateCommand.ExecuteNonQuery();
        }
    }

    public (int bookID, string title, string author, string genre, string yearPublished, string publisher, string isbn, double price, int stock, double value) GetBookDetails()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT BookID, Title, Author, Genre, YearPublished, Publisher, ISBN, Price, Stock, Value FROM stocks";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int bookID = reader.GetInt32("BookID");
                    string title = reader.GetString("Title");
                    string author = reader.GetString("Author");
                    string genre = reader.GetString("Genre");
                    string yearPublished = reader.GetString("YearPublished");
                    string publisher = reader.GetString("Publisher");
                    string isbn = reader.GetString("ISBN");
                    double price = reader.GetDouble("Price");
                    int stock = reader.GetInt32("Stock");
                    double value = reader.GetDouble("Value");

                    return (bookID, title, author, genre, yearPublished, publisher, isbn, price, stock, value);
                }

                else
                {
                    throw new Exception("No book found.");
                }

            }
        }
    }

    public string TestMySQLConnection()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string message = " ";

            try
            {
                message = "Connected to MySQL!";
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
            }

            return message;
        }
    }
}