public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) => _products.Add(product);

    public double CalculateTotalCost()
    {
        double subtotal = _products.Sum(p => p.CalculateTotalCost());
        double shipping = _customer.IsInUSA() ? 5 : 35;
        return subtotal + shipping;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => $"{p.GetName()} (ID: {p.GetProductId()})"));
    }

    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}