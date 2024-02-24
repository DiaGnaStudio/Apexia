using System.Collections.Generic;

namespace Unit.Logic.Module
{
    internal class Storage<T, K>
    {
        private readonly Dictionary<T, K> catched = new();

        public void Add((T id, K data) info)
        {
            if (catched.ContainsKey(info.id))
                catched[info.id] = info.data;
            else
                catched.Add(info.id, info.data);
        }

        public void Add((T id, K data)[] infos)
        {
            foreach (var info in infos)
                Add(info);
        }

        public K Get(T id)
        {
            if (TryGet(id, out K data))
                return data;

            throw new System.NullReferenceException();
        }

        public bool TryGet(T id, out K data)
        {
            if (catched.TryGetValue(id, out data))
                return true;

            return false;
        }
    }
}