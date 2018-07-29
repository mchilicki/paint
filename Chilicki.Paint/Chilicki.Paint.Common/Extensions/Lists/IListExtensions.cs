using System.Collections.Generic;
using System;

namespace Chilicki.Paint.Common.Extensions.Lists
{
    public static class IListExtensions
    {
        private static readonly string ArgumentNull = "IListExtensions: IList is null";

        public static T First<T>(this IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(ArgumentNull);
            return list[0];
        }

        public static T Last<T>(this IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(ArgumentNull);
            return list[list.Count - 1];
        }
    }
}
