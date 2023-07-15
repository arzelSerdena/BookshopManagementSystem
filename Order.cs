// TransactionNumber, OrderID, Date, BookID, Title, Price, Quantity, TotalAmount

using MySql.Data.MySqlClient;
public class Order
{
    // public string Title { get; set; }
    // public int OrderQuantity { get; set; }
    // public double Price { get; set; }
    // public double TotalAmount { get; set; }

    // public Order(string title, double price, int orderQuantity, double totalAmount)
    // {

    //     Title = title;
    //     Price = price;
    //     OrderQuantity = orderQuantity;
    //     TotalAmount = totalAmount;
    // }

    MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;");

    public int GetOrderID()
    {
        connection.Open();
        string query = $"SELECT COUNT(*) FROM orders";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.ExecuteNonQuery();

        int orderID = (int)command.ExecuteScalar() + 1;

        return orderID;

    }

    public void SendOrderToMySQL(int transactionNumber, string date, string bookChoice, string title, double price, int orderQuantity, double orderAmount)
    {
        connection.Open();

        string query = $"INSERT INTO orders (TransactionNumber, OrderID, Date, BookID, Title, Price, Quantity, TotalAmount) VALUES ({transactionNumber}, {date}, {bookChoice}, {title}, {orderQuantity}, {orderAmount});";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.ExecuteNonQuery();
    }

    //TO DO

    // public void VoidOrder()
    // {

    // }

    // public void EditOrderQuantity()
    // {

    // }

}