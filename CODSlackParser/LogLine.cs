using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODSlackParser {
	class LogLine {

		public enum LogType {
			KILL,
			DEATH,
			JOIN,
			SAY
		}

		public string Time { get; private set; }
		public string Player { get; private set; }
		public LogType Type { get; private set; }

		public LogLine(string line) {
			string[] pieces = line.Split(';');

			ParseTime(pieces[0]);
			ParseType(pieces[0]);

			Console.WriteLine("Type: " + Type + " - on time: " + Time);
		}

		private void ParseTime(string piece) {
			string[] pieces = piece.Split(' ');
			if (pieces.Length < 2)
				return;

			Time = pieces[pieces.Length - 2];
			
		}

		private void ParseType(string piece) {
			string[] pieces = piece.Split(' ');
			string typeString = pieces[pieces.Length - 1];

			switch (typeString) {
				case "J":
					Type = LogType.JOIN;
					break;
				case "D":
					Type = LogType.DEATH;
					break;
				case "K":
					Type = LogType.KILL;
					break;
				case "say":
					Type = LogType.SAY;
					break;
			}

		}
	}
}
