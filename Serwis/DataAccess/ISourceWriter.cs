using Serwis.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serwis.DataAccess.Implementations
{
    interface ISourceWriter
    {
        void WriteComputers(string filePath, List<Computer> Computers);
    }
}
