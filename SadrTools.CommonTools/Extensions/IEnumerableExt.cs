using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;

namespace SadrTools.Extensions
{
    public static class IEnumerableExt
    {
        public static string PrintList<T>(this IEnumerable<T> list, bool isVertical = false)
        {
            string str = "";
            string seprator = isVertical ? "\n" : ",";

            foreach (T item in list)
                str += item + seprator;

            return str.RemoveLastChar();
        }

        public static ArrayList ToArrayList<T>(this IEnumerable<T> list)
        {
            var arrayList = new ArrayList();
            foreach (var item in list)
            {
                arrayList.Add(item);
            }

            return arrayList;
        }

        public static List<string> ToStringList<T>(this IEnumerable<T> list)
        {
            var stringList = new List<string>();
            foreach (var item in list)
            {
                stringList.Add(item.ToString());
            }

            return stringList;
        }

        public static void ForEachAction<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
                action(item);
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var i in list)
                action(i);
            return list;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable list, Action<T> action)
        {
            return list.Cast<T>().ForEach<T>(action);
        }

        public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
        {
            var list = new List<RT>();
            foreach (var i in array)
            {
                var obj = func(i);
                if (obj != null)
                    list.Add(obj);
            }
            return list;
        }

        public static string Join<T>(this IEnumerable<T> list, string separator)
        {
            return String.Join(separator, list.Select(e => e.ToString()).ToArray());
        }

        public static bool AreAllSame<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));

            using (var enumerator = enumerable.GetEnumerator())
            {
                var toCompare = default(T);
                if (enumerator.MoveNext())
                {
                    toCompare = enumerator.Current;
                }

                while (enumerator.MoveNext())
                {
                    if (toCompare != null && !toCompare.Equals(enumerator.Current))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsReadOnly<T>(this IEnumerable<T> list)
        {
            return (list as ICollection<T>).IsReadOnly;
        }

        /// <summary>
        /// آرایه ای از بایت به رشته
        /// </summary>
        public static string BitToString(this byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var shuffledList = list.Select(x => new
            {
                Number = SadrTools.Utility.NumericMethods.ReturnRandomNumber(),
                Item = x
            }).OrderBy(x => x.Number).Select(x => x.Item);
            return shuffledList.ToList();
        }

        /// <summary>
        /// مرتب سازی
        /// </summary>
        private static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> list,
                                                                               Func<TSource, TKey> keySelector,
                                                                               bool isDescending)
        {
            if (list == null)
                return null;

            if (isDescending)
                return list.OrderByDescending(keySelector);

            return list.OrderBy(keySelector);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> list,
                                                                        Func<TSource, IComparable> keySelector1,
                                                                        Func<TSource, IComparable> keySelector2,
                                                                        params Func<TSource, IComparable>[] keySelectors)
        {
            if (list == null)
                return null;

            IEnumerable<TSource> current = list;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i]);
                }
            }

            current = current.OrderBy(keySelector2);

            return current.OrderBy(keySelector1);
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource>(this IEnumerable<TSource> list,
                                                                        bool isDescending,
                                                                        Func<TSource, IComparable> keySelector,
                                                                        params Func<TSource, IComparable>[] keySelectors)
        {
            if (list == null)
                return null;

            IEnumerable<TSource> current = list;

            if (keySelectors != null)
            {
                for (int i = keySelectors.Length - 1; i >= 0; i--)
                {
                    current = current.OrderBy(keySelectors[i], isDescending);
                }
            }

            return current.OrderBy(keySelector, isDescending);
        }


        public static Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>> Pivot<TSource, TFirstKey, TSecondKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TFirstKey> firstKeySelector, Func<TSource, TSecondKey> secondKeySelector, Func<IEnumerable<TSource>, TValue> aggregate)
        {
            var retVal = new Dictionary<TFirstKey, Dictionary<TSecondKey, TValue>>();

            var l = source.ToLookup(firstKeySelector);
            foreach (var item in l)
            {
                var dict = new Dictionary<TSecondKey, TValue>();
                retVal.Add(item.Key, dict);
                var subdict = item.ToLookup(secondKeySelector);
                foreach (var subitem in subdict)
                {
                    dict.Add(subitem.Key, aggregate(subitem));
                }
            }

            return retVal;
        }

        /// <summary>
        /// ساختن عکس از روی فایل باینری آن
        /// </summary>
        /// <param name="binaryFile">فایل باینری</param>
        /// <returns></returns>
        public static Image ToImage(this byte[] binaryFile)
        {
            using var ms = new MemoryStream(binaryFile);
            return Image.FromStream(ms);
        }

    }

}