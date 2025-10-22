namespace VendingMachine
{
    internal class Slot
    {
        public SlotCode Code { get; set; }
        public Product Product { get; set; }

        private int _currentQuantity;
        private int _maxQuantity;

        public int CurrentQuantity
        {
            get => _currentQuantity;
            set
            {
                if (value > MaxQuantity)
                    throw new InvalidQuantityException("Current quantity cannot exceed maximum quantity.");
                _currentQuantity = value;
            }
        }

        public int MaxQuantity
        {
            get => _maxQuantity;
            set
            {
                if (value < CurrentQuantity)
                    throw new InvalidQuantityException("Maximum quantity cannot be less than current quantity.");
                _maxQuantity = value;
            }
        }

        public Slot(SlotCode code, Product product, int maxQuantity)
        {
            Code = code;
            Product = product;
            _maxQuantity = maxQuantity;
            _currentQuantity = maxQuantity;
        }

        public decimal GetDiscountedPrice()
        {
            return Product.Price * (1 - Product.Discount / 100);
        }
    }
}