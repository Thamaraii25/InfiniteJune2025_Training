using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7CSharp
{
    /*
     Scenario: Mobile Phone – Ring Notification System
You are simulating a mobile phone that can ring when someone calls. Different parts of the phone (like ringtone player, screen display, and vibration motor) need to react to the ring event.

        To model this, use delegates and events.

        🎯 Task:
        Implement the following in C#:

        1. MobilePhone class
        Has a delegate RingEventHandler and an event OnRing.

        Has a method ReceiveCall() which triggers the OnRing event.

        2. Subscriber classes (handlers):
        RingtonePlayer – prints: "Playing ringtone..."

        ScreenDisplay – prints: "Displaying caller information..."

        VibrationMotor – prints: "Phone is vibrating..."

        3. In the Main() method:
        Create an instance of MobilePhone.

     */
    public delegate void RingEventHandler(string msg);

    internal class MobilePhone
    {

        public event RingEventHandler OnRing;

        public void ReceiveCall(string msg)
        {
            if (msg == "Call")
            {
                OnRing(msg);
            }
            else
            {
                Console.WriteLine("Call Not Received");
            }
        }
    }

    class Subcribers
    {
        public void RingtonePlayer(string msg)
        {
            Console.WriteLine($"Playing ringtone...");
        }

        public void ScreenDisplay(string msg)
        {
            Console.WriteLine($"Displaying caller information...");
        }

        public void VibrationMotor(string msg)
        {
            Console.WriteLine($"Phone is vibrating...");
        }
    }

    class EventAndDelegates
    {
        public static void Main()
        {
            MobilePhone mobilePhone = new MobilePhone();
            Subcribers subcribers = new Subcribers();

            mobilePhone.OnRing += new RingEventHandler(subcribers.RingtonePlayer);
            mobilePhone.OnRing += new RingEventHandler(subcribers.ScreenDisplay);
            mobilePhone.OnRing += new RingEventHandler(subcribers.VibrationMotor);

            mobilePhone.ReceiveCall("Call");

            Console.Read();



        }
    }


}
