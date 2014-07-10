using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODSlackParser {
	class LineReader {

		public Action<string> OnNewLineDetected;

		private int _linesProcessed;

		public LineReader(string file) {
			_linesProcessed = 0;

			FileSystemWatcher watcher = new FileSystemWatcher();
			watcher.Path = Directory.GetCurrentDirectory();
			watcher.NotifyFilter = NotifyFilters.LastWrite;
			watcher.Filter = "*.log";
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.EnableRaisingEvents = true;
		}

		private void OnChanged(object sender, FileSystemEventArgs e) {

			if (e.ChangeType == WatcherChangeTypes.Changed) {
				bool isFileInUse = true;
				int totalLines = _linesProcessed;

				while (isFileInUse) {
					try {
						string[] lines = File.ReadAllLines(e.FullPath);

						if (lines.Length < _linesProcessed)
							return;

						string[] subarray = SubArray(lines, _linesProcessed, lines.Length - _linesProcessed);
						ProcessLines(subarray);

						totalLines = lines.Length;
					} catch (IOException exception) {
						Console.WriteLine("File in use");
						isFileInUse = true;
					} finally {
						isFileInUse = false;
					}
				}

				_linesProcessed = totalLines;
			}
		}

		private void ProcessLines(string[] newLines) {
			foreach (string newLine in newLines) {
				if (OnNewLineDetected != null)
					OnNewLineDetected(newLine);
			}
		}

		public static string[] SubArray(string[] data, int index, int length) {
			string[] result = new string[length];
			Array.Copy(data, index, result, 0, length);
			return result;
		}
	}
}
