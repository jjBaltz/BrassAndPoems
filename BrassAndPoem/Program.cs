
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
using System.Diagnostics;
using System.Xml.Linq;

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Tuba",
        Price = 475.00m,
        ProductTypeId = 1
    },
     new Product()
    {
        Name = "The Road Not Taken",
        Price = 15.50m,
        ProductTypeId = 2
    },
      new Product()
    {
        Name = "French Horn",
        Price = 675.00m,
        ProductTypeId = 1
    },
       new Product()
    {
        Name = "Trumpet",
        Price = 135.50m,
        ProductTypeId = 1
    },
        new Product()
    {
        Name = "The Two-Headed Calf",
        Price = 8.99m,
        ProductTypeId = 2
    }
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Title = "Instrument",
        Id = 1,
    },
    new ProductType()
    {
        Title = "Poetry",
        Id = 2,
    }
};

//put your greeting here
    Console.WriteLine(@"Welcome to Brass and Poems.
Would you be interested in instruments or perhaps a few lines of peotry?");

//implement your loop here
    int choice = 0;
    while (choice != 5)
    {
        DisplayMenu();

        string input = Console.ReadLine();

        if (int.TryParse(input, out choice))
        {
            switch (choice)
            {
                case 1:
                    DisplayAllProducts(products, productTypes);
                    break;
                case 2:
                    DeleteProduct(products, productTypes);
                    break;
                case 3:
                    AddProduct(products, productTypes);
                    break;
                case 4:
                    UpdateProduct(products, productTypes);
                    break;
                case 5:
                    Console.WriteLine("Thank you. Goodbye.");
                    break;
                default:
                    Console.WriteLine("Try selecting again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Try selecting again.");
        }
    }

void DisplayMenu()
{
    Console.WriteLine(@"What would you like to do:
                        1. Display All Products
                        2. Delete Product
                        3. Add Product
                        4. Update Product
                        5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(proType => proType.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name} is priced at ${product.Price} ");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.WriteLine("Wishing to delete a product?");

    string input = Console.ReadLine();
    if (int.TryParse(input, out int pIndex))
    {
        if (pIndex >= 1 && pIndex <= products.Count)
        {
        products.RemoveAt(pIndex - 1);
        Console.WriteLine("Product removed");
        }
        else
        {
        Console.WriteLine("Try selecting again.");
        }
    }
    else
    {
    Console.WriteLine("Try selecting again.");
    } 
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine(@"Add a new product.
                        What is the name of your product?");
    string newPName = Console.ReadLine();

    Console.WriteLine("What is the price of your product?");
    string tempPrice = Console.ReadLine();
    decimal.TryParse(tempPrice, out decimal newPrice);

    Console.WriteLine("Types of Products:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{productTypes[i].Id}. {productTypes[i].Title} ");
    }
    string newType = Console.ReadLine();
    Int32.TryParse(newType, out int newTypeId);

    Product newProduct = new()
    {
        Name = newPName,
        Price = newPrice,
        ProductTypeId = newTypeId
    };

    products.Add(newProduct);
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Console.WriteLine("Which product would you like to update?");
    string userInput = Console.ReadLine();
    Int32.TryParse(userInput, out int input);

    int lastInput = input - 1;
    var editProduct = products[lastInput];

    Console.WriteLine(@"Update product.
                        What is the new product name?");
    string editName = Console.ReadLine();

    Console.WriteLine("What is the new price of your product?");
    string tempPrice = Console.ReadLine();
    decimal.TryParse(tempPrice, out decimal editPrice);

    Console.WriteLine("Types of Products:");
    for (int i = 0; i < productTypes.Count; i++)
    {
        Console.WriteLine($"{productTypes[i].Id}. {productTypes[i].Title} ");
    }
    string newType = Console.ReadLine();
    Int32.TryParse(newType, out int editTypeId);

    editProduct.Name = editName;
    editProduct.Price = editPrice;
    editProduct.ProductTypeId = editTypeId;
}

// don't move or change this!
public partial class Program { }