using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace OfficeStruct_Agent_Win.Classes
{
    public static class Xml
    {
        /// <summary>
        /// This method serializes given object into an XML string
        /// </summary>
        /// <param name="objectToSerialize">Object to be serialized</param>
        /// <returns>XML string representing the object</returns>
        public static string Serialize(object objectToSerialize)
        {
            var mem = new MemoryStream();
            var ser = new XmlSerializer(objectToSerialize.GetType());
            ser.Serialize(mem, objectToSerialize);
            var utf8 = new UTF8Encoding();
            return utf8.GetString(mem.ToArray());
        }
        /// <summary>
        /// This method serializes given object into a file
        /// </summary>
        /// <param name="objectToSerialize">Object to be serialized</param>
        /// <param name="filename">Filename to save XML string into</param>
        /// <returns>XML string representing the object</returns>
        public static string ToFile(object objectToSerialize, string filename)
        {
            var s = Serialize(objectToSerialize);
            File.WriteAllText(filename, s, Encoding.UTF8);
            return s;
        }
        /// <summary>
        /// This method converts an XML string into the object represented by it
        /// </summary>
        /// <typeparam name="T">Type of the object to be deserialized</typeparam>
        /// <param name="xmlString">XML string representing the object</param>
        /// <returns>The object represented from XML string</returns>
        public static T Deserialize<T>(string xmlString)
        {
            var type = typeof(T);
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var mem = new MemoryStream(bytes);
            var ser = new XmlSerializer(type);
            return (T)ser.Deserialize(mem);
        }
        /// <summary>
        /// This method converts an XML string contained in given file into the object represented by it
        /// </summary>
        /// <typeparam name="T">Type of the object to be deserialized</typeparam>
        /// <param name="filename">Filename used to read XML string</param>
        /// <returns>The object represented from XML string read from file</returns>
        public static T FromFile<T>(string filename)
        {
            var xmlString = File.ReadAllText(filename, Encoding.UTF8)
                .Replace(">True<", ">true<")
                .Replace(">False<", ">false<");
            var type = typeof(T);
            var bytes = Encoding.UTF8.GetBytes(xmlString);
            var mem = new MemoryStream(bytes);
            var ser = new XmlSerializer(type);
            return (T)ser.Deserialize(mem);
        }
    }
}
