using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODSlackParser {
	class CallOfDutyLogParser {

		public Action<LogLine> OnLoggedLine;

		public CallOfDutyLogParser() {
			
		}

		public void ParseLine(string line) {
			LogLine logLine = new LogLine(line);

			OnLoggedLine(logLine);
		}
	}
}
