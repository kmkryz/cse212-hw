/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Test 1
        // Scenario: Create CustomerService with valid size
        // Expected Result: CustomerService created with specified size
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService(5);
        Console.WriteLine($"Max size: {cs1}");
        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Create CustomerService with invalid size
        // Expected Result: CustomerService created with default size 10
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService(0);
        Console.WriteLine($"Max size: {cs2}");
        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Add customers until queue is full
        // Expected Result: 5 customers added successfully
        Console.WriteLine("Test 3");
        var cs3 = new CustomerService(5);
        for (int i = 0; i < 5; i++)
        {
            cs3.AddNewCustomer($"Customer{i + 1}", $"ACC{i + 1}", $"Problem{i + 1}");
        }
        Console.WriteLine($"Queue after adding 5 customers: {cs3}");
        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Try to add customer to full queue
        // Expected Result: Error message displayed
        Console.WriteLine("Test 4");
        cs3.AddNewCustomer("ExtraCustomer", "ACCX", "ExtraProblem");
        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serve customers from non-empty queue
        // Expected Result: First customer served and removed from queue
        Console.WriteLine("Test 5");
        Console.WriteLine($"Before serving: {cs3}");
        cs3.ServeCustomer();
        Console.WriteLine($"After serving: {cs3}");
        // Defect(s) Found: None

        Console.WriteLine("=================");

        // Test 6
        // Scenario: Try to serve customer from empty queue
        // Expected Result: Error message displayed
        Console.WriteLine("Test 6");
        var cs4 = new CustomerService(5);
        cs4.ServeCustomer();
        // Defect(s) Found: None
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer(string name, string accountId, string problem)
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Error: Maximum Number of Customers in Queue.");
            return;
        }

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("Error: No customers in the queue.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine($"Serving customer: {customer}");
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}