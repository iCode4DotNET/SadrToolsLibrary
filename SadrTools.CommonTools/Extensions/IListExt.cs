using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace SadrTools.Extensions;

public static class IListExt
{
    public static TList Push<TList, TItem>(this TList list, TItem item) where TList : IList<TItem>
    {
        if (list.IsReadOnly)
            throw new Exception(CommonConsts.Messages.Exception.ReadOnlyList);

        list.Add(item);
        return list;
    }

    public static void ToExcel<T>(this List<T> list, string path)
    {

        #region [ تعریفات ]

        if (path.IsNullOrEmpty())
            throw new Exception(CommonConsts.Messages.Exception.InvalidObject);

        if (list == null)
            throw new Exception(CommonConsts.Messages.Exception.InvalidObject);


        Excel.Application excelApp = null;
        Excel.Workbooks workBooks = null;
        Excel._Workbook workBook = null;
        Excel.Sheets sheets = null;
        Excel._Worksheet workSheet = null;
        Excel.Range range = null;
        Excel.Font font = null;
        object optionalValue = Missing.Value;

        string strHeaderStart = "A2";
        string strDataStart = "A3";
        #endregion

        #region [ پردازش ]

        try
        {
            #region [ ایجاد ]

            excelApp = new Excel.Application();
            workBooks = (Excel.Workbooks)excelApp.Workbooks;
            workBook = (Excel._Workbook)(workBooks.Add(optionalValue));
            sheets = (Excel.Sheets)workBook.Worksheets;
            workSheet = (Excel._Worksheet)(sheets.get_Item(1));

            #endregion

            #region [ هدر ]

            Dictionary<string, string> objHeaders = new Dictionary<string, string>();

            PropertyInfo[] headerInfo = typeof(T).GetProperties();


            foreach (var property in headerInfo)
            {
                var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                                        .Cast<DisplayNameAttribute>().FirstOrDefault();
                objHeaders.Add(property.Name, attribute == null ? property.Name : attribute.DisplayName);
            }


            range = workSheet.get_Range(strHeaderStart, optionalValue);
            range = range.get_Resize(1, objHeaders.Count);

            range.set_Value(optionalValue, objHeaders.Values.ToArray());
            range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

            font = range.Font;
            font.Bold = true;
            range.Interior.Color = Color.LightGray.ToArgb();

            #endregion

            #region [ نوشتن دیتا در سلول ها ]


            int count = list.Count;
            object[,] objData = new object[count, objHeaders.Count];

            for (int j = 0; j < count; j++)
            {
                var item = list[j];
                int i = 0;
                foreach (KeyValuePair<string, string> entry in objHeaders)
                {
                    var y = typeof(T).InvokeMember(entry.Key.ToString(), BindingFlags.GetProperty, null, item, null);
                    objData[j, i++] = (y == null) ? "" : y.ToString();
                }
            }


            range = workSheet.get_Range(strDataStart, optionalValue);
            range = range.get_Resize(count, objHeaders.Count);

            range.set_Value(optionalValue, objData);
            range.BorderAround(Type.Missing, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Type.Missing);

            range = workSheet.get_Range(strHeaderStart, optionalValue);
            range = range.get_Resize(count + 1, objHeaders.Count);
            range.Columns.AutoFit();

            #endregion

            #region [ ذخیره فایل ]


            if (!path.IsNullOrEmpty())
                workBook.SaveAs(path);

            excelApp.Visible = true;

            #endregion

            #region Release objects

            try
            {
                if (workSheet != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workSheet);
                workSheet = null;

                if (sheets != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);
                sheets = null;

                if (workBook != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                workBook = null;

                if (workBooks != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workBooks);
                workBooks = null;

                if (excelApp != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                excelApp = null;
            }
            catch (Exception ex)
            {
                workSheet = null;
                sheets = null;
                workBook = null;
                workBooks = null;
                excelApp = null;
                ex.LogToTextFile("ToExcel");
            }
            finally
            {
                GC.Collect();
            }

            #endregion
        }
        catch (Exception ex)
        {
            ex.LogToTextFile("ToExcel");
        }
        finally
        {
            GC.Collect();
        }

        #endregion
    }

}