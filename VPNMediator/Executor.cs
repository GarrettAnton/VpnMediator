using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPNMediator
{
    class Executor
    {
        private string command;
        public Executor (string command)
        {
            this.command = command;
        }
        public async void RunTask ()
        {
             await Task.Run(new Action(this.Run));
        }
        public void Run ()
        {
            string filePath = (command.Split(new char[] { ' ' }))[0];
            string arguments = command.Split(new char[] { ' ' }).Length>1 ?
            command.Substring( (command.Split(new char[] { ' ' }))[0].Length) : "";
            ProcessStartInfo startInfo = new ProcessStartInfo(filePath, arguments);                
            Process.Start(startInfo);
        }
    }
}
