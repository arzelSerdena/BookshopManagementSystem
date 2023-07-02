public class BookPurchase
{
    public string Title { get; set; }
    public int OrderQuantity { get; set; }
    public double Price { get; set; }
    public double TotalAmount { get; set; }

    public BookPurchase(string title, double price, int orderQuantity, double totalAmount)
    {

        Title = title;
        Price = price;
        OrderQuantity = orderQuantity;
        TotalAmount = totalAmount;
    }
}