using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODSlackParser {
	class Program {

		private static Slack _slack;

		static void Main(string[] args) {

			LineReader reader = new LineReader("games_mp.log");

			CallOfDutyLogParser parser = new CallOfDutyLogParser();
			reader.OnNewLineDetected += parser.ParseLine;
			parser.OnLoggedLine += OnLoggedLine;

			_slack = new Slack();

			Console.ReadLine();
		}

		private static void OnLoggedLine(LogLine line){
			_slack.SendMessage("test", "COD BOT", line.Player + " " + line.Type, ":cod:");
		}
	}
}
