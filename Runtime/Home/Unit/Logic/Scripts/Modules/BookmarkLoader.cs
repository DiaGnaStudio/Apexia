using Bookmark.Provider;
using System;
using UnityEngine;

namespace Unit.Logic.Module
{
    internal class BookmarkLoader
    {
        private readonly Action<int, bool> OnBookmark;

        public BookmarkLoader(Action<int, bool> onBookmark)
        {
            OnBookmark = onBookmark;
        }

        public void SetBookmark(int unitId, int clientId, bool value)
        {
            BookmarkService.Bookmark(unitId, clientId, Get, Error);

            void Get() => 
                OnBookmark.Invoke(unitId, value);

            void Error(string message) =>
                Debug.LogError(message);
        }
    }
}