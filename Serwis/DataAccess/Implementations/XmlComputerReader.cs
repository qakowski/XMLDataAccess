using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Serwis.Models;
using System.Xml;
using System.Xml.Serialization;

namespace Serwis.DataAccess.Implementations
{
    class XmlComputerReader : ISourceReader
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Computer>), new XmlRootAttribute("ComputerList"));
        public List<Computer> ReadBooks(string filePath)
        {
            using (var file = File.OpenRead(filePath))
            {
                return (List<Computer>)serializer.Deserialize(file);
            }
        }
    }
}
