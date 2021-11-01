using System;
using System.Diagnostics;
using System.Text;
using Akka.Actor;
using parallel.Actors;
using parallel.Messages;

namespace parallel
{
    class Program
    {
        static void Main(string[] args)
        {

            var availableCharsCount = Helpers.Chars.Length;
            var rand = new Random();

            StringBuilder sbPassword = new StringBuilder(Helpers.PwdLength);
            var maxIdx = availableCharsCount - 1;

            for (int i = 0; i < Helpers.PwdLength; i++)
            {
                var randIdx = rand.Next(0, maxIdx);
                sbPassword.Append(Helpers.Chars[randIdx]);
            }

            string pwd = sbPassword.ToString();
            Console.WriteLine($"Password is: {pwd}");


            Helpers.TheStopWatch = new Stopwatch();


            var system = ActorSystem.Create("hacker-system");

            var timerActor = system.ActorOf(TimerActor.Props(), "timer");
            var supervisor = system.ActorOf(HackerSupervisor.Props(timerActor).WithMailbox("hacker-mailbox"), "super");
            supervisor.Tell(new Start(pwd));

            while (true) { }
        }
    }
}
