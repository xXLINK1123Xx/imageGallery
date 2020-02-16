using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure.Services;
using VkNet;

namespace Data.Services
{
    public class VkService: IRepostService
    {
        private readonly VkApi _vkApiWrapper;

        public VkService(VkApi vkApi)
        {
            _vkApiWrapper = vkApi;
        }

        public async Task RepostPost(RepostInfo info)
        {
            
        }
    }
}