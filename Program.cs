using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace webhost
{
	class MainClass
	{
		const string VERSION = @"0.0.1beta";
		const string DEFAULT_COMMAND = @"help";

		public static Dictionary<string, AbstractCommand> Commands;

		private static string CamelCaseToDashed(string text)
		{
			return Regex.Replace(text, @"!^([A-Z])", ":$1").ToLower();
		}

		public static void Main (string[] args)
		{
			Console.WriteLine (@"");
			Commands = new Dictionary<string, AbstractCommand> ();
			AbstractCommand command;
			Regex regex = new Regex (@"(\w+)Command");
			foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (type.Namespace == @"webhost.App.Command")
				{
					command = Activator.CreateInstance (type) as AbstractCommand;
					if (command.Name == null) {
						command.Name = CamelCaseToDashed(regex.Match (type.Name).Groups[1].ToString());
					}
					Commands.Add (command.Name, command);
				}
			}
			string commandName =  args.Length>0 ? args[0] : DEFAULT_COMMAND;
			try
			{
				if (!Commands.ContainsKey (commandName)) {
					throw new Exception (@"Command """ + commandName + @""" not found");
				}
				if (args.Length>0)
				{
					Array.Copy(args,1,args,0,args.Length-1);
					Array.Resize(ref args,args.Length-1);
				}
				Commands[commandName].execute(args);
			}catch(Exception e) {
				Console.WriteLine (e.Message);
			}
		}
	}
}
