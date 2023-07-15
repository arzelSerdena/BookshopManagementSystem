using MySql.Data.MySqlClient;
public class Order
{
    public string connectionString = "server=localhost;database=bookshop_management_system;user=root;password= ;";

    public int GetOrderID()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT COUNT(*) FROM orders";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();

            long count = (long)command.ExecuteScalar();

            int orderID = Convert.ToInt32(count) + 1;


            return orderID;
        }
    }

    public void SendOrderToMySQL(int transactionNumber, int orderID, string date, int bookID, string title, double price, int orderQuantity, double orderAmount)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO orders (TransactionNumber, OrderID, Date, BookID, Title, Price, Quantity, TotalAmount) VALUES ({transactionNumber}, {orderID}, '{date}', {bookID}, '{title}', {price}, {orderQuantity}, {orderAmount});";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
    }
}