using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tools.Abstract
{
    public interface IExcelExport<T>
    {
        byte[] ExportToExcel(List<T> t);
    }
}
