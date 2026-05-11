using Interface3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface3.Classes
{
    // Single Responsibility Principle (S i SOLID) overholdes ikke, 
    // da denne klasse har to funktionaliteter:
    // at behandle MobilePay-overførsler
    // og at sende kvitteringer via MobilePay.

    //public class MobilePayProcessor : IPaymentProcessor, INotifier
    public class MobilePayProcessor : IAdvancedPaymentProvider
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Behandler MobilePay-overførsel på {amount} kr... (klasse MobilePayProcessor)");
        }

        public void SendReceipt(string message)
        {
            Console.WriteLine($"Sender kvittering via MobilePay: {message}... (klasse MobilePayProcessor)");
        }
    }
}
