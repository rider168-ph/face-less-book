using System.Diagnostics;
using FaceLessBook.Domain.Contracts.Logger;

namespace FaceLessBook.Infrastructure.Logger
{
    public class DebugLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
