// transaction number, date, orders, total quantity, amount due, payment, change due

using MySql.Data.MySqlClient;

public class Transaction
{
    // public DateTime Date { get; set; }
    // public int TransactionNumber { get; set; }
    // public int NumberOfItems { get; set; }
    // public double AmountDue { get; set; }
    // public double AmountOfCashPayment { get; set; }
    // public double ChangeDue { get; set; }

    // public Transaction(DateTime date, int transactionNumber, int numberOfItems, double amountDue, double amountOfCashPayment, double changeDue)
    // {

    //     Date = DateTime.Now;
    //     TransactionNumber = transactionNumber;
    //     NumberOfItems = numberOfItems;
    //     AmountDue = amountDue;
    //     AmountOfCashPayment = amountOfCashPayment;
    //     ChangeDue = changeDue;

    // }

    MySqlConnection connection = new MySqlConnection("server=localhost;database=bookshop_management_system;user=root;password= ;");

    public MySqlDataReader TransactionExists(int transactionNumber)
    {
        connection.Open();
        string query = $"SELECT * FROM transactions WHERE TransactionNumber = {transactionNumber}";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        return reader;
    }

    public int GetTransactionNumber()
    {
        connection.Open();
        string query = $"SELECT COUNT(*) FROM transactions";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.ExecuteNonQuery();

        int transactionNumber = (int)command.ExecuteScalar() + 1;

        return transactionNumber;

    }

    public string GetDate()
    {
        DateTime now = DateTime.Now;
        string date = now.ToString("yyyy-MM-dd HH:mm:ss");
        return date;
    }

    public double GetAmountDue(int transactionNumber)
    {
        connection.Open();
        string query = $"SELECT SUM(Price) FROM orders WHERE TransactionNumber = {transactionNumber}";
        MySqlCommand command = new MySqlCommand(query, connection);
        object result = command.ExecuteScalar();

        double amountDue = Convert.ToDouble(result);

        return amountDue;

    }

    public int GetTotalQuantity(int transactionNumber)
    {
        connection.Open();
        string query = $"SELECT SUM(Quantity) FROM orders WHERE TransactionNumber = {transactionNumber}";
        MySqlCommand command = new MySqlCommand(query, connection);
        object result = command.ExecuteScalar();

        int totalQuantity = Convert.ToInt32(result);

        return totalQuantity;

    }

    //TO DO

    // public void VoidTransaction()
    // {

    // }

    public void SendTransactionToMySQL(int transactionNumber, string date, string orders, int totalQuantity, double amountDue, double amountOfCashPayment, double changeDue)
    {
        connection.Open();

        string query = $"INSERT INTO transactions (TransactionNumber, Date, Orders, TotalQuantity, AmountDue, Payment, ChangeDue) VALUES ({transactionNumber}, {date}, {orders}, {totalQuantity}, {amountDue}, {amountOfCashPayment}, {changeDue});";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.ExecuteNonQuery();

    }

    public string GetOrdersList(int transactionNumber, MySqlDataReader reader)
    {
        string concatenatedBookIDs = string.Empty;

        connection.Open();
        string query = $"SELECT BookID FROM orders WHERE TransactionNumber = {transactionNumber}";
        MySqlCommand command = new MySqlCommand(query, connection);

        while (reader.Read())
        {
            int bookID = (int)reader["bookID"];
            concatenatedBookIDs += bookID.ToString() + ", ";
        }

        concatenatedBookIDs = concatenatedBookIDs.TrimEnd(',', ' ');

        return concatenatedBookIDs;
    }

    public (string date, int totalQuantity, double amountDue, double amountOfCashPayment, double changeDue) GetTransactionDetails()
    {
        connection.Open();
        string query = "SELECT Date, TotalQuantity, AmountDue, Payment, ChangeDue FROM transactions";
        MySqlCommand command = new MySqlCommand(query, connection);
        MySqlDataReader reader = command.ExecuteReader();

        string date = reader.GetString("Date");
        int totalQuantity = reader.GetInt32("TotalQuantity");
        double amountDue = reader.GetDouble("AmountDue");
        double amountOfCashPayment = reader.GetDouble("Payment");
        double changeDue = reader.GetDouble("ChangeDue");

        return (date, totalQuantity, amountDue, amountOfCashPayment, changeDue);
    }
}