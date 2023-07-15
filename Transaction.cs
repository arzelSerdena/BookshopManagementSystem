using MySql.Data.MySqlClient;

public class Transaction
{
    public string connectionString = "server=localhost;database=bookshop_management_system;user=root;password= ;";

    // public DateTime Date { get; set; }
    // public int TransactionNumber { get; set; }
    // public int NumberOfItems { get; set; }
    // public double AmountDue { get; set; }
    // public double AmountOfCashPayment { get; set; }
    // public double ChangeDue { get; set; }

    // public Transaction(DateTime date, int transactionNumber, int numberOfItems, double amountDue, double payment, double changeDue)
    // {

    //     Date = DateTime.Now;
    //     TransactionNumber = transactionNumber;
    //     NumberOfItems = numberOfItems;
    //     AmountDue = amountDue;
    //     AmountOfCashPayment = payment;
    //     ChangeDue = changeDue;

    // }

    // public MySqlDataReader TransactionExists(int transactionNumber)
    // {
    //     using (MySqlConnection connection = new MySqlConnection(connectionString))
    //     {
    //         connection.Open();
    //         string query = $"SELECT * FROM transactions WHERE TransactionNumber = {transactionNumber}";
    //         MySqlCommand command = new MySqlCommand(query, connection);
    //         MySqlDataReader reader = command.ExecuteReader();

    //         return reader;
    //     }
    // }

    public int GetTransactionNumber()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT COUNT(*) FROM transactions";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();

            long count = (long)command.ExecuteScalar();

            int transactionNumber = Convert.ToInt32(count) + 1;

            return transactionNumber;
        }
    }

    public string GetDate()
    {
        DateTime now = DateTime.Now;
        string date = now.ToString("yyyy-MM-dd HH:mm:ss");
        return date;
    }

    public double GetAmountDue(int transactionNumber)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT SUM(TotalAmount) FROM orders WHERE TransactionNumber = {transactionNumber}";
            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();

            double amountDue = Convert.ToDouble(result);

            return amountDue;
        }
    }

    public int GetTotalQuantity(int transactionNumber)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT SUM(Quantity) FROM orders WHERE TransactionNumber = {transactionNumber}";
            MySqlCommand command = new MySqlCommand(query, connection);
            object result = command.ExecuteScalar();

            int totalQuantity = Convert.ToInt32(result);

            return totalQuantity;
        }
    }

    public void SendTransactionToMySQL(int transactionNumber, string date, string orders, int totalQuantity, double amountDue, double payment, double changeDue)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO transactions (TransactionNumber, Date, Orders, TotalQuantity, AmountDue, Payment, ChangeDue) VALUES ({transactionNumber}, '{date}', '{orders}', {totalQuantity}, {amountDue}, {payment}, {changeDue});";
            MySqlCommand command = new MySqlCommand(query, connection);

            command.ExecuteNonQuery();
        }
    }

    public string GetOrdersList(int transactionNumber)
    {
        string concatenatedBookIDs = string.Empty;

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT BookID FROM orders WHERE TransactionNumber = {transactionNumber}";
            MySqlCommand command = new MySqlCommand(query, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int bookID = (int)reader["bookID"];
                    concatenatedBookIDs += bookID.ToString() + ", ";
                }

                concatenatedBookIDs = concatenatedBookIDs.TrimEnd(',', ' ');
            }
            return concatenatedBookIDs;
        }
    }

    public (string date, int totalQuantity, double amountDue, double payment, double changeDue) GetTransactionDetails(int transactionNumber)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = $"SELECT Date, TotalQuantity, AmountDue, Payment, ChangeDue FROM transactions WHERE TransactionNumber = {transactionNumber}";
            MySqlCommand command = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string date = reader.GetString("Date");
                    int totalQuantity = reader.GetInt32("TotalQuantity");
                    double amountDue = reader.GetDouble("AmountDue");
                    double payment = reader.GetDouble("Payment");
                    double changeDue = reader.GetDouble("ChangeDue");

                    return (date, totalQuantity, amountDue, payment, changeDue);
                }
            }
        }
        return (string.Empty, 0, 0.0, 0.0, 0.0);
    }

    //TO DO

    // public void VoidTransaction()
    // {

    // }
}