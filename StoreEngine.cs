using System;
using System.Collections.Generic;
using System.Text;

namespace OOPAdvanced02
{
    internal static class StoreEngine
    {
        // Task 01: Smart Product Search
        // Delegate: Func<Product, bool>
        // Rationale: Accepts a Product as input and returns a boolean (true if match, false otherwise).
        
        internal static List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> matches = new List<Product>();
            foreach (var product in products)
            {
                if (filter(product))
                {
                    matches.Add(product);
                }
            }
            return matches;
        }
    }
}
