using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Logic.Models.XmlSerializers
{
	internal class BaseXmlSerializer
	{
		private XmlSerializer _s;
		private string _customRoot;
		private XmlSerializerNamespaces _ns;
		
		private BaseXmlSerializer()
		{
		}

		private static XmlSerializer CreateXmlSerializer(string customRoot, Type type)
		{
			return string.IsNullOrEmpty(customRoot) ? new XmlSerializer(type) : new XmlSerializer(type, new XmlRootAttribute(customRoot));
		}

		private static BaseXmlSerializer CreateProjectXmlSerializer<T>(string customRoot)
		{
			var p = new BaseXmlSerializer
			{
				_customRoot = customRoot,
				_s = CreateXmlSerializer(customRoot, typeof(T)),
				_ns = new XmlSerializerNamespaces()
			};
			p._ns.Add(string.Empty, string.Empty);

			return p;
		}

		/// <summary>Deserializes to an instance of Project.</summary>
		/// <param name="xml">String xml.</param>
		/// <returns>Project result.</returns>
		public T Deserialize<T>(string xml)
		{
			TextReader reader = new StringReader(xml);
			return Deserialize<T>(reader);
		}

		/// <summary>Deserializes to an instance of Project.</summary>
		/// <param name="doc">XmlDocument instance.</param>
		/// <returns>Project result.</returns>
		public T Deserialize<T>(XmlDocument doc)
		{
			TextReader reader = new StringReader(doc.OuterXml);
			return Deserialize<T>(reader);
		}

		/// <summary>Deserializes to an instance of Project.</summary>
		/// <param name="reader">TextReader instance.</param>
		/// <returns>Project result.</returns>
		public T Deserialize<T>(TextReader reader)
		{
			var o = (T)_s.Deserialize(reader);
			reader.Close();
			return o;
		}

		/// <summary>Serializes to an XmlDocument.</summary>
		/// <param name="project">Project to serialize.</param>
		/// <returns>XmlDocument instance.</returns>
		public XmlDocument Serialize<T>(T project)
		{
			string xml = StringSerialize(project);
			var doc = new XmlDocument { PreserveWhitespace = true };
			doc.LoadXml(xml);
			doc = Clean(doc);
			return doc;
		}

		private string StringSerialize<T>(T project)
		{
			TextWriter w = WriterSerialize(project);
			string xml = w.ToString();
			w.Close();
			return xml.Trim();
		}

		private TextWriter WriterSerialize<T>(T project)
		{
			TextWriter w = new Utf8StringWriter();
			if (_s == null)
			{
				_s = CreateXmlSerializer(_customRoot, project.GetType());
			}
			_s.Serialize(w, project, _ns);
			w.Flush();
			return w;
		}

		private static XmlDocument Clean(XmlDocument doc)
		{
			doc.RemoveChild(doc.FirstChild);
			XmlNode first = doc.FirstChild;
			foreach (XmlNode n in doc.ChildNodes)
			{
				if (n.NodeType == XmlNodeType.Element)
				{
					first = n;
					break;
				}
			}
			if (first.Attributes != null)
			{
				XmlAttribute a = first.Attributes["xmlns:xsd"];
				if (a != null)
				{
					first.Attributes.Remove(a);
				}
				a = first.Attributes["xmlns:xsi"];
				if (a != null)
				{
					first.Attributes.Remove(a);
				}
			}
			return doc;
		}

		/// <summary>Reads config data from config file.</summary>
		/// <param name="file">Config file name.</param>
		/// <param name="ex"></param>
		/// <param name="customRoot"></param>
		/// <returns></returns>
		public static T ReadFile<T>(string file, out Exception ex, string customRoot = null)
		{
			ex = null;
			var serializer = CreateProjectXmlSerializer<T>(customRoot);
			try
			{
				string xml;
				using (var reader = new StreamReader(file))
				{
					xml = reader.ReadToEnd();
					reader.Close();
				}
				return serializer.Deserialize<T>(xml);
			}
			catch (Exception exx)
			{
				ex = exx;
			}
			return default(T);
		}

		/// <summary>Reads config data from config file.</summary>
		/// <param name="reader">Stream containing the file to deserialize.</param>
		/// <param name="ex"></param>
		/// <param name="customRoot"></param>
		/// <returns></returns>
		public static T ReadFile<T>(StreamReader reader, out Exception ex, string customRoot = null)
		{
			ex = null;
			var serializer = CreateProjectXmlSerializer<T>(customRoot);
			try
			{
				string xml = reader.ReadToEnd();
				return serializer.Deserialize<T>(xml);
			}
			catch (Exception exx)
			{
				ex = exx;
			}
			return default(T);
		}

		public static bool WriteFile<T>(string file, T config, out Exception ex, string customRoot = null)
		{
			ex = null;
			bool ok = false;
			var serializer = CreateProjectXmlSerializer<T>(customRoot);
			try
			{
				string xml = serializer.Serialize(config).OuterXml;
				using (var writer = new StreamWriter(file, false, Encoding.UTF8))
				{
					writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
					writer.Write(xml.Trim());
					writer.Flush();
					writer.Close();
				}
				ok = true;
			}
			catch (Exception exx)
			{
				ex = exx;
			}
			return ok;
		}

		private class Utf8StringWriter : StringWriter
		{
			public override IFormatProvider FormatProvider => CultureInfo.InvariantCulture;

			public override Encoding Encoding => Encoding.UTF8;
		}
	}
}