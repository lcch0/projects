using System;
using System.IO;

namespace Logic.Models.XmlSerializers
{
    public class SingleFileSerializer<T> where T : new()
    {
        public static bool Save(T config, string path, out Exception ex)
        {
            ex = null;
            if (config == null)
                return false;

            BaseXmlSerializer.WriteFile(path, config, out ex);

            return ex == null;
        }

        public static T Load(string path, out Exception ex)
        {
            ex = null;
            return File.Exists(path) ? BaseXmlSerializer.ReadFile<T>(path, out ex) : default(T);
        }
    }
}