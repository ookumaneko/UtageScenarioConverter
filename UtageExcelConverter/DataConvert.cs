using System.Collections.Generic;

namespace UtageExcelConverter
{
    public class DataConvert
    {
        private List<DataFile> m_data = new List<DataFile>();

        public List<DataFile> Data => m_data;

        public void Add(DataFile data)
        {
            m_data.Add(data);
        }
    }
}