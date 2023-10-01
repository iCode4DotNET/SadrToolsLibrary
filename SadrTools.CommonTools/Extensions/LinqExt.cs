using System.Linq;
using System.Text;

namespace SadrTools.Extensions
{
    public static class LinqExt
    {

        public static string ToCSVString<T>(this IQueryable<T> data)
        {
            return ToCSVString(data, "; ");
        }


        public static string ToCSVString<T>(this IQueryable<T> data, string delimiter)
        {
            return ToCSVString(data, "; ", null);
        }


        public static string ToCSVString<T>(this IQueryable<T> data, string delimiter, string nullvalue)
        {
            StringBuilder sb = new StringBuilder();
            string replaceFrom = delimiter.Trim();
            string replaceDelimiter = ";";
            System.Reflection.PropertyInfo[] headers = data.ElementType.GetProperties();
            switch (replaceFrom)
            {
                case ";":
                    replaceDelimiter = ":";
                    break;
                case ",":
                    replaceDelimiter = "¸";
                    break;
                case "\t":
                    replaceDelimiter = "    ";
                    break;
                default:
                    break;
            }
            if (headers.Length > 0)
            {
                foreach (var head in headers)
                {
                    sb.Append(head.Name.Replace("_", " ") + delimiter);
                }
                sb.Append("\n");
            }
            foreach (var row in data)
            {
                var fields = row.GetType().GetProperties();
                for (int i = 0; i < fields.Length; i++)
                {
                    object value = null;
                    try
                    {
                        value = fields[i].GetValue(row, null);
                    }
                    catch { }
                    if (value != null)
                    {
                        sb.Append(value.ToString().Replace("\r", "\f").Replace("\n", " \f").Replace("_", " ").Replace(replaceFrom, replaceDelimiter) + delimiter);
                    }
                    else
                    {
                        sb.Append(nullvalue);
                        sb.Append(delimiter);
                    }
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}