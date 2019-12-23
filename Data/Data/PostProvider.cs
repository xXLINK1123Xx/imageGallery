using System;
using System.Collections.Generic;
using System.Linq;
using Data.Comparators;
using Infrastructure.Models;
using Infrastructure.Providers;

namespace Data.Data
{
    public class PostProvider: IDataProvider<Post>
    {
        private readonly SortedSet<Post> _posts;

        public PostProvider()
        {
            _posts = new SortedSet<Post>(new PostComparer());
        }
        
        public Post Get(int id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public void SaveMany(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                _posts.Add(post);
            }
        }

        public Post Save(Post post)
        {
            _posts.Add(post);
            return post;
        }

    }
}