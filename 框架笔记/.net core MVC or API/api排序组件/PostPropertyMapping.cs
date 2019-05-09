using System;
using System.Collections.Generic;
using System.Text;
using BlogDemo.Core.Entites;
using BlogDemo.Infrastructure.Dto;
using BlogDemo.Infrastructure.Services;

namespace BlogDemo.Infrastructure.Dto
{
    public class PostPropertyMapping : PropertyMapping<PostDto, Post>
    {
        public PostPropertyMapping() : base(
            new Dictionary<string, List<MappedProperty>>
                (StringComparer.OrdinalIgnoreCase)
                {
                    [nameof(PostDto.Title)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Post.Title), Revert = false}
                    },
                    [nameof(PostDto.Body)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Post.Body), Revert = false}
                    },
                    [nameof(PostDto.Author)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Post.Author), Revert = false}
                    }
                })
        {
        }
    }
}
