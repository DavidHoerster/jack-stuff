using System;
using System.Diagnostics;
using Akka.Actor;
using parallel.Messages;

namespace parallel.Actors
{
    public class TimerActor : ReceiveActor
    {

        public TimerActor()
        {
            var sw = new Stopwatch();
            Receive<StartTimer>(msg =>
            {
                sw.Start();
            });

            Receive<StopTimer>(msg =>
            {
                sw.Stop();
                Console.WriteLine($"Elapsed time was {sw.ElapsedMilliseconds} ms");
            });
        }

        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new TimerActor());
        }

    }
}