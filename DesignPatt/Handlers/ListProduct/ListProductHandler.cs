using DesignPatt.Models;
using DesignPatt.Services;
using DesignPatt.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatt.Handlers.ListProducts
{
    public class ListProductHandler
    {
        private readonly ProductRepository _productrepository;
        private readonly AuthenticationStore _authenticationstore;

        public ListProductHandler(ProductRepository productrepository, AuthenticationStore authenticationstore)
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

            Console.WriteLine("Getting product...");

            IEnumerable<Product> products = _productrepository.GetAll();

            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }

            Console.WriteLine($"Total product: {products.Count()}");
        }
    }
}
