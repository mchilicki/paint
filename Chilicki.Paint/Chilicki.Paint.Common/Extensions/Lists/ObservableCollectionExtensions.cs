using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Chilicki.Paint.Common.Extensions.Lists
{
    public static class ObservableCollectionExtensions
    {
        public static List<T> ToList<T>(this ObservableCollection<T> observableCollection)
        {
            IEnumerable<T> collection = observableCollection;
            return new List<T>(collection);
        }
    }
}
