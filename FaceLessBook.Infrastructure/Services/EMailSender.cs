using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FaceLessBook.Domain.Contracts.Logger;
using FaceLessBook.Domain.Contracts.Services;

namespace FaceLessBook.Infrastructure.Services
{
    public class EMailSender : IEMailSender
    {
        private readonly ILogger _logger;

        public EMailSender(ILogger logger)
        {
            // when instantiating this class, Ninject will automatically resolve which implementation of ILogging 
            // to use and pass it in
            _logger = logger;
        }

        public void Send(string toAddress, string subject, string message)
        {
            _logger.Log("Sending email...");
            Debug.WriteLine("Sending Mail to: [{0}] with Subject: [{1}] {2}", 
                toAddress, subject, Environment.NewLine + message);
        }
    }
}
