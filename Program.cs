namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|=== Vending Machine ===|");

            VendingMachine vm = new VendingMachine();
            bool running = true;

            while (running)
            {
                try
                {
                    Console.WriteLine("\n--- Menu ---");
                    Console.WriteLine("1. Deposite");
                    Console.WriteLine("2. Purchase product");
                    Console.WriteLine("3. Balance");
                    Console.WriteLine("4. Product list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nSelect an operation: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Deposit amount (20, 50, 100, 500): ");
                            if (int.TryParse(Console.ReadLine(), out int amount))
                            {
                                vm.Deposit(amount);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect format!");
                            }
                            break;

                        case "2":
                            vm.ShowProducts();
                            Console.Write("Enter product code: ");
                            string code = Console.ReadLine();
                            vm.Purchase(code);
                            break;

                        case "3":
                            vm.ShowBalance();
                            break;

                        case "4":
                            vm.ShowProducts();
                            break;

                        case "5":
                            if (vm.GetBalance() > 0)
                            {
                                Console.WriteLine($"\nBalance {vm.GetBalance():F2} GEL");
                            }
                            Console.WriteLine("Thanks you <3");
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Inncorect format!");
                            break;
                    }
                }
                catch (InvalidCodeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (OutOfStockException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidDenominationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }
    }
}
