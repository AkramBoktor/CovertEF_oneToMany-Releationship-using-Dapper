using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {




        // GET: api/ToDoItem
        public IEnumerable GetAll()
        {
            /*  using (IDbConnection db = new SqlConnection("Server=.;Initial Catalog=ConvertEfToDapper;Trusted_Connection=True"))
              {
                  return db.Query<ToDoItem>
                  ("SELECT* FROM ToDoItems td JOIN TodoItemDetails details ON details.TodoItemId = td.Id").ToList();
              }*/


            var todoDictionary = new Dictionary<int, ToDoItem>();

            string query = "SELECT* FROM ToDoItems td JOIN TodoItemDetails details ON details.TodoItemId = td.Id";

            using (IDbConnection con = new SqlConnection("Server=.;Initial Catalog=ConvertEfToDapper;Trusted_Connection=True"))
            {
                var result = con.Query<ToDoItem, ToDoItemDetails, ToDoItem>(query, (todoItem, todoItemDetail) => {

                    ToDoItem todoEntry;

                    if (!todoDictionary.TryGetValue(todoItem.Id, out todoEntry))
                    {

                        todoEntry = todoItem;

                        todoEntry.Details = new List<ToDoItemDetails>();

                        todoDictionary.Add(todoEntry.Id, todoEntry);
                    }

                    todoEntry.Details.Add(todoItemDetail);

                    return todoEntry;
                });

                return result;
            }



        }



        /*  public IEnumerable Get()
          {
             return _context.toDoItems.Include(a => a.Details).ToList();
          }*/

    }
}