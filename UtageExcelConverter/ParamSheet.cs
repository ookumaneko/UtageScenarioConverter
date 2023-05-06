using NPOI.SS.UserModel;

namespace UtageExcelConverter
{
    public class ParamSheet
    {
        public IWorkbook Book;
        public ISheet Sheet;
        public int Row = 0;
        public int Col = 0;

        public ParamSheet(int startRow = 0, int startCol = 0)
        {
            Row = startRow;
            Col = startCol;
        }
    }
}