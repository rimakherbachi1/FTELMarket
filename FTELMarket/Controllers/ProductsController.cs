using Microsoft.AspNetCore.Mvc;

namespace FTELMarket.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // 1. Définition des modèles de réponse
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
        }

        // 2. Initialisation de données statiques en mémoire
        private static readonly List<Category> Categories = new()
        {
            new Category { Id = 1, Name = "Jeux de société" },
            new Category { Id = 2, Name = "Jeux vidéo" }
        };

        private static readonly List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Catan", Price = 45.00m, CategoryId = 1 },
            new Product { Id = 2, Name = "Mario Kart 8", Price = 49.99m, CategoryId = 2 }
        };

        // 3. Implémentation des routes

        [HttpGet("/products")]
        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }

        [HttpGet("/categories")]
        public IEnumerable<Category> GetCategories()
        {
            return Categories;
        }

        [HttpPost("/products")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            product.Id = Products.Count > 0 ? Products.Max(p => p.Id) + 1 : 1;
            Products.Add(product);
            return Ok(product);
        }

        [HttpPut("/products/{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.CategoryId = updatedProduct.CategoryId;

            return Ok(product);
        }

        [HttpDelete("/products/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            Products.Remove(product);
            return NoContent();
        }
    }
}