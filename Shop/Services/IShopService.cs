using Shop.Models;

namespace Shop.Services;

public interface IShopService
{
    // Категории
    List<Category> GetCategories();

    // Товары
    List<Product> GetProducts();
    List<Product> GetProductsByCategory(int categoryId);
    Product? GetProductById(int id);

    // Корзина
    List<OrderItem> GetCartItems();
    void AddToCart(Product product, int quantity = 1);
    void RemoveFromCart(int productId);
    void ClearCart();

    // Заказы
    void PlaceOrder(Order order);
    List<Order> GetOrderHistory();
}