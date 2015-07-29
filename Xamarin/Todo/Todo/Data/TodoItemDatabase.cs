using System.Collections.Generic;
using System.Linq;
using Todo.Models;
using Xamarin.Forms;

namespace Todo
{
	public class TodoItemDatabase 
	{
	    private readonly string _connectionString;

		public TodoItemDatabase()
		{
		    _connectionString = DependencyService.Get<IBrightstarConnectionStringProvider>().GetConnectionString();
		}


	    private MyEntityContext GetContext()
	    {
	        return new MyEntityContext(_connectionString);
	    }

		public IEnumerable<ITodoItem> GetItems ()
		{
		    using (var context = GetContext())
		    {
		        return context.TodoItems.ToList();
		    }
		}

		public IEnumerable<ITodoItem> GetItemsNotDone ()
		{
		    using (var context = GetContext())
		    {
		        return context.TodoItems.Where(x => !x.Done);
		    }
		}

		public ITodoItem GetItem (string id) 
		{
		    using (var context = GetContext())
		    {
		        return context.TodoItems.FirstOrDefault(x => x.ID.Equals(id));
		    }
		}

		public string SaveItem (TodoItem item) 
		{
		    using (var context = GetContext())
		    {
                // Ensure we don't try to attach an item that is already attached to a different context instance
                if (item.IsAttached) item.Detach();
		        context.TodoItems.AddOrUpdate(item);
                context.SaveChanges();
		    }
		    return item.ID;
		}

		public int DeleteItem(string id)
		{
		    using (var context = GetContext())
		    {
		        var toDelete = context.TodoItems.FirstOrDefault(x => x.ID.Equals(id));
		        if (toDelete == null) return 0;
		        context.DeleteObject(toDelete);
		        context.SaveChanges();
		        return 1;
		    }
		}
	}
}

