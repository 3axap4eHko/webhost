using System;

namespace webhost.Libs.Application
{
	public class ErrorCommand : AbstractCommand
	{
		public ErrorCommand ()
		{
		}

		public override void execute(string[] args)
		{
			Console.WriteLine ("Error");
		}

	}
}

