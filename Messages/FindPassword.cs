namespace parallel.Messages
{
    public class FindPassword
    {
        public readonly string Password, FirstLetter, SecondLetter;
        public readonly int PwdLength;
        public FindPassword(string pwd, string first, string second, int pwdLength = 4)
        {
            Password = pwd;
            FirstLetter = first;
            SecondLetter = second;
            PwdLength = pwdLength;
        }
    }
}