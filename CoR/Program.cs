using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoR
{
    class Program
    {
        public static void Requst(PaymentHandler h, Receiver receiver)
        {
            h.Handle(receiver);
        }
        static void Main(string[] args)
        {
            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();

            bankPaymentHandler.Next = paypalPaymentHandler;
            paypalPaymentHandler.Next = moneyPaymentHandler;

            Receiver receiver_1 = new Receiver(true, false,false);
            Receiver receiver_2 = new Receiver(false, true, false);
            Receiver receiver_3 = new Receiver(false, false, true);

            Requst(bankPaymentHandler, receiver_1);
            Requst(bankPaymentHandler, receiver_2);
            Requst(bankPaymentHandler, receiver_3);
        }
    }
}
