using System;
using Akka.Actor;
using parallel.Messages;

namespace parallel.Actors
{
    public class HackerActor : ReceiveActor
    {
        private readonly IActorRef _timer;
        public HackerActor(IActorRef timer)
        {
            _timer = timer;
            Receive<FindPassword>(msg =>
            {
                //var prefix = $"{msg.FirstLetter}{msg.SecondLetter}";
                if (msg.PwdLength == 4)
                {
                    for (int a = 0; a < Helpers.Chars.Length; a++)
                    {
                        for (int b = 0; b < Helpers.Chars.Length; b++)
                        {
                            //var guess = $"{prefix}{Helpers.Chars[a]}{Helpers.Chars[b]}";
                            if (msg.FirstLetter[0] == msg.Password[0] && msg.SecondLetter[0] == msg.Password[1] && Helpers.Chars[a] == msg.Password[2] && Helpers.Chars[b] == msg.Password[3])
                            {
                                //_timer.Tell(new StopTimer());
                                Helpers.TheStopWatch.Stop();
                                Context.Parent.Tell(new End());
                                Console.WriteLine($"Found password: {msg.Password}");
                                Console.WriteLine($"Elapsed time was {Helpers.TheStopWatch.ElapsedMilliseconds} ms");
                                return;
                            }
                        }
                    }
                }
                else if (msg.PwdLength == 6)
                {
                    for (int a = 0; a < Helpers.Chars.Length; a++)
                    {
                        for (int b = 0; b < Helpers.Chars.Length; b++)
                        {
                            for (int c = 0; c < Helpers.Chars.Length; c++)
                            {
                                for (int d = 0; d < Helpers.Chars.Length; d++)
                                {
                                    //var guess = $"{prefix}{Helpers.Chars[a]}{Helpers.Chars[b]}{Helpers.Chars[c]}{Helpers.Chars[d]}";
                                    if (msg.FirstLetter[0] == msg.Password[0] && msg.SecondLetter[0] == msg.Password[1] && Helpers.Chars[a] == msg.Password[2] && Helpers.Chars[b] == msg.Password[3] && Helpers.Chars[c] == msg.Password[4] && Helpers.Chars[d] == msg.Password[5])
                                    {
                                        //_timer.Tell(new StopTimer());
                                        Helpers.TheStopWatch.Stop();
                                        Context.Parent.Tell(new End());
                                        Console.WriteLine($"Found password: {msg.Password}");
                                        Console.WriteLine($"Elapsed time was {Helpers.TheStopWatch.ElapsedMilliseconds} ms");
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (msg.PwdLength == 8)
                {
                    for (int a = 0; a < Helpers.Chars.Length; a++)
                    {
                        for (int b = 0; b < Helpers.Chars.Length; b++)
                        {
                            for (int c = 0; c < Helpers.Chars.Length; c++)
                            {
                                for (int d = 0; d < Helpers.Chars.Length; d++)
                                {
                                    for (int e = 0; e < Helpers.Chars.Length; e++)
                                    {
                                        for (int f = 0; f < Helpers.Chars.Length; f++)
                                        {
                                            //var guess = $"{prefix}{Helpers.Chars[a]}{Helpers.Chars[b]}{Helpers.Chars[c]}{Helpers.Chars[d]}{Helpers.Chars[e]}{Helpers.Chars[f]}";
                                            if (msg.FirstLetter[0] == msg.Password[0] && msg.SecondLetter[0] == msg.Password[1] && Helpers.Chars[a] == msg.Password[2] && Helpers.Chars[b] == msg.Password[3] && Helpers.Chars[c] == msg.Password[4] && Helpers.Chars[d] == msg.Password[5] && Helpers.Chars[e] == msg.Password[6] && Helpers.Chars[f] == msg.Password[7])
                                            {
                                                //_timer.Tell(new StopTimer());
                                                Helpers.TheStopWatch.Stop();
                                                Context.Parent.Tell(new End());
                                                Console.WriteLine($"Found password: {msg.Password}");
                                                Console.WriteLine($"Elapsed time was {Helpers.TheStopWatch.ElapsedMilliseconds} ms");
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            });
        }

        public static Props Props(IActorRef timer)
        {
            return Akka.Actor.Props.Create(() => new HackerActor(timer));
        }
    }
}