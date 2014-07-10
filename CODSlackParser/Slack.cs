using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CODSlackParser {
	class Slack {
		public const string SLACK_URL = "PUT SLACK WEBHOOK HERE";

		public Slack() {
		}

		public void SendMessage(string channel, string username, string message, string icon) {

			string payload;
			payload = "payload={\"channel\": \"" + channel + "\", \"username\": \"" + username + "\", \"text\": \""+ message + "\", \"icon_emoji\": \"" + icon + "\"}";

			System.Net.WebRequest request = WebRequest.Create(SLACK_URL);

			//request.ContentType = "application/json";
			request.ContentType = "application/x-www-form-urlencoded";
			request.Method = "POST";
			byte[] buffer = Encoding.GetEncoding("UTF-8").GetBytes(payload);
			string result = System.Convert.ToBase64String(buffer);
			Stream reqstr = request.GetRequestStream();
			reqstr.Write(buffer, 0, buffer.Length);
			reqstr.Close();

			WebResponse response = request.GetResponse();
		}
	}
}
