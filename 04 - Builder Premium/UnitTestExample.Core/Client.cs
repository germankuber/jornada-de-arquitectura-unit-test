using System;

namespace UnitTestExample.Core
{
    public class Client
    {
        public DateTime Birthday { get; set; }

        public Client(DateTime birthday)
        {
            Birthday = birthday;
        }

        public bool IsValid() =>
            DateTime.Now.Year - Birthday.Year > 18;
    }
}
