using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface3.Interfaces
{
    // Dette inerface arver både IPaymentProcessor og INotifier,
    // hvilket betyder at enhver klasse der implementerer
    // IAdvancedPaymentProvider skal implementere metoderne fra begge interfaces.
    public interface IAdvancedPaymentProvider : IPaymentProcessor, INotifier
    {
    }
}
