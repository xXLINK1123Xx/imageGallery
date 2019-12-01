using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Providers
{
    public interface IApiProvider
    {
        Task<List<Image>> GetImages(int page = 1, Tag[] tags = null);
        Task<List<Tag>> GetTags();
        Task<Image> GetImage(int id);
    }
}