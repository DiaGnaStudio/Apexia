using System;
using Unit.Data;

namespace Unit.Logic.Module
{
    internal class BookmarkHandler
    {
        private const int DEFAULT_CLIENT_ID = -1;

        private readonly Func<int> GetClientId = () => DEFAULT_CLIENT_ID;

        public BookmarkHandler(Func<int> getClientId)
        {
            GetClientId = getClientId;
        }

        public bool IsEnable() =>
            GetClientId() != DEFAULT_CLIENT_ID;
    }
}