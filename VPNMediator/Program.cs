using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace VPNMediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            logger.BeginLogging();                        
            try
            {
                ArgsString argsString = new ArgsString(args);
                logger.LogIt("Check arguments ");
                argsString.ArgsCheck();
                PathString conf = new PathString(argsString[0]);
                PathString command = new PathString(argsString[1]);
                logger.LogIt("Check path " + conf.Path);
                conf.PathStringCheck();                
                logger.LogIt("Check path " + command.Path);
                command.PathStringCheck();                
                XmlWriterReader<XmlConfFile> xmlReaderConf = new XmlWriterReader<XmlConfFile>(conf.Path);
                XmlWriterReader<XmlCommandFile> xmlWriterReaderCommand = new XmlWriterReader<XmlCommandFile>(command.Path);
                XmlConfFile xmlConf = xmlReaderConf.Read();
                logger.LogIt("Deserialized " + xmlConf.GetType());
                XmlCommandFile xmlCommand = xmlWriterReaderCommand.Read();
                logger.LogIt("Deserialized " + xmlCommand.GetType());
                try
                {
                    logger.LogIt("Try to execute " + xmlConf[xmlCommand[0]]);
                    Executor executor = new Executor(xmlConf[xmlCommand[0]]);
                    executor.Run();
                    //executor.RunTask();
                }
                catch (ListsIsEmptytExeption e)
                {
                    throw new Exception(e.Message);
                }
                catch (InvalidInstructionException e)
                {
                    logger.LogIt(e.Message);
                    Console.WriteLine(e.Message);
                }
                xmlCommand.listWithCommands.Remove(xmlCommand[0]);
                xmlWriterReaderCommand.Write(xmlCommand);
                logger.LogIt("Serialize " + xmlCommand.GetType());
            }
            catch (Exception e)
            {
                logger.LogIt(e.Message);
                Console.WriteLine(e.Message);
            }
            //Console.ReadKey();

        }
    }
}
