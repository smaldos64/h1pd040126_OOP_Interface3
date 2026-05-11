using Interface3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface3.Classes
{
    // Single Responsibility Principle (S i SOLID) overholdes,
    // da denne klasse kun har én funktionalitet: at behandle kortbetalinger.
    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Behandler kortbetaling på {amount} kr. via Nets... (klasse CreditCardProcessor)");
        }
    }
}
