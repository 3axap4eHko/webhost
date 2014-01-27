using System;

namespace webhost
{
	abstract public class AbstractCommand
	{
		public string Name;
		public string Description;
		public bool Hidden;

		public AbstractCommand ()
		{
		}

		abstract public void execute(string[] args);
	}
}

