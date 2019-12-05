# CovertEF_oneToMany-Releationship-using-Dapper
CovertEF_oneToMany Releationship using Dapper
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
