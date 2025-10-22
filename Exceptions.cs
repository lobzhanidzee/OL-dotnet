using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public class InvalidCodeException : Exception
    {
        public InvalidCodeException(string message) : base(message) { }
    }

    public class OutOfStockException : Exception
    {
        public OutOfStockException(string message) : base(message) { }
    }

    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public class InvalidDenominationException : Exception
    {
        public InvalidDenominationException(string message) : base(message) { }
    }

    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }

}
