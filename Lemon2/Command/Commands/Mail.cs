using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using Org.BouncyCastle.Utilities;

namespace Lemon2.Command.Commands {
    
    public class Mail : CommandBase {

        private SmtpClient smtp = new SmtpClient() {Port = 587};
        private ImapClient imap = new ImapClient();
        
        private string email;

        public Mail() : base("mail", "A mail client for lemon", "mail <server/login/send>") {}

        public override void onCommand(string[] args) {

            smtp.EnableSsl = true;

            if (args[1] == "server") {
                imap.Connect(args[2], 993, SecureSocketOptions.SslOnConnect);
                smtp.Host = args[3];

            } else if (args[1] == "login") {
                smtp.Credentials = new NetworkCredential(args[2], args[3]);
                imap.Authenticate(args[2], args[3]);
                
                email = args[2];

            } else if (args[1] == "send") {
                // Mail message object
                MailMessage message = new MailMessage();
                message.Sender = new MailAddress(email);
                message.From = new MailAddress(email);

                // Read subject
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter reciver: ");
                Console.ResetColor();
                
                message.To.Add(Console.ReadLine());

                // Read subject
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter mail subject: ");
                Console.ResetColor();

                message.Subject = Console.ReadLine();
                
                // Read body
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter mail body: ");
                Console.ResetColor();

                message.Body = Utils.MultiLineInput();

                smtp.Send(message);

            } else if (args[1] == "list") {
                imap.Inbox.Open(FolderAccess.ReadOnly);
                IList<UniqueId> uids = imap.Inbox.Search(SearchQuery.All);

                foreach (UniqueId id in uids) {
                    
                    Console.WriteLine(id.Id.ToString() + ": " + imap.Inbox.GetMessage(id).Subject);
                    
                }

            } else if (args[1] == "read") {
                var message = imap.Inbox.GetMessage(UniqueId.Parse(args[2]));
                
                Utils.ValueWrite(ConsoleColor.Cyan, "Subject: ", message.Subject);
                Utils.ValueWrite(ConsoleColor.Cyan, "From: ", message.From.ToString());
                
                Console.WriteLine();
                
                Console.WriteLine(message.Body.ToString().Replace("X-MimeKit-Warning: Do NOT use ToString() to serialize entities! Use one of the WriteTo() methods instead!", ""));

            }
            
        }
    }
}