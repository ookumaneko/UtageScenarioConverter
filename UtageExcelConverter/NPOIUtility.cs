using System;
using System.IO;

using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

namespace UtageExcelConverter
{
	static class NPOIUtility
	{
		public static IWorkbook CreateNewBook (string filePath)
		{
			IWorkbook book;
			var extension = Path.GetExtension (filePath);

			// HSSF => Microsoft Excel(xls形式)(excel 97-2003)
			// XSSF => Office Open XML Workbook形式(xlsx形式)(excel 2007以降)
			if (extension == Defines._EXTENSION_XLS)
			{
				book = new HSSFWorkbook ();
			}
			else if (extension == Defines._EXTENSION_XLSX)
			{
				book = new XSSFWorkbook ();
			}
			else
			{
				throw new ApplicationException ("CreateNewBook: invalid extension");
			}

			return book;
		}

		public static IWorkbook OpenNewBook (string filePath)
		{
			IWorkbook book;
			var extension = Path.GetExtension (filePath);

			// HSSF => Microsoft Excel(xls形式)(excel 97-2003)
			// XSSF => Office Open XML Workbook形式(xlsx形式)(excel 2007以降)
			if (extension == Defines._EXTENSION_XLS)
			{
				book = WorkbookFactory.Create(filePath);  //new HSSFWorkbook ();
			}
			else if (extension == Defines._EXTENSION_XLSX)
			{
				book = new XSSFWorkbook (filePath);
			}
			else
			{
				throw new ApplicationException ("CreateNewBook: invalid extension");
			}

			return book;
		}

		public static void WriteToCell (ISheet sheet, int columnIndex, int rowIndex, string value, ICellStyle style = null)
		{
			var row = sheet.GetRow (rowIndex) ?? sheet.CreateRow (rowIndex);
			var cell = row.GetCell (columnIndex) ?? row.CreateCell (columnIndex);

			cell.SetCellValue (value);
			cell.SetCellType (CellType.String);
			if (style != null)
			{
				cell.CellStyle = style;
			}
		}

		public static void WriteToCell (ISheet sheet, int columnIndex, int rowIndex, int value, ICellStyle style = null)
		{
			var row = sheet.GetRow (rowIndex) ?? sheet.CreateRow (rowIndex);
			var cell = row.GetCell (columnIndex) ?? row.CreateCell (columnIndex);

			cell.SetCellValue (value);
			cell.SetCellType (CellType.Numeric);
			if (style != null)
			{
				cell.CellStyle = style;
			}
		}

		public static void WriteCellStyle (ISheet sheet, int columnIndex, int rowIndex, ICellStyle style)
		{
			var row = sheet.GetRow (rowIndex) ?? sheet.CreateRow (rowIndex);
			var cell = row.GetCell (columnIndex) ?? row.CreateCell (columnIndex);
			cell.CellStyle = style;
		}

		public static ICell GetCell (ISheet sheet, int columnIndex, int rowIndex)
		{
			var row = sheet.GetRow (rowIndex) ?? sheet.CreateRow (rowIndex);
			return row.GetCell (columnIndex) ?? row.CreateCell (columnIndex);
		}
	}
}
