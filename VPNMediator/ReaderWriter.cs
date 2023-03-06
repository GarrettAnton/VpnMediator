using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace VPNMediator
{
    //interface IReader<T>
    //{
    //    T Read();
    //}

    public class XmlWriterReader <T>// : IReader<XmlConfFile>
    {
        private string pathFile;
        public XmlWriterReader(string path)
        {
            pathFile = path;
        }
        public T Read()
        {            
            using (FileStream fs = new FileStream(pathFile, FileMode.Open))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));
                return (T)(serialiser.Deserialize(fs)) ?? throw new InvalidConvertExeption(typeof(T).ToString(), pathFile);
            }
        }

        public void Write (T t)
        {
            using (FileStream fs = new FileStream(pathFile, FileMode.Create))
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));
                serialiser.Serialize(fs, t);
            }
        }
    }
    

}
