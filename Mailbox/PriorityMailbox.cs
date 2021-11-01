using Akka.Actor;
using Akka.Configuration;
using Akka.Dispatch;
using parallel.Messages;

namespace parallel.Mailbox
{
    public class HackerMailbox : UnboundedPriorityMailbox
    {
        public HackerMailbox(Settings settings, Config config) : base(settings, config) { }
        protected override int PriorityGenerator(object message)
        {
            var msg = message as End;

            if (msg != null)
            {
                return 0;
            }

            return 100;
        }
    }
}