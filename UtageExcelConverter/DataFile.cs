using System.Collections.Generic;

namespace UtageExcelConverter
{
    public class DataFile
    {
        public List<DataCommand> Commands { get; private set; } = new List<DataCommand>();
        public string FileName { get; private set; }

        public DataFile(in string fileName)
        {
            FileName = fileName;
        }
    }
}