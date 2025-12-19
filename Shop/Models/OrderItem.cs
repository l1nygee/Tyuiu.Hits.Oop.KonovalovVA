namespace Shop.Models;

public class OrderItem
{
    public int ProductId { get; set; } 
    public Product? Product { get; set; } // Ссылка на сам товар
    public int Quantity { get; set; } // Количество этого товара в заказе
}