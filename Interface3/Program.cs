using Interface3.Classes;
using Interface3.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Interface4_Automatiseret_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. VI BYGGER CONTAINEREN (Konfiguration)
            var serviceProvider = new ServiceCollection()
                // Vi registrerer vores klasser præcis som i Web API
                .AddScoped<MobilePayProcessor>()
                .AddScoped<CreditCardProcessor>()
                .AddScoped<EMailService>()
                .AddScoped<IPaymentProcessor>(sp => sp.GetRequiredService<MobilePayProcessor>())
                .AddScoped<INotifier>(sp => sp.GetRequiredService<MobilePayProcessor>())
                
                .AddScoped<IPaymentProcessor, CreditCardProcessor>()
                .AddScoped<INotifier, EMailService>()
                .AddScoped<CheckoutManager>()
                .BuildServiceProvider(); // Her "låses" containeren

            // 2. VI HENTER STARTOBJEKTET
            // I en konsol-app skal vi manuelt bede om det første objekt (vores indgangsvinkel)
            var manager = serviceProvider.GetRequiredService<CheckoutManager>();

            // 3. BRUG AF KODEN
            manager.CompleteOrder(150.00m);

            Console.WriteLine("");
            Console.WriteLine("Dynamisk håndtering !!!");
            Console.WriteLine("");

            // SCENARIE 1: Alt-i-én (MobilePay)
            var services1 = new ServiceCollection();
            services1.AddScoped<IPaymentProcessor, MobilePayProcessor>();
            services1.AddScoped<INotifier, MobilePayProcessor>();
            services1.AddScoped<CheckoutManager>();
            var provider1 = services1.BuildServiceProvider();

            // SCENARIE 2: Kun betaling (SimpleCardReader)
            var services2 = new ServiceCollection();
            services2.AddScoped<IPaymentProcessor, CreditCardProcessor>();
            services2.AddScoped<INotifier, EMailService>();
            services2.AddScoped<CheckoutManager>();
            var provider2 = services2.BuildServiceProvider();

            // AFVIKLING
            Console.WriteLine("--- Scenarie 1: MobilePay ---");
            provider1.GetRequiredService<CheckoutManager>().CompleteOrder(100);

            Console.WriteLine("\n--- Scenarie 2: CreditCardProcessor og EMAilService ---");
            provider2.GetRequiredService<CheckoutManager>().CompleteOrder(100);

            Console.ReadKey();
        }
    }
}
