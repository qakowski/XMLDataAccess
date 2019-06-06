using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serwis.DataAccess.Implementations
{
    class DialogService : IDialogService
    {

        public string OpenFileDialog()
        {
            var fileDialog = new OpenFileDialog
            {
                DefaultExt = ".xml",
                Filter = "XML Files (*.xml)|*.xml"
            };
            bool? showResult = fileDialog.ShowDialog();
            return showResult == true ? fileDialog.FileName : null;
        }

        public string SaveToFileDialog()
        {
            var fileDialog = new SaveFileDialog
            {
                DefaultExt = ".xml",
                Filter = "XML Files (*.xml)|*.xml"
            };
            bool? showResult = fileDialog.ShowDialog();
            return showResult == true ? fileDialog.FileName : null;
        }
    }
}
