using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTestRun
{
    internal static class LogWriter
    {
        private static List<string> logLines = new List<string>();

        public static void LogLine(string line)
        {
            logLines.Add(DateTime.Now + " - " + line);
        }

        public static void WriteLinesToFile()
        {
            string filePath = @"c:\logs\AutomationLog.log";
            File.AppendAllLines(filePath, logLines.ToArray());
        }
    }
}
