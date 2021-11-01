
namespace parallel.Messages
{
    public class Start
    {

        public readonly string Password;
        public Start(string pwd)
        {
            Password = pwd;
        }
    }
}
