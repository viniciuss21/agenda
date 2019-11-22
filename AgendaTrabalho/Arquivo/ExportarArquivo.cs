using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AgendaContato.Arquivo
{
    public class ExportarArquivo
    {
        private string pathCsv = "C:\\tmp\\exportCsv\\teste.csv";

        public void exportCsv(DataGrid DG)
        {


            DG.SelectAllCells();
            DG.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, DG);
            DG.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            File.AppendAllText(pathCsv, result, UnicodeEncoding.UTF8);
            MessageBox.Show("Arquivo Csv exportado para: " + pathCsv);

        }

    }
}
