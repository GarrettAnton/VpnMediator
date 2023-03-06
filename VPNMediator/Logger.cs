using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPNMediator
{
    class Logger
    {
        string pathLog;
        public Logger()
        {
            this.pathLog = Directory.GetCurrentDirectory() +"\\" + DateTime.Today.ToString().Substring(0, 10) + ".log";
        }
        public Logger (string pathLog)
        {
            this.pathLog = pathLog;
        }

        public void BeginLogging ()
        {
            if (!File.Exists(pathLog))
            {
                using (FileStream fs = new FileStream(pathLog, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLineAsync(DateTime.Now + " _____ START");
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(pathLog, true))
                {
                    sw.WriteLineAsync(DateTime.Now + " _____ START");
                }
            }
        }
        public void LogIt (string logMessage)
        {
            using (StreamWriter sw = new StreamWriter(pathLog, true))
            {
                sw.WriteLineAsync(DateTime.Now + " _____ " + logMessage);
            }            
        }
    }
}
