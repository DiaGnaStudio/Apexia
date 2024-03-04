using System;

namespace Unit.Logic.Module
{
    internal class BookmarkHandler
    {
        private const int DEFAULT_CLIENT_ID = -1;

        private readonly BookmarkLoader loaderAPI;
        private readonly BookmarkStorage storage = new();

        private readonly Func<int> GetClientId = () => DEFAULT_CLIENT_ID;

        public BookmarkHandler(Func<int> getClientId)
        {
            GetClientId = getClientId;

            loaderAPI = new(storage.Add);
        }

        public void SetBookmark(int unitId, bool isBookmark)
        {
            loaderAPI.SetBookmark(unitId, GetClientId(), isBookmark);
            storage.Add(unitId, isBookmark);
        }

        public bool IsEnable() =>
            GetClientId() != DEFAULT_CLIENT_ID;

        public bool IsBookmarked(int unitId) =>
            storage.Get(unitId);
    }
}