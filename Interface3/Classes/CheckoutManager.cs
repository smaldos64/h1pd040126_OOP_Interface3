using Interface3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface3.Classes
{
    public class CheckoutManager
    {
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly INotifier? _notifier;

        // Den første og fleksible Constructor tager to parametre, som begge er interfaces.
        // Det betyder, at vi kan sende enhver klasse, der implementerer disse interfaces,
        // når vi opretter en instans af CheckoutManager.
        // Hermed overholder vi alle principperne i SOLID.

        // 1) Vi overholder Single Responsibility Principle (S i SOLID), da CheckoutManager
        // kun har én funktionalitet: at håndtere checkout-processen.

        // 2) Vi "injecter" interfacene her (Constructor Dependency Injection).
        // Og da injecter Interfaces vil vi altid overholde Open/Closed Principle (O i SOLID),
        // da vi alid kan tilføje nye implementeringer af IPaymentProcessor og INotifier.

        // 3) Vi overholder også Liskov Substitution Principle (L i SOLID),
        // da vi kan erstatte IPaymentProcessor med IAdvancedPaymentProvider
        // uden at ændre på CheckoutManager's funktionalitet.
        // Herudover kan vi i begge tilfælde erstatte IPaymentProcessor og
        // INotifier med andre klasser, der implementerer dette/disse interfaces.

        // 4) Ligeledes overholder vi Interface Segregation Principle (I i SOLID),
        // da vi har opdelt/kan opdele funktionaliteten i flere interfaces.

        // 5) Endelig overholder vi Dependency Inversion Principle (D i SOLID),
        // da Constructoren her afhænger af abstraktioner (interfaces)
        // og ikke konkrete implementeringer.
        public CheckoutManager(IPaymentProcessor paymentProcessor,
                               INotifier? notifier = null)
        {
            this._paymentProcessor = paymentProcessor;
            this._notifier = notifier;
        }

        // Den anden Constructor er en "overload" af den første, og den gør det muligt at sende en klasse,
        // der implementerer IAdvancedPaymentProvider. 
        // Da IAdvancedPaymentProvider både implementerer IPaymentProcessor og INotifier,
        // kan vi bruge den samme instans til begge parametre i den første Constructor.
        // Når vi gør dette, giver vi imidlertid køb på nogle af principperne i SOLID.

        // 1) Vi overholder ikke Single Responsibility Principle (S i SOLID),
        // da klasser der implementerer Interfacet IAdvancedPaymentProvider,
        // skal implementere 2 funktionaliteter: betaling og notifikation i samme klasse.

        // 2) Vi "injecter" interfacet her (Constructor Dependency Injection).
        // Og da injecter Interfaces vil vi altid overholde Open/Closed Principle (O i SOLID),
        // da vi alid kan tilføje nye implementeringer af IAdvancedPaymentProvider.

        // 3) Vi overholder også Liskov Substitution Principle (L i SOLID),
        // da vi kan erstatte IAdvancedPaymentProvider med
        // med en anden klasse, der implementerer både IPaymentProcessor og INotifier,
        // uden at ændre på CheckoutManager's funktionalitet.

        // 4) Vi overholder IKKE Interface Segregation Principle (I i SOLID),
        // da vi har et interface der ikke er lille => der tvinger klasserne,
        // som implementerer dette Interface til at håndtere flere
        // funktionaliteter.

        // 5) Vi overholder Dependency Inversion Principle (D i SOLID),
        // da Constructoren her afhænger af abstraktioner (interfaces)
        // og ikke konkrete implementeringer.
        public CheckoutManager(IAdvancedPaymentProvider advancedPaymentProvider) :
            this(advancedPaymentProvider, advancedPaymentProvider)
        {
            
        }

        public void CompleteOrder(decimal total)
        {
            this._paymentProcessor.ProcessPayment(total);
            this._notifier?.SendReceipt($"Betaling på {total} kr. er gennemført.");
        }
    }
}
