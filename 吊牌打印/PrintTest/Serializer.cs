using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace PrintTest
{
    public class Serializer
    {
        public static string XmlSerialize<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.Indent = true;
            xws.OmitXmlDeclaration = true;
            XmlWriter textWriter = XmlWriter.Create(ms, xws);
            serializer.Serialize(textWriter, obj);
            byte[] mybyte = ms.ToArray();

            textWriter.Close();
            ms.Close();
            return Encoding.UTF8.GetString(mybyte, 0, mybyte.Length);
        }

        public static T XmlDeSerialize<T>(string objString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(objString));
            ms.Position = 0;
            T _obj = (T)serializer.Deserialize(ms);
            ms.Close();         
            return _obj;
        }
    }
}