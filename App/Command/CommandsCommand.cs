using System;
using System.Collections.Generic;
using webhost;

namespace webhost.App.Command
{
	public class CommandsCommand : AbstractCommand
	{
		public CommandsCommand ()
		{
			Hidden = true;
		}

		public override void execute(string[] args)
		{
			foreach(KeyValuePair<string, AbstractCommand> command in MainClass.Commands)
			{
				if (command.Value.Hidden != true) {
					Console.WriteLine (command.Value.Name);
				}
			}
		}

	}
}

