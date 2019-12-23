using System.Collections.Generic;
using Infrastructure.Models;

namespace Infrastructure.Providers
{
    public interface IDataProvider<T>
    {
        T Get(int id);
        void SaveMany(IEnumerable<T> posts);
        T Save(T post);
    }
}