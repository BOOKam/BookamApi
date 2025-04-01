using BookamApi.Interfaces;
using RestSharp;
using RestSharp.Authenticators;

public class EmailService : IEmailService
{
    private readonly string _apiKey;
    private readonly string _domain;
    private readonly string _fromEmail;
    private readonly string _senderName;

    public EmailService(IConfiguration configuration)
    {
        _apiKey = configuration["Mailgun:ApiKey"];
        _domain = configuration["Mailgun:Domain"];
        _fromEmail = configuration["Mailgun:FromEmail"];
        _senderName = configuration["Mailgun:SenderName"];
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false)
    {
        var client = new RestClient($"https://api.mailgun.net/v3/{_domain}/messages");
        client.Authenticator = new HttpBasicAuthenticator("api", _apiKey);
        
        var request = new RestRequest(Method.POST);
        request.AddParameter("from", $"{_senderName} <{_fromEmail}>");
        request.AddParameter("to", toEmail);
        request.AddParameter("subject", subject);
        
        if (isBodyHtml)
            request.AddParameter("html", body);
        else
            request.AddParameter("text", body);
            
        await client.ExecuteAsync(request);
    }
}




// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using System.Net; // Namespace for network credentials and related functionality.
// using System.Net.Mail;
// using BookamApi.Interfaces; // Namespace for email-related classes like SmtpClient and MailMessage.

// namespace BookamApi.Services
// {
//     public class EmailService : IEmailService
//     {

//         // Configuration property to access application settings.
//         private readonly IConfiguration _configuration;

//         // Constructor that injects the configuration dependency.
//         public EmailService(IConfiguration configuration)
//         {
//             // Save the configuration object for later use.
//             _configuration = configuration; 
//         }

//         // Method to send an email asynchronously.
//         public Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false)
//         {
//             // Retrieve the mail server (SMTP host) from the configuration.
//             string? MailServer = _configuration["EmailSettings:MailServer"];

//             // Retrieve the sender email address from the configuration.
//             string? FromEmail = _configuration["EmailSettings:FromEmail"];

//             // Retrieve the sender email password from the configuration.
//             string? Password = _configuration["EmailSettings:Password"];

//             // Retrieve the sender's display name from the configuration.
//             string? SenderName = _configuration["EmailSettings:SenderName"];

//             // Retrieve the SMTP port number from the configuration and convert it to an integer.
//             int Port = Convert.ToInt32(_configuration["EmailSettings:MailPort"]);

//             // Create a new instance of SmtpClient using the mail server and port number.
//             var client = new SmtpClient(MailServer, Port)
//             {
//                 // Set the credentials (email and password) for the SMTP server.
//                 Credentials = new NetworkCredential(FromEmail, Password),

//                 // Enable SSL for secure email communication.
//                 EnableSsl = true,
//             };

//             // Create a MailAddress object with the sender's email and display name.
//             MailAddress fromAddress = new MailAddress(FromEmail, SenderName);

//             // Create a new MailMessage object to define the email's properties.
//             MailMessage mailMessage = new MailMessage
//             {
//                 From = fromAddress, // Set the sender's email address with display name.
//                 Subject = Subject, // Set the email subject line.
//                 Body = Body, // Set the email body content.
//                 IsBodyHtml = IsBodyHtml // Specify whether the body content is in HTML format.
//             };

//             // Add the recipient's email address to the message.
//             mailMessage.To.Add(ToEmail);

//             // Send the email asynchronously using the SmtpClient instance.
//             return client.SendMailAsync(mailMessage);
//         }

    
//     }
// }