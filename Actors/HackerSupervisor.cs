
using System;
using System.Diagnostics;
using System.Linq;
using Akka.Actor;
using parallel.Messages;

namespace parallel.Actors
{
    public class HackerSupervisor : ReceiveActor
    {
        private readonly IActorRef _timer;
        public HackerSupervisor(IActorRef timer)
        {
            _timer = timer;
            Receive<Start>(msg =>
            {
                //timer.Tell(new StartTimer());
                Helpers.TheStopWatch.Reset();
                Helpers.TheStopWatch.Start();
                for (int a = 0; a < Helpers.Chars.Length; a++)
                {
                    for (int b = 0; b < Helpers.Chars.Length; b++)
                    {
                        var actor = Context.ActorOf(HackerActor.Props(_timer).WithMailbox("hacker-mailbox"), $"{Helpers.Chars[a]}{Helpers.Chars[b]}");
                        actor.Tell(new FindPassword(msg.Password, $"{Helpers.Chars[a]}", $"{Helpers.Chars[b]}", Helpers.PwdLength));
                    }
                }
            });

            Receive<End>(msg =>
            {
                Console.WriteLine("Stopping all child actors......");
                var kids = Context.GetChildren();
                foreach (var kid in kids)
                {
                    Context.Stop(kid);
                }
                Console.WriteLine("done");
            });
        }

        public static Props Props(IActorRef timer)
        {
            return Akka.Actor.Props.Create(() => new HackerSupervisor(timer));
        }
    }
}