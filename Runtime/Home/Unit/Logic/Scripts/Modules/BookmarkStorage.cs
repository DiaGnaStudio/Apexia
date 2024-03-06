using System.Collections.Generic;

namespace Unit.Logic.Module
{
    internal class BookmarkStorage
    {
        private readonly List<int> catched = new();

        public void Add(int unitId)
        {
            if (catched.Contains(unitId)) return;
            catched.Add(unitId);
        }

        public void Remove(int unitId)
        {
            if (!catched.Contains(unitId)) return;
            catched.Remove(unitId);
        }

        public bool IsBookmarked(int unitId) =>
            catched.Contains(unitId);
    }
}