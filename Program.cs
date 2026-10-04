namespace OOPAdvanced02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Product Catalog
            List<Product> catalog = new()
            {
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1200, Stock = 10 },
                new Product { Id = 2, Name = "Phone", Category = "Electronics", Price = 800, Stock = 25 },
                new Product { Id = 3, Name = "T-Shirt", Category = "Clothing", Price = 30, Stock = 100 },
                new Product { Id = 4, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 50 },
                new Product { Id = 5, Name = "Chocolate", Category = "Food", Price = 5, Stock = 200 },
                new Product { Id = 6, Name = "Coffee Beans", Category = "Food", Price = 15, Stock = 80 },
                new Product { Id = 7, Name = "C# Book", Category = "Books", Price = 45, Stock = 30 },
                new Product { Id = 8, Name = "Novel", Category = "Books", Price = 20, Stock = 60 },
                new Product { Id = 9, Name = "Headphones", Category = "Electronics", Price = 150, Stock = 40 },
                new Product { Id = 10, Name = "Jacket", Category = "Clothing", Price = 90, Stock = 15 }
            };
            #endregion

            #region Task 01
            // Delegate Used: Func<Product, bool>
            // Why: Takes a Product parameter and returns a bool indicating if the condition is met.
            // Allows the caller to define dynamic filtering logic via lambdas without modifying the engine.

            // 1. All Electronics products
            Console.WriteLine("--- Electronics ---");
            List<Product> electronics = StoreEngine.SearchProducts(catalog, p => p.Category == "Electronics");
            foreach (var p in electronics)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            // 2. Products cheaper than $50
            Console.WriteLine("\n--- Under $50 ---");
            List<Product> under50 = StoreEngine.SearchProducts(catalog, p => p.Price < 50);
            foreach (var p in under50)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            // 3. Products that are in stock (Stock > 0)
            Console.WriteLine("\n--- In Stock ---");
            List<Product> inStock = StoreEngine.SearchProducts(catalog, p => p.Stock > 0);
            foreach (var p in inStock)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }

            // 4. Clothing products under $100
            Console.WriteLine("\n--- Clothing Under $100 ---");
            List<Product> cheapClothing = StoreEngine.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            foreach (var p in cheapClothing)
            {
                Console.WriteLine($"{p.Name} - ${p.Price} (Stock: {p.Stock})");
            }
            #endregion

            #region Task 03.1: Print Reports
            // Delegate Used: Action<Product>
            // Why: Action<Product> accepts a Product and returns void.
            // It allows the caller to decide the formatting and printing side-effects without modifying the engine.

            // Scenario 1: Short Report (Name - $price)
            Console.WriteLine("\n\n\n\n\n\n--- Short Report ---");
            StoreEngine.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            // Scenario 2: Detailed Report ([Category] Name | Price: $price | Stock: stock)
            Console.WriteLine("\n--- Detailed Report ---");
            StoreEngine.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            #endregion

            #region Task 03.2: Transform Products
            // Delegate Used: Func<Product, TResult>
            // Why: Takes an input Product and returns a new transformed value (TResult, here string).
            // It allows converting data into different formats/projections cleanly.

            // Scenario 3: Summary List (e.g. "Laptop ($1200)")
            Console.WriteLine("\n\n\n\n\n--- Summary List ---");
            List<string> summaryList = StoreEngine.TransformProducts(catalog, p => $"{p.Name} (${p.Price})");
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }

            // Scenario 4: Price Labels ("Expensive!" if Price > 100, else "Affordable")
            Console.WriteLine("\n--- Price Labels ---");
            List<string> priceLabels = StoreEngine.TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (var label in priceLabels)
            {
                Console.WriteLine(label);
            }
            #endregion

        }
    }
}