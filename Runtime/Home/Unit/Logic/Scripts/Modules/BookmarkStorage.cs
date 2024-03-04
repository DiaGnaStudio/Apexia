using System.Collections.Generic;

namespace Unit.Logic.Module
{
    internal class BookmarkStorage
    {
        private readonly Dictionary<int, bool> catched = new();

        public void Add(int unitId, bool value)
        {
            if (catched.ContainsKey(unitId))
                catched[unitId] = value;
            else
                catched.Add(unitId, value);
        }

        public bool Get(int unitId) =>
            catched.TryGetValue(unitId, out bool result) && result;
    }
}