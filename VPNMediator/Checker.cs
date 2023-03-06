using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VPNMediator
{
    public class PathString
    {       
        public string Path { get; }

        public PathString(string path)
        {
            Path = path;
        }
        public void PathStringCheck()
        {
            if (!File.Exists(Path))
                throw new FileNotFoundException($"The file {Path} not found");
        }
    }

    public class ArgsString
    {
        string[] args;
        public ArgsString(string[] args  )
        {
            this.args = args;
        }
        public string this [int index]
        {
            get 
            {
                return args[index];
            }
        }
        public void ArgsCheck ()
        {
            if (args.Length != 2)
            {
                throw new Exception("Wrong number of arguments");
            }
        }
    }
    
}
