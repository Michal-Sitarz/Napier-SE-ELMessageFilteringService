using ELMessageFilteringService.Models;
using ELMessageFilteringService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ELMessageFilteringService.Services
{
    public class MessageService : IMessageService
    {
        public Message AddNewMessage(MessageDTO message)
        {
            if (message.IsValid())
            {
                // detect message type and generate New Message accordingly
                Message newMessage = GetMessageWithType(message.Header[0]);
                if (newMessage != null)
                {
                    newMessage.Id = message.Header.ToCharArray();

                    // populate all fields
                    //switch (newMessage.Type)
                    //{
                    //    case MessageType.Sms:

                    //}

                    // add it to the list of messages

                    // export msg to a file


                    // add statistics, if needed

                    // return message for display
                    return newMessage;
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
                _ => null,
            };
        }



        private bool ExportMessage(Message message)
        {
            return true;
        }

        public IList<Message> ImportMessages()
        {
            throw new NotImplementedException();
        }

    }
}
