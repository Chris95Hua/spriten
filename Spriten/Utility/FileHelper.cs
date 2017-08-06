using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Spriten.Utility
{
    public static class FileHelper
    {
        public static void SerializeXML<T>(T toWrite, string path) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, toWrite);
            }
        }

        public static T DeserializeXML<T>(string path) where T : new()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using(TextReader reader = new StreamReader(path))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        public static void SerializeBinary<T>(T toSerialize, string path) where T : new()
        {
            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, toSerialize);
            stream.Close();
        }

        public static T DeserializeBinary<T>(string path) where T : new()
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            T toReturn = (T)formatter.Deserialize(stream);
            stream.Close();
            return toReturn;
        }
    }
}
