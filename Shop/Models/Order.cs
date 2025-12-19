namespace Shop.Models;

public class Order
{
    public int Id { get; set; } 
    public string CustomerName { get; set; } = ""; // Имя клиента
    public string Address { get; set; } = ""; // Адрес доставки
    public DateTime OrderDate { get; set; } = DateTime.Now; // Дата заказа
    public List<OrderItem> Items { get; set; } = new(); // Список товаров в заказе
    public decimal TotalPrice => Items.Sum(item => (item.Product?.Price ?? 0) * item.Quantity); // Вычисляемое свойство для общей суммы
}