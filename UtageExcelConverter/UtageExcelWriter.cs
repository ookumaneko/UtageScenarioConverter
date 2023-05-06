using System;
using System.IO;

namespace UtageExcelConverter
{
    public class UtageExcelWriter
    {
        private const int _START_ROW = 1;
        private const int _SHEET_INDEX = 0;
        
        enum ColumnType
        {
            Command = 0,
            Arg1,
            Arg2,
            Arg3,
            Arg4,
            Arg5,
            Arg6,
            WaitType,
            Text,
            PageCtrl,
            Voice,
            WindowType,
            English,
            Max
        }
        
        public ParamResult Write(ParamConvert paramConvert, DataConvert data)
        {
            ParamResult result = new ParamResult();
            foreach (var fileData in data.Data)
            {
                WriteFile(paramConvert, fileData, result);
                if (!result.IsSuccess)
                {
                    break;
                }
            }

            if (result.IsSuccess)
            {
                result.Message = Defines._MESSAGE_SUCCESS;
            }

            return result;
        }

        private void WriteFile(ParamConvert paramConvert, DataFile data, ParamResult result)
        {
            ParamSheet paramSheet = new ParamSheet(_START_ROW);

            try
            {
                // コピー作成
                var targetPath = $"{paramConvert.PathOutputFolder}\\{data.FileName}{Defines._EXTENSION_UTAGE_SCENARIO}";
                FileInfo inputExcelFile = new FileInfo (paramConvert.PathTemplateFile);
                inputExcelFile.CopyTo(targetPath, true);
                
                //ブック読み込み
                var book = NPOIUtility.OpenNewBook(targetPath );

                //シート名からシート取得
                var sheet = book.GetSheetAt( _SHEET_INDEX );
                
                paramSheet.Book = book;
                paramSheet.Sheet = sheet;
                book.SetSheetName(_SHEET_INDEX, data.FileName);
                
                foreach (var command in data.Commands)
                {
                    WriteCommand (command, paramSheet, paramConvert);
                }
                
                //ブックを保存
                using (var fs = new FileStream(targetPath, FileMode.Create))
                {
                    book.Write(fs, false);
                }
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }
        }
        
        private void WriteCommand(DataCommand command, ParamSheet sheet, ParamConvert convert)
        {
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Command, sheet.Row, command.Command);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Arg1, sheet.Row, command.Arg1);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Arg2, sheet.Row, command.Arg2);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Arg3, sheet.Row, command.Arg3);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Arg4, sheet.Row, command.Arg4);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Arg5, sheet.Row, command.Arg5);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Arg6, sheet.Row, command.Arg6);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.WaitType, sheet.Row, command.WaitType);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Text, sheet.Row, command.Text);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.PageCtrl, sheet.Row, command.PageCtrl);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.Voice, sheet.Row, command.Voice);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.WindowType, sheet.Row, command.WindowType);
            NPOIUtility.WriteToCell(sheet.Sheet, (int)ColumnType.English, sheet.Row, command.English);
            sheet.Row++;
        }
    }
}