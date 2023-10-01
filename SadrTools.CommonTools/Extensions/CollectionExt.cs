using System.Collections.Generic;
using System.Text;

namespace SadrTools.Extensions
{
    public static class CollectionExt
    {
        public static string ListToStr(this List<string> items)
        {
            if (items == null || items.Count == 0)
                return string.Empty;

            var res = "";
            foreach (var item in items)
            {
                res += item + ",";
            }

            return res.RemoveLastCharacter();
        }

        public static string ByteArrayToStr(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return string.Empty;

            string str = Encoding.UTF8.GetString(bytes);

            return str;
        }

        public static object[] ToObjectArray(this List<string> list)
        {
            var result = new object[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                result[i] = list[i];
            }

            return result;

        }


    }
}