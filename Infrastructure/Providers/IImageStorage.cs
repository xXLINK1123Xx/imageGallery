using System.Net.Http;
using System.Threading.Tasks;
using Infrastructure.Models;

namespace Infrastructure.Providers
{
    public interface IImageStorage
    {
        Task<string> GetImage(Post post);
        Task<string> SaveImage(Post post);
    }
}