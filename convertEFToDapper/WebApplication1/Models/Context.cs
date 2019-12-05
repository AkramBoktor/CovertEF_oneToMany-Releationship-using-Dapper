﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<ToDoItem> toDoItems { get; set; }
        public DbSet<ToDoItemDetails> toDoItemDetails { get; set; }
    }
}
