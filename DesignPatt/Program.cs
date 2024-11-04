

using DesignPatt.Handlers.CreateProduct;
using DesignPatt.Handlers.ListProducts;
using DesignPatt.Services;
using DesignPatt.Stores;

//Services
ProductRepository productRepository = new ProductRepository();
AuthenticationStore authenticationStore = new AuthenticationStore();

//Handlers
CreateProductHandler createProductHandler = new CreateProductHandler(productRepository, authenticationStore);
ListProductHandler listProductHandler = new ListProductHandler(productRepository, authenticationStore);

bool hasExited = false;

do
{
    Console.Write("Enter a command: ");
    string command = Console.ReadLine() ?? "";
    string[] arguments = command.Split(" ");

    string action = arguments[0];
    string[] remainingarguments = arguments.Skip(1).ToArray();

    switch (action.ToLower())
    {
        case "list":
            listProductHandler.Handle(remainingarguments);
            break;
        case "create":
            createProductHandler.Handle(remainingarguments);
            break;
        case "exit":
            hasExited = true;
            Console.WriteLine("Exiting application.");
            break;
        case "signin":
            authenticationStore.SignIn();
            Console.WriteLine("Successfully signed in.");
            break;
        default:
            Console.WriteLine("Invalid command");
            break;
    }
} while (!hasExited);