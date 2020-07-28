using ELMessageFilteringService.Models;

namespace ELMessageFilteringService.Services
{
    public interface IMessageService
    {
        public Message TranslateMessage(MessageDTO message);

    }
}
