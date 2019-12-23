using System.Collections.Generic;
using Infrastructure.Models;

namespace Data.Comparators
{
    public class PostComparer: IComparer<Post>
    {
        public int Compare(Post x, Post y)
        {
            if(x != null && y != null)
                return x.Id.CompareTo(y.Id);

            return 0;
        }
    }
}