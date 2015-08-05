using System.Collections.Generic;
using System.Linq;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItemDatabase 
	{
	    private readonly string _connectionString;
	    private MyEntityContext _context;

		public TodoItemDatabase()
		{
		    _connectionString = DependencyService.Get<IBrightstarConnectionStringProvider>().GetConnectionString();
		    _context = new MyEntityContext(_connectionString);
        }


		public IEnumerable<ITodoItem> GetItems ()
		{
		    return _context.TodoItems.ToList();
		}

		public IEnumerable<ITodoItem> GetItemsNotDone ()
		{
		    return _context.TodoItems.Where(x => !x.Done);
		}

		public ITodoItem GetItem (string id) 
		{
		   return _context.TodoItems.FirstOrDefault(x => x.ID.Equals(id));
		}

		public string SaveItem (TodoItem item) 
		{
		    if (item.ID == null)
		    {
		        _context.TodoItems.Add(item);
		    }
            _context.SaveChanges();
		    return item.ID;
		}

		public int DeleteItem(string id)
		{
		    var toDelete = _context.TodoItems.FirstOrDefault(x => x.ID.Equals(id));
		    if (toDelete == null) return 0;
		    _context.DeleteObject(toDelete);
		    _context.SaveChanges();
		    return 1;
		}
	}
}

