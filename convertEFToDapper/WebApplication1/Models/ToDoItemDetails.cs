using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ToDoItemDetails
    {
        [Key]
        public int Id { get; set; }
        public int TodoItemId { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public ToDoItem TodoItem { get; set; }
    }
}
