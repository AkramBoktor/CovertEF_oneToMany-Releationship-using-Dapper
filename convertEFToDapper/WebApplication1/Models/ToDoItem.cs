using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            Details = new HashSet<ToDoItemDetails>();
        }
        [Key]
        public int Id { get; set; }
        public string ToDoText { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public ICollection<ToDoItemDetails> Details { get; set; }
    }
}
