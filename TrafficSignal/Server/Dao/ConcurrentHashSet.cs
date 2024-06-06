using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSignal.Server.Dao
{
    public class ConcurrentHashSet<T>
    {
        private readonly ConcurrentDictionary<T, byte> _dict;

        public ConcurrentHashSet()
        {
            _dict = new ConcurrentDictionary<T, byte>();
        }

        public bool Add(T item)
        {
            return _dict.TryAdd(item, 0);
        }

        public bool Remove(T item)
        {
            return _dict.TryRemove(item, out _);
        }

        public bool Contains(T item)
        {
            return _dict.ContainsKey(item);
        }

        public int Count => _dict.Count;

        public void Clear()
        {
            _dict.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _dict.Keys.GetEnumerator();
        }

        // Additional members to implement IEnumerable and other needed interfaces
    }
}