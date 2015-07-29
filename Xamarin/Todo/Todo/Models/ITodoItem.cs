using System;
using BrightstarDB.EntityFramework;

namespace Todo
{
    [Entity]
	public interface ITodoItem
	{
		[Identifier]
		string ID { get; }
		string Name { get; set; }
		string Notes { get; set; }
		bool Done { get; set; }
	}
}

