namespace VendingMachine
{
    internal class VendingMachine
    {
        private readonly Dictionary<SlotCode, Slot> slots;
        private decimal balance;
        private readonly int[] validDenominations = { 20, 50, 100, 500 };

        public VendingMachine()
        {
            slots = new Dictionary<SlotCode, Slot>();
            balance = 0;
            InitializeMachine();
        }

        private void InitializeMachine()
        {
            var cola = new Product("Pepsi", ProductCategory.Drinks, 250);
            var water = new Product("Water", ProductCategory.Drinks, 150);
            var chips = new Product("Chips", ProductCategory.Snacks, 200);
            var cookies = new Product("Biscuit", ProductCategory.Snacks, 180);
            var milka = new Product("Milka", ProductCategory.Snacks, 300);
            var snickers = new Product("Snickers", ProductCategory.Snacks, 280);

            slots.Add(SlotCode.A001, new Slot(SlotCode.A001, cola, 10));
            slots.Add(SlotCode.A002, new Slot(SlotCode.A002, water, 12));
            slots.Add(SlotCode.A003, new Slot(SlotCode.A003, chips, 8));
            slots.Add(SlotCode.B001, new Slot(SlotCode.B001, cookies, 10));
            slots.Add(SlotCode.B002, new Slot(SlotCode.B002, milka, 6));
            slots.Add(SlotCode.B003, new Slot(SlotCode.B003, snickers, 9));
        }

        public void Deposit(int amount)
        {
            if (!validDenominations.Contains(amount))
            {
                throw new InvalidDenominationException(
                    $"Invalid denomination! Please enter only: {string.Join(", ", validDenominations)} GEL");
            }

            balance += amount;
            Console.WriteLine($"You have successfully deposited {amount} GEL.");
            Console.WriteLine($"Your Balance: {balance} GEL");
        }

        public void Purchase(string code)
        {
            if (!Enum.TryParse(code, out SlotCode slotCode))
            {
                throw new InvalidCodeException($"Invalid code: {code}");
            }

            if (!slots.ContainsKey(slotCode))
            {
                throw new InvalidCodeException($"Invalid code: {code}");
            }

            Slot slot = slots[slotCode];

            if (slot.CurrentQuantity == 0)
            {
                throw new OutOfStockException($"The product {slot.Product.Name} ({slotCode}) is out of stock");
            }

            decimal discountedPrice = slot.GetDiscountedPrice();

            if (balance < discountedPrice)
            {
                throw new InsufficientBalanceException(
                    $"Insufficient balance! Need {discountedPrice:F2} GEL, you have {balance:F2} GEL.");
            }

            balance -= discountedPrice;
            slot.CurrentQuantity--;

            Console.WriteLine($"\nSuccessfully purchased: {slot.Product.Name}");
            Console.WriteLine($"Price (after discount): {discountedPrice:F2} GEL");
            Console.WriteLine($"Remaining balance: {balance:F2} GEL");
            Console.WriteLine($"Remaining quantity of product in the slot {slotCode}: {slot.CurrentQuantity}");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"\nYour current balance: {balance:F2} GEL.");
        }

        public void ShowProducts()
        {
            Console.WriteLine("\n=== Available products ===");
            foreach (var slot in slots.Values)
            {
                decimal discountedPrice = slot.GetDiscountedPrice();
                string stock = slot.CurrentQuantity > 0 ? $"{slot.CurrentQuantity} left" : "Sold out";
                Console.WriteLine($"{slot.Code} - {slot.Product.Name}\t| " +
                                $"Price: {discountedPrice:F2} GEL | " +
                                $"Stock: {stock}\t");
            }
            Console.WriteLine();
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }
}