namespace Shop.Models;

public class Product
{
    public int Id { get; set; } 
    public string Name { get; set; } = "";
    public string Description { get; set; } = ""; // Описание
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = ""; // Ссылка на изображение
    public int CategoryId { get; set; } // Ссылка на категорию
    public Category? Category { get; set; } // Навигационное свойство к Category
}