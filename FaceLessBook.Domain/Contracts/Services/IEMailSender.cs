namespace FaceLessBook.Domain.Contracts.Services
{
    public interface IEMailSender
    {
        void Send(string toAddress, string subject, string message);
    }
}
