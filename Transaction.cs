public class Transaction
{
    public DateTime Date { get; set; }
    public int TransactionNumber { get; set; }
    public int NumberOfItems { get; set; }
    public double AmountDue { get; set; }
    public double AmountOfCashPayment { get; set; }
    public double ChangeDue { get; set; }

    public Transaction(DateTime date, int transactionNumber, int numberOfItems, double amountDue, double amountOfCashPayment, double changeDue)
    {

        Date = DateTime.Now;
        TransactionNumber = transactionNumber;
        NumberOfItems = numberOfItems;
        AmountDue = amountDue;
        AmountOfCashPayment = amountOfCashPayment;
        ChangeDue = changeDue;

    }

    public Transaction()
    {
    }

    public DateTime GetDate()
    {
        return DateTime.Now;
    }

    public int GetNumberOfItems(List<BookPurchase> purchases)
    {
        int numberOfItems = 0;
        foreach (var purchase in purchases)
        {
            numberOfItems += purchase.OrderQuantity;
        }
        return numberOfItems;
    }

    public double GetAmountDue(List<BookPurchase> purchases)
    {
        double amountDue = 0;
        foreach (var purchase in purchases)
        {
            amountDue += purchase.OrderQuantity * purchase.Price;
        }
        return amountDue;


    }


}