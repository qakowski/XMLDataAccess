using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Serwis.Models;

namespace Serwis.DataAccess.Implementations
{
    class XmlComputerWriter : ISourceWriter
    {
        static XmlSerializer serializer = new XmlSerializer(typeof(List<Computer>), new XmlRootAttribute("ComputerList"));
        public void WriteComputers(string filePath, List<Computer> Computers)
        {
            using (var file = File.OpenWrite(filePath))
            {
                serializer.Serialize(file, Computers);
            }
        }
    }
}
