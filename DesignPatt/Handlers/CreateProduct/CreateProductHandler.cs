using DesignPatt.Models;
using DesignPatt.Services;
using DesignPatt.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatt.Handlers.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly ProductRepository _productrepository;
        private readonly AuthenticationStore _authenticationstore;

        public CreateProductHandler(ProductRepository productrepository, AuthenticationStore authenticationstore)
        {
            _productrepository = productrepository;
            _authenticationstore = authenticationstore;
        }

        public void Handle(string[] args)
        {
            if (!_authenticationstore.IsSignedIn)
            {
                Console.WriteLine("You ust be signed in to create a product.");
                return;
            }
            if (args.Length < 2)
            {
                Console.WriteLine("Invalid parameters. Please provide a description and a price.");
                return;
            }

            string description = args[0];
            if (!decimal.TryParse(args[1], out decimal price))
            {
                Console.WriteLine($"Invalid price: {args[1]}");
                return;
            }

            Console.WriteLine("Creating product...");

            Product product = new Product(description, price);
            _productrepository.Create(product);

            Console.WriteLine($"Successfully created product '{product}'.");
        }
    }
}
