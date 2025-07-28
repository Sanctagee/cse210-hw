// Create addresses
var usaAddress = new Address("123 Main St", "Rexburg", "ID", "USA");
var canadaAddress = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
var nigeriaAddress = new Address("21 Afikpo Road", "Abakaliki", "Ebonyi State", "Nigeria");
var ukAddress = new Address("1 London Bridge", "London", "England", "UK");

// Create customers
var customer1 = new Customer("Jennifer Williams", usaAddress);
var customer2 = new Customer("StrongCode", canadaAddress);
var customer3 = new Customer("GabbyTech", nigeriaAddress);
var customer4 = new Customer("Amanda Potens", ukAddress);

// Create products
var laptop = new Product("Laptop", "P100", 999.99, 1);
var mouse = new Product("Wireless Mouse", "P200", 19.99, 2);
var earbuds = new Product("Wireless Earbuds", "P300", 59.99, 2);
var notebook = new Product("Programming Notebook", "P400", 12.50, 1);
var usbCable = new Product("USB-C Cable", "P500", 15.99, 3);
var iphone = new Product("i_phone 15 Pro-max", "P700", 1205.99, 3);
var microWave = new Product("Microwave", "P600", 1540.99, 1);
var officeChair = new Product("Swivel Seat", "P800", 650.99, 2);

// Create and display orders
var order1 = new Order(customer1);
order1.AddProduct(laptop);
order1.AddProduct(mouse);
DisplayOrder("Order 1 (USA)", order1);

var order2 = new Order(customer3); // My order
order2.AddProduct(earbuds);
order2.AddProduct(notebook);
DisplayOrder("Order 2 (Nigeria - My Order)", order2);

var order3 = new Order(customer4); // UK order
order3.AddProduct(laptop);
order3.AddProduct(usbCable);
DisplayOrder("Order 3 (UK - International)", order3);

var order4 = new Order(customer2); // Canada order
order4.AddProduct(notebook);
order4.AddProduct(earbuds);
order4.AddProduct(mouse);
DisplayOrder("Order 4 (Canada - International)", order4);

var order5 = new Order(customer3); // Nigeria order
order5.AddProduct(notebook);
order5.AddProduct(iphone);
order5.AddProduct(microWave);
DisplayOrder("Order 5 (Nigeria - My Order)", order5);

var order6 = new Order(customer1); // USA order
order6.AddProduct(notebook);
order6.AddProduct(earbuds);
order6.AddProduct(mouse);
DisplayOrder("Order 6 (USA - International)", order6);

var order7 = new Order(customer4); // UK order
order7.AddProduct(earbuds);
order7.AddProduct(notebook);
order7.AddProduct(officeChair);
DisplayOrder("Order 7 (UK - International)", order7);

// Helper method to display orders
void DisplayOrder(string title, Order order)
{
    Console.WriteLine($"\n=== {title} ===");
    Console.WriteLine("Packing Label:");
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine("\nShipping Label:");
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine($"\nTotal Cost: ${order.CalculateTotalCost():0.00}");
    Console.WriteLine("-----------------------------");
}