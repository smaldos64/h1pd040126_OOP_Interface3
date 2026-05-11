using Interface3.Classes;
using Interface3.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Interface4_Automatiseret_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreditCardProcessor creditCardProcessor_Object = new CreditCardProcessor();
            //MobilePayProcessor mobilePayProcessor_Object = new MobilePayProcessor();
            //EMailService eMailService_Object = new EMailService();

            //CheckoutManager checkoutManager_Object = new CheckoutManager(creditCardProcessor_Object);
            //CheckoutManager checkoutManager_Object1 = new CheckoutManager(mobilePayProcessor_Object);
                        
            // 1. VI BYGGER CONTAINEREN (Konfiguration)
            var serviceProvider = new ServiceCollection()
                // Vi registrerer vores klasser præcis som i Web API
                //.AddScoped<MobilePayProcessor>()
                //.AddScoped<IPaymentProcessor>(sp => sp.GetRequiredService<MobilePayProcessor>())
                //.AddScoped<INotifier>(sp => sp.GetRequiredService<MobilePayProcessor>())
                //.AddScoped<CheckoutManager>()
                //.BuildServiceProvider(); // Her "låses" containeren

                //.AddScoped<MobilePayProcessor>()
                //.AddScoped<IPaymentProcessor>(sp => sp.GetRequiredService<MobilePayProcessor>())
                //.AddScoped<EMailService>()
                //.AddScoped<INotifier>(sp => sp.GetRequiredService<EMailService>())
                //.AddScoped<CheckoutManager>()
                //.BuildServiceProvider(); // Her "låses" containeren

                .AddScoped<CreditCardProcessor>()
                .AddScoped<IPaymentProcessor>(sp => sp.GetRequiredService<CreditCardProcessor>())
                .AddScoped<EMailService>()
                .AddScoped<INotifier>(sp => sp.GetRequiredService<EMailService>())
                .AddScoped<CheckoutManager>()
                .BuildServiceProvider(); // Her "låses" containeren

            // 2. VI HENTER STARTOBJEKTET
            // I en konsol-app skal vi manuelt bede om det første objekt (vores indgangsvinkel)
            CheckoutManager manager_Object = serviceProvider.GetRequiredService<CheckoutManager>();

            // 3. BRUG AF KODEN
            manager_Object.CompleteOrder(150.00m);
            Console.WriteLine("");

            manager_Object.CompleteOrder(250.00m);
            Console.WriteLine("");

            CheckoutManager manager_Object1 = serviceProvider.GetRequiredService<CheckoutManager>();
            manager_Object1.CompleteOrder(2000.00m);

            Console.ReadKey();
        }
    }
}
