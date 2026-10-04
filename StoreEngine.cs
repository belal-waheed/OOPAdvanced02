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

        // Task 03.1: Print Reports
        // Delegate Used: Action<Product>
        // Why: Action<T> represents a method that takes a parameter (Product) and returns void.
        // It is ideal for side effects like printing, allowing the caller to define the format.
        internal static void PrintReport(List<Product> products, Action<Product> printAction)
        {
            foreach (var product in products)
            {
                printAction(product);
            }
        }

        // Task 03.2: Transform Products
        // Delegate Used: Func<Product, TResult>
        // Why: Func<T, TResult> takes a Product and returns a transformed value of type TResult.
        // This allows mapping products into strings, view models, or calculated numbers.
        internal static List<TResult> TransformProducts<TResult>(List<Product> products, Func<Product, TResult> transformer)
        {
            List<TResult> transformedList = new List<TResult>();

            foreach (var product in products)
            {
                transformedList.Add(transformer(product));
            }

            return transformedList;
        }

        // Task 03.3: Filter Products
        // Delegate Used: Predicate<Product>
        // Why: Predicate<T> is a specialized built-in delegate that takes one parameter of type T
        // and always returns a bool.
        internal static List<Product> FilterProducts(List<Product> products, Predicate<Product> condition)
        {
            List<Product> matches = new List<Product>();

            foreach (var product in products)
            {
                if (condition(product))
                {
                    matches.Add(product);
                }
            }

            return matches;
        }
    }
}
