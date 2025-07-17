using ZondaAPI.Models;

namespace ZondaAPI.Services
{
    public interface IDataService
    {
        List<ZondaCustomer> GetAllCustomers();
        ZondaCustomer? GetCustomerById(int id);
        ZondaCustomer AddCustomer(ZondaCustomer customer);
        ZondaCustomer? UpdateCustomer(ZondaCustomer customer);
        bool DeleteCustomer(int id);
        
        List<ZondaProduct> GetAllProducts();
        List<ZondaProduct> GetProductsByCustomerId(int customerId);
        ZondaProduct? GetProductById(int id);
        ZondaProduct AddProduct(ZondaProduct product);
        ZondaProduct? UpdateProduct(ZondaProduct product);
        bool DeleteProduct(int id);
    }

    public class DataService : IDataService
    {
        private List<ZondaCustomer>? _customers;
        private List<ZondaProduct>? _products;
        private int _nextCustomerId = 4;
        private int _nextProductId = 38;
        public DataService()
        {
            InitializeMockData();
        }

        private void InitializeMockData()
        {
            // Initialize customers
            _customers = new List<ZondaCustomer>
            {
                new ZondaCustomer { Id = 1, Name = "Mary Adams", Email = "madams@gmail.com", Phone = "123-456-7890" },
                new ZondaCustomer { Id = 2, Name = "Rob Smith", Email = "rsmith@email.com", Phone = "234-567-8901" },
                new ZondaCustomer { Id = 3, Name = "Henry Chau", Email = "superheny@hotmail.com", Phone = "345-678-912" }
            };

            // Initialize products
            _products = new List<ZondaProduct>
            {
                // Customer 1 - Mary Adams (existing products)
                new ZondaProduct { Id = 1, CustomerId = 1, Name = "CPU", Price = 500 },
                new ZondaProduct { Id = 2, CustomerId = 1, Name = "Monitor", Price = 130 },
                new ZondaProduct { Id = 3, CustomerId = 1, Name = "RAM", Price = 200 },
                new ZondaProduct { Id = 4, CustomerId = 1, Name = "Keyboard", Price = 50 },
                new ZondaProduct { Id = 5, CustomerId = 1, Name = "Mouse", Price = 30 },
                
                // Customer 1 - Additional products
                new ZondaProduct { Id = 9, CustomerId = 1, Name = "Graphics Card", Price = 450 },
                new ZondaProduct { Id = 10, CustomerId = 1, Name = "SSD1", Price = 120 },
                new ZondaProduct { Id = 11, CustomerId = 1, Name = "Motherboard", Price = 180 },
                new ZondaProduct { Id = 12, CustomerId = 1, Name = "Power Supply", Price = 85 },
                new ZondaProduct { Id = 13, CustomerId = 1, Name = "CPU Cooler", Price = 65 },
                new ZondaProduct { Id = 14, CustomerId = 1, Name = "Case Fan", Price = 25 },
                new ZondaProduct { Id = 15, CustomerId = 1, Name = "Network Card", Price = 40 },
                new ZondaProduct { Id = 16, CustomerId = 1, Name = "Sound Card", Price = 75 },
                new ZondaProduct { Id = 17, CustomerId = 1, Name = "Webcam", Price = 35 },
                new ZondaProduct { Id = 18, CustomerId = 1, Name = "Microphone", Price = 45 },
                
                // Customer 2 - Rob Smith (existing products)
                new ZondaProduct { Id = 6, CustomerId = 2, Name = "Laptop", Price = 900 },
                new ZondaProduct { Id = 7, CustomerId = 2, Name = "Tablet", Price = 300 },
                
                // Customer 2 - Additional products
                new ZondaProduct { Id = 19, CustomerId = 2, Name = "External Hard Drive", Price = 95 },
                new ZondaProduct { Id = 20, CustomerId = 2, Name = "USB Hub", Price = 20 },
                new ZondaProduct { Id = 21, CustomerId = 2, Name = "Wireless Mouse", Price = 35 },
                new ZondaProduct { Id = 22, CustomerId = 2, Name = "Bluetooth Keyboard", Price = 60 },
                new ZondaProduct { Id = 23, CustomerId = 2, Name = "Laptop Stand", Price = 45 },
                new ZondaProduct { Id = 24, CustomerId = 2, Name = "Laptop Cooling Pad", Price = 30 },
                new ZondaProduct { Id = 25, CustomerId = 2, Name = "USB-C Cable", Price = 15 },
                new ZondaProduct { Id = 26, CustomerId = 2, Name = "HDMI Cable", Price = 12 },
                new ZondaProduct { Id = 27, CustomerId = 2, Name = "Laptop Sleeve", Price = 25 },
                new ZondaProduct { Id = 28, CustomerId = 2, Name = "Wireless Headphones", Price = 80 },
                
                // Customer 3 - Henry Chau (existing products)
                new ZondaProduct { Id = 8, CustomerId = 3, Name = "Printer", Price = 150 },
                
                // Customer 3 - Additional products
                new ZondaProduct { Id = 29, CustomerId = 3, Name = "Scanner", Price = 120 },
                new ZondaProduct { Id = 30, CustomerId = 3, Name = "Document Camera", Price = 85 },
                new ZondaProduct { Id = 31, CustomerId = 3, Name = "Label Printer", Price = 65 },
                new ZondaProduct { Id = 32, CustomerId = 3, Name = "3 Printer", Price = 350 },
                new ZondaProduct { Id = 33, CustomerId = 3, Name = "Printer Ink Cartridges", Price = 45 },
                new ZondaProduct { Id = 34, CustomerId = 3, Name = "Paper Tray", Price = 30 },
                new ZondaProduct { Id = 35, CustomerId = 3, Name = "Wireless Print Server", Price = 55 },
                new ZondaProduct { Id = 36, CustomerId = 3, Name = "Printer Stand", Price = 40 },
                new ZondaProduct { Id = 37, CustomerId = 3, Name = "Photo Paper", Price = 25 }
            };
        }

