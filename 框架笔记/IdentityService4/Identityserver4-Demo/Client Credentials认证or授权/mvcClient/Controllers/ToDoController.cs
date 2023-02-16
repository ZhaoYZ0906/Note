using System;
using System.Collections.Generic;
using Api1Resource.Models;
using APIClient.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace APIClient.Controllers
{
    [Route("api/todo")]
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly IMemoryCache memoryCache;
        private const string Key = "TODO_KEY";
        private readonly List<ToDo> _toDos;

        public ToDoController(IMemoryCache memory)
        {
            this.memoryCache = memory;

            //初始化数据
            _toDos = new List<ToDo>
            {
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Title = "吃饭",
                    Completed = true
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Title = "学习C#",
                    Completed = false
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Title = "学习.NET Core",
                    Completed = false
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Title = "学习 ASP.NET Core",
                    Completed = false
                },
                new ToDo
                {
                    Id = Guid.NewGuid(),
                    Title = "学习 Entity Framework",
                    Completed = false
                }
            };

            //写入缓存
            if (!memoryCache.TryGetValue(Key, out List<ToDo> todos))
            {
                todos = _toDos;
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(Key, todos, options);
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            if (!memoryCache.TryGetValue(Key, out List<ToDo> todos))
            {
                todos = _toDos;
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));
                memoryCache.Set(Key, todos, options);
            }

            return Ok(todos);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ToDoEdit toDoEdit)
        {
            var todo = new ToDo
            {
                Id = Guid.NewGuid(),
                Title = toDoEdit.Title,
                Completed = toDoEdit.Completed
            };

            if (!memoryCache.TryGetValue(Key, out List<ToDo> todos))
            {
                todos = _toDos;
            }
            todos.Add(todo);
            var options = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromDays(1));
            memoryCache.Set(Key, todos, options);

            return Ok(todo);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}