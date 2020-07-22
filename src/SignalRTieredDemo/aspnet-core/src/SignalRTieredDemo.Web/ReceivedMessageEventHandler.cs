using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace SignalRTieredDemo.Web
{
    public class ReceivedMessageEventHandler : IDistributedEventHandler<ReceivedMessageEto>, ITransientDependency
    {
        readonly IHubContext<ChatHub> _hubContext;
        readonly ILogger<ReceivedMessageEventHandler> _logger;
        public ReceivedMessageEventHandler(IHubContext<ChatHub> hubContext, ILogger<ReceivedMessageEventHandler> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task HandleEventAsync(ReceivedMessageEto eto)
        {
            var message = $"{eto.SenderUserName}: {eto.ReceivedText}";

            await _hubContext.Clients
                .User(eto.TargetUserId.ToString())
                .SendAsync("ReceiveMessage", message);
        }
    }
}