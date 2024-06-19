using System;

namespace DI
{

    // Interface representing the dependency
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    // Concrete implementation of the dependency
    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"Sending email: {message}");
        }
    }

    // Class that depends on the IMessageService
    public class NotificationService
    {
        private readonly IMessageService _messageService;

        // Constructor injection
        public NotificationService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void SendNotification(string message)
        {
            _messageService.SendMessage(message);
        }
    }

    // Usage example
    public class Program
    {
        public static void Main()
        {
            // Create an instance of the dependency
            IMessageService emailService = new EmailService();

            // Create an instance of the class with the dependency injected
            NotificationService notificationService = new NotificationService(emailService);

            // Use the class
            notificationService.SendNotification("Hello, world!");
        }
    }
}