using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Models;
using ELMessageFilteringService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ELMessageFilteringService.Services
{
    public class MessageService : IMessageService
    {
        private readonly IDataProvider _dataProvider;
        //private readonly IDictionary<string, string> abbreviations;

        public MessageService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public IDictionary<string, string> GetAbbreviations()
        {
            return (Dictionary<string, string>)_dataProvider.ImportAbbreviations();
        }

        public IList<Message> GetExistingMessages()
        {
            throw new NotImplementedException();
        }

        public Message AddNewMessage(MessageDTO message)
        {
            if (message.IsValid())
            {
                // detect message type and generate New Message accordingly
                Message newMessage = GetMessageWithType(message.Header[0]);
                if (newMessage != null)
                {
                    // Id
                    newMessage.Id = message.Header;

                    // extract Sender and Content from Body
                    var (sender, content) = ExtractSenderAndContent(message.Body);
                    newMessage.Sender = sender;
                    newMessage.Content = content;

                    // type-specific functions
                    switch (newMessage.Type)
                    {
                        case MessageType.Email:
                            //check if it's SIR
                            //handle SIR
                            //quarantine URLs
                            break;
                        case MessageType.Sms:
                            //sanitize
                            break;
                        case MessageType.Tweet:
                            //sanitize
                            //stats???
                            break;
                    };

                    // add it to the list of messages <- this should be done on the ViewModel, right?
                    // add statistics, if needed <- what about this one?

                    // export msg to a file //TODO
                    if (_dataProvider.ExportMessage(newMessage))
                    {
                        // return message for display
                        return newMessage;
                    }
                }
            }
            return null;
        }

        // private helpers
        private Message GetMessageWithType(char typeIndicator)
        {
            return typeIndicator switch
            {
                'E' => new Email() { Type = MessageType.Email },
                'S' => new Sms() { Type = MessageType.Sms },
                'T' => new Tweet() { Type = MessageType.Tweet },
                _ => null
            };
        }

        private (string sender, string content) ExtractSenderAndContent(string body)
        {
            var firstWordEndsAtIndex = body.IndexOf(" ");
            if (firstWordEndsAtIndex > 0)
            {
                var sender = body.Substring(0, firstWordEndsAtIndex);
                var content = body.Substring(firstWordEndsAtIndex + 1);
                return (sender, content);
            }
            return (body, "Message has no content!");
        }
    }
}
