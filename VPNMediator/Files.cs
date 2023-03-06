using System;
using System.Collections.Generic;
using System.Text;

namespace VPNMediator
{
    [Serializable]
    public class XmlConfFile
    {
        public XmlSerializableDictionary<string, string> listWithConf;
        public XmlConfFile ()
        {
            listWithConf = new XmlSerializableDictionary<string, string>();
        }
        public string this [string keys]
        {
            get 
            {
                if (this.listWithConf.Count == 0)
                {
                    throw new ListsIsEmptytExeption(typeof(XmlConfFile).ToString());
                }
                if (listWithConf.TryGetValue(keys, out string value))
                {
                    return listWithConf[keys];
                }
                else
                {
                    throw new InvalidInstructionException(keys);
                }
            }
        }
    }
    [Serializable]
    public class XmlCommandFile
    {
        public List<string> listWithCommands;

        public XmlCommandFile ()
        {
            listWithCommands = new List<string>();
        }
        public string this [int index]
        {
            get
            {
                if (this.listWithCommands.Count == 0)
                {
                    throw new ListsIsEmptytExeption(typeof(XmlCommandFile).ToString());
                }
                else
                {
                    return listWithCommands[index];
                }                
            }
        }
    }
}