        // Customer operations
        public List<ZondaCustomer> GetAllCustomers()
        {
            return _customers ?? new List<ZondaCustomer>();
        }

        public ZondaCustomer? GetCustomerById(int id)
        {
            return _customers?.FirstOrDefault(c => c.Id == id);
        }

        public ZondaCustomer AddCustomer(ZondaCustomer customer)
        {
            customer.Id = _nextCustomerId++;
            _customers?.Add(customer);
            return customer;
        }

        public ZondaCustomer? UpdateCustomer(ZondaCustomer customer)
        {
            var existingCustomer = _customers?.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                existingCustomer.Phone = customer.Phone;
                return existingCustomer;
            }
            return null;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = _customers?.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                _customers?.Remove(customer);
                // Also delete all products associated with this customer
                _products?.RemoveAll(p => p.CustomerId == id);
                return true;
            }
            return false;
        }

        // Product operations
        public List<ZondaProduct> GetAllProducts()
        {
            return _products ?? new List<ZondaProduct>();
        }

        public List<ZondaProduct> GetProductsByCustomerId(int customerId)
        {
            return _products?.Where(p => p.CustomerId == customerId).ToList() ?? new List<ZondaProduct>();
        }

        public ZondaProduct? GetProductById(int id)
        {
            return _products?.FirstOrDefault(p => p.Id == id);
        }

        public ZondaProduct AddProduct(ZondaProduct product)
        {
            product.Id = _nextProductId++;
            _products?.Add(product);
            return product;
        }

        public ZondaProduct? UpdateProduct(ZondaProduct product)
        {
            var existingProduct = _products?.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct != null)
            {
                existingProduct.CustomerId = product.CustomerId;
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                return existingProduct;
            }
            return null;
        }

        public bool DeleteProduct(int id)
        {
            var product = _products?.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products?.Remove(product);
                return true;
            }
            return false;
        }
    }
} 