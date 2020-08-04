using ELMessageFilteringService.DataAccess;
using ELMessageFilteringService.Models;
using ELMessageFilteringService.Models.Enums;
using ELMessageFilteringService.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ELMessageFilteringService.Services
{
    public class MessageService : IMessageService
    {
        private readonly IDataProvider _dataProvider;
        private readonly IStatisticsService _statisticsService;

        #region Constructor
        public MessageService(IDataProvider dataProvider, IStatisticsService statisticsService)
        {
            _dataProvider = dataProvider;
            _statisticsService = statisticsService;
        }
        #endregion

        public IList<RawMessage> GetRawMessages()
        {
            return _dataProvider.ImportMessages();
        }

        public IList<Message> GetExistingMessages()
        {
            var existingMessages = new List<Message>();
            IList<RawMessage> importedMessages = GetRawMessages();

            foreach (var msg in importedMessages)
            {
                existingMessages.Add(AddNewMessage(msg));
            }

            return existingMessages;
        }

        public Message AddNewMessage(RawMessage message)
        {
            if (message.IsValid())
            {
                // New Message and Message Type
                Message newMessage = GetMessageWithType(message);

                if (newMessage != null)
                {
                    // Id
                    newMessage.Id = message.Header;

                    // Sender and Content
                    var (sender, content) = ExtractSenderAndContent(message.Body);
                    newMessage.Sender = sender;
                    newMessage.Content = content;

                    // type-specific functions
                    switch (newMessage.Type)
                    {
                        case MessageType.Email:
                            Email email = (Email)newMessage;
                            email.SetSubjectContentAndSIRflag(); // remaining Email properties

                            var quarantinedUrls = email.SterilizeContentFromUrls();
                            _statisticsService.AddQuarantinedUrls(quarantinedUrls);

                            if (email.IsSIR)
                            {
                                SIR sir = (SIR)newMessage;
                                
                                sir.SetSportCentreCodeAndNatureOfIncident(); // remaining SIR properties
                                _statisticsService.AddSIRs(sir.IncidentDetails.SportCentreCode, sir.IncidentDetails.NatureOfIncident);
                            }
                            break;

                        case MessageType.Sms:
                            Sms sms = (Sms)newMessage;
                            sms.SanitizeContent(_dataProvider.ImportAbbreviations());
                            break;

                        case MessageType.Tweet:
                            Tweet tweet = (Tweet)newMessage;
                            tweet.SanitizeContent(_dataProvider.ImportAbbreviations());

                            tweet.CheckContentForHashtagsAndMentions();
                            if (tweet.Hashtags != null && tweet.Hashtags.Count > 0)
                            {
                                _statisticsService.AddHashtags(tweet.Hashtags);
                            }
                            if (tweet.Mentions != null && tweet.Mentions.Count > 0)
                            {
                                _statisticsService.AddMentions(tweet.Mentions);
                            }
                            break;
                    };

                    // export msg to a file
                    if (_dataProvider.ExportMessage(newMessage))
                    {
                        _statisticsService.UpdateStatistics();
                        // return fully-processed message to the ViewModel
                        return newMessage;
                    }
                }
            }
            return null;
        }

        #region Private Helper Methods
        private Message GetMessageWithType(RawMessage message)
        {
            switch (message.Header[0])
            {
                case 'S':
                    return new Sms() { Type = MessageType.Sms };
                case 'T':
                    return new Tweet() { Type = MessageType.Tweet };
                case 'E':
                    var (_, content) = ExtractSenderAndContent(message.Body);
                    Email email = new Email()
                    {
                        Content = content
                    };
                    email.SetSubjectContentAndSIRflag();
                    if (email.IsSIR)
                    {
                        return new SIR() { Type = MessageType.Email }; // SIR is a special case of an Email
                    }
                    else
                    {
                        return new Email() { Type = MessageType.Email };
                    }
                default:
                    return null;

            }

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
        #endregion
    }
}
