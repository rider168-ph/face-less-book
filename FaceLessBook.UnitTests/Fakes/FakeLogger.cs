using System;
using FaceLessBook.Domain.Contracts.Logger;

namespace FaceLessBook.UnitTests.Fakes
{
    public class FakeLogger : ILogger
    {
        public void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
