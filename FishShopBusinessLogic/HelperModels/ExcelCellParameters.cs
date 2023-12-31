﻿using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.HelperModels
{
    public class ExcelCellParameters
    {
        public Worksheet Worksheet { get; set; }
        public string ColumnName { get; set; }
        public uint RowIndex { get; set; }
        public UInt32Value StyleIndex { get; set; }
        public string Text { get; set; }
        public SharedStringTablePart ShareStringPart { get; set; }
        public string CellReference => $"{ColumnName}{RowIndex}";

    }
}
