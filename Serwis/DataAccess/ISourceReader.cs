using Serwis.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serwis.DataAccess
{
    interface ISourceReader
    {
        List<Computer> ReadBooks(string filePath);
    }
}
