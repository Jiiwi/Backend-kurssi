using System;

namespace web_api
{
    public class LowLevelPlayerException : Exception
    {
        public LowLevelPlayerException(string message) : base(message)
        {
        }
    }
}