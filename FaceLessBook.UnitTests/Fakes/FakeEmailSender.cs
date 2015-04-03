using System;
using FaceLessBook.Domain.Contracts.Services;

namespace FaceLessBook.UnitTests.Fakes
{
    public class FakeEmailSender : IEMailSender
    {
        public void Send(string toAddress, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
