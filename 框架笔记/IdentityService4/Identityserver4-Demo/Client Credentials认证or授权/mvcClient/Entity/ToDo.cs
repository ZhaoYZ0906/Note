using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIClient.Entity
{
    public class ToDo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

    }
}
