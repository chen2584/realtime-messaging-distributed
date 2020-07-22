using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace SignalRTieredDemo.Controllers
{
    [Route("api/app/chat")]
    public class ChatController : AbpController, IChatAppService
    {
        readonly IChatAppService _chatAppService;
        public ChatController(IChatAppService chatAppService)
        {
            _chatAppService = chatAppService;
        }

        [HttpPost("send-message")]
        public async Task SendMessageAsync(SendMessageInput input)
        {
            System.Console.WriteLine($"target {input.TargetUserName}: {input.Message}");
            await _chatAppService.SendMessageAsync(input);
        }
    }
}