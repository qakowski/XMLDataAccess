using System;
using System.Collections.Generic;
using System.Text;

namespace Serwis.DataAccess
{
    interface IDialogService
    {
        string OpenFileDialog();
        string SaveToFileDialog();
    }
}
