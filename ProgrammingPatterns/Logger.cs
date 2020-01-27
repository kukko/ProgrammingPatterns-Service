using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPatterns
{
    class Logger
    {
        public static void Log(string tag, string message)
        {
            DateTime now = DateTime.Now;
            File.WriteAllLines(GetLogFilename(now), new string[] {
                PrepareLineForLog(now, tag, message)
            });
        }
        private static string GetLogFilename()
        {
            return GetLogFilename(DateTime.Now);
        }
        private static string GetLogFilename(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd") + ".txt";
        }
        private static string GetDateTimeForLog()
        {
            return GetDateTimeForLog(DateTime.Now);
        }
        private static string GetDateTimeForLog(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private static string PrepareLineForLog(string tag, string message)
        {
            return PrepareLineForLog(DateTime.Now, tag, message);
        }
        private static string PrepareLineForLog(DateTime dateTime, string tag, string message)
        {
            return "\"" + String.Join("\";\"", new string[]{
                    GetDateTimeForLog(dateTime),
                    tag,
                    message
                }) + "\"";
        }
    }
}
