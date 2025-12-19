using Shop.Models;

namespace Shop.Services;

public class ShopService : IShopService
{
    // база данных
    private readonly List<Category> _categories = new()
    {
        new Category { Id = 1, Name = "Футболки" },
        new Category { Id = 2, Name = "Штаны" },
        new Category { Id = 3, Name = "Обувь" },
        new Category { Id = 4, Name = "Куртки" },
        new Category { Id = 5, Name = "Аксессуары" }
    };

    private readonly List<Product> _products = new()
{
    // Футболки (CategoryId = 1)
    new Product { Id = 1, Name = "Футболка черная базовая", Description = "Классическая черная футболка из хлопка", Price = 999.99M, CategoryId = 1 },
    new Product { Id = 2, Name = "Футболка белая с принтом", Description = "Белая футболка с графическим принтом", Price = 1299.99M, CategoryId = 1 },
    new Product { Id = 3, Name = "Футболка серая oversize", Description = "Свободная футболка оверсайз", Price = 1499.99M, CategoryId = 1 },
    new Product { Id = 4, Name = "Футболка поло", Description = "Футболка-поло с воротником", Price = 1999.99M, CategoryId = 1 },
    new Product { Id = 5, Name = "Футболка с длинным рукавом", Description = "Футболка лонгслив для прохладной погоды", Price = 1799.99M, CategoryId = 1 },
    
    // Штаны (CategoryId = 2)
    new Product { Id = 6, Name = "Джинсы классические", Description = "Прямые синие джинсы", Price = 2999.99M, CategoryId = 2 },
    new Product { Id = 7, Name = "Брюки чинос", Description = "Хлопковые брюки чинос бежевого цвета", Price = 2499.99M, CategoryId = 2 },
    new Product { Id = 8, Name = "Спортивные штаны", Description = "Удобные штаны для тренировок", Price = 1899.99M, CategoryId = 2 },
    new Product { Id = 9, Name = "Джинсы скинни", Description = "Облегающие черные джинсы", Price = 3199.99M, CategoryId = 2 },
    new Product { Id = 10, Name = "Шорты джинсовые", Description = "Короткие джинсовые шорты", Price = 1999.99M, CategoryId = 2 },
    new Product { Id = 11, Name = "Брюки карго", Description = "Брюки с большими карманами", Price = 2799.99M, CategoryId = 2 },
    
    // Обувь (CategoryId = 3)
    new Product { Id = 12, Name = "Кроссовки беговые", Description = "Легкие кроссовки для бега", Price = 4999.99M, CategoryId = 3 },
    new Product { Id = 13, Name = "Кеды классические", Description = "Белые кеды из кожи", Price = 3499.99M, CategoryId = 3 },
    new Product { Id = 14, Name = "Ботинки зимние", Description = "Теплые ботинки на меху", Price = 5999.99M, CategoryId = 3 },
    new Product { Id = 15, Name = "Туфли офисные", Description = "Кожаные туфли для делового стиля", Price = 4599.99M, CategoryId = 3 },
    new Product { Id = 16, Name = "Сандалии летние", Description = "Открытые сандалии для пляжа", Price = 1999.99M, CategoryId = 3 },
    new Product { Id = 17, Name = "Сапоги женские", Description = "Высокие сапоги на каблуке", Price = 6999.99M, CategoryId = 3 },
    
    // Куртки (CategoryId = 4)
    new Product { Id = 18, Name = "Куртка ветровка", Description = "Легкая ветронепроницаемая куртка", Price = 3999.99M, CategoryId = 4 },
    new Product { Id = 19, Name = "Пуховик зимний", Description = "Теплый пуховик для морозов", Price = 8999.99M, CategoryId = 4 },
    new Product { Id = 20, Name = "Джинсовая куртка", Description = "Классическая джинсовая куртка", Price = 4599.99M, CategoryId = 4 },
    new Product { Id = 21, Name = "Кожаная куртка", Description = "Куртка из натуральной кожи", Price = 12999.99M, CategoryId = 4 },
    
    // Аксессуары (CategoryId = 5)
    new Product { Id = 22, Name = "Бейсболка", Description = "Хлопковая бейсболка с логотипом", Price = 899.99M, CategoryId = 5 },
    new Product { Id = 23, Name = "Ремень кожаный", Description = "Классический кожаный ремень", Price = 1499.99M, CategoryId = 5 },
    new Product { Id = 24, Name = "Шарф вязаный", Description = "Теплый шерстяной шарф", Price = 1299.99M, CategoryId = 5 },
    new Product { Id = 25, Name = "Перчатки кожаные", Description = "Кожаные перчатки для зимы", Price = 1999.99M, CategoryId = 5 }
};

    private readonly List<Order> _orders = new(); // История заказов

    private List<OrderItem> _cartItems = new(); // Текущая корзина

    // Реализация методов интервейса
    public List<Category> GetCategories() => _categories;

    public List<Product> GetProducts() => _products;

    public List<Product> GetProductsByCategory(int categoryId)
        => _products.Where(p => p.CategoryId == categoryId).ToList();

    public Product? GetProductById(int id)
        => _products.FirstOrDefault(p => p.Id == id);

    public List<OrderItem> GetCartItems() => _cartItems;

    public void AddToCart(Product product, int quantity = 1)
    {
        var existingItem = _cartItems.FirstOrDefault(item => item.ProductId == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            _cartItems.Add(new OrderItem { ProductId = product.Id, Product = product, Quantity = quantity });
        }
    }

    public void RemoveFromCart(int productId)
    {
        var item = _cartItems.FirstOrDefault(item => item.ProductId == productId);
        if (item != null)
        {
            _cartItems.Remove(item);
        }
    }

    public void ClearCart() => _cartItems.Clear();

    public void PlaceOrder(Order order)
    {
        order.Items = new List<OrderItem>(_cartItems); // Копируем корзину
        order.Id = _orders.Count + 1; 
        order.OrderDate = DateTime.Now;

        _orders.Add(order); // Добавляем в историю
        ClearCart(); 
    }

    public List<Order> GetOrderHistory() => _orders;
}