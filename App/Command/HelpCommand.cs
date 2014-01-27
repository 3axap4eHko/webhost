using System;
using System.Collections.Generic;
using webhost;

namespace webhost.App.Command
{
	public class HelpCommand : AbstractCommand
	{
		public HelpCommand ()
		{
			Hidden = true;
			Description = "display current information";
		}

		public override void execute(string[] args)
		{
			Console.WriteLine (@"Avalilable commands:");
			foreach(KeyValuePair<string, AbstractCommand> command in MainClass.Commands)
			{
				if (command.Value.Hidden != true) {
					Console.WriteLine (String.Format("\t{0} - {1}", command.Value.Name, command.Value.Description));
				}
			}
			Console.WriteLine (String.Format("\t{0} - {1}", Name, Description));
		}
	}
}

