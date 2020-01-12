using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Providers
{
    public interface IApiProvider
    {
        Task<List<Post>> GetPosts(int page = 1, Tag[] tags = null);
        Task<List<Tag>> GetTags();
    }
}