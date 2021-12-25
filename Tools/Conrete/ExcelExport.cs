using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Tools.Abstract;

namespace Tools.Conrete
{
    public class ExcelExport<T> : IExcelExport<T> where T : class
    {

        public byte[] ExportToExcel(List<T> t)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("List");

                //write column name
                var columnCount = 0;
                foreach (var item in t)
                {
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (columnCount == 0)
                        {
                            columnCount++;
                            continue;
                        } // dont pass ID column
                        worksheet.Cell(1, columnCount).Value = Convert.ToString(property.Name);
                        columnCount++;
                    }
                    break;
                }

                //write rows
                int rowCount = 2;
                foreach (var item in t)
                {
                    var columnCountForRow = 0;
                    foreach (var property in typeof(T).GetProperties())
                    {
                        if (columnCountForRow == 0)
                        {
                            columnCountForRow++;
                            continue;
                        } // dont pass ID column
                        worksheet.Cell(rowCount, columnCountForRow).Value = Convert.ToString(property.GetValue(item, null)).Trim();
                        columnCountForRow++;
                    }
                    rowCount++;
                }

                //convert file format
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }
        }
    }
}
