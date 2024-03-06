using Bookmard.Core;
using Bookmard.Data;
using System.Collections.Generic;

namespace Bookmard
{
    public static class BookmarkSystem
    {
        private static readonly BookmarkController logic = new();

        public static void AddBookmark(BookmarkedUnit unit) =>
            logic.AddBookmark(unit);

        public static void RemoveBookmark(int unitId) =>
            logic.RemoveBookmark(unitId);

        public static void RemoveAll() =>
            logic.RemoveAll();

        public static BookmarkedUnit[] GetAll() =>
            logic.GetAll();

        public static BookmarkedUnit GetBookmark(int unitId) =>
            logic.Get(unitId);

        public static bool HasBookmark(int unitId) =>
            logic.TryGet(unitId, out _);
    }
}
namespace Bookmard.Core
{
    public class BookmarkController
    {
        private readonly Storage storage = new();

        public void AddBookmark(BookmarkedUnit unit) =>
            storage.Add(unit);

        public void RemoveBookmark(int unitId) =>
            storage.Remove(unitId);

        public void RemoveAll() =>
            storage.CLear();

        public BookmarkedUnit[] GetAll() =>
            storage.GetAll();

        public BookmarkedUnit Get(int unitId) =>
            storage.Get(unitId);

        public bool TryGet(int unitId, out BookmarkedUnit data) =>
            storage.TryGet(unitId,out data);
    }

    public class Storage
    {
        private readonly List<BookmarkedUnit> catched = new();

        public void Add(BookmarkedUnit info)
        {
            if (!catched.Contains(info))
                catched.Add(info);
        }

        public void Remove(int id)
        {
            if (TryGet(id, out BookmarkedUnit data))
                catched.Remove(data);
        }

        public void CLear() =>
            catched.Clear();

        public BookmarkedUnit Get(int id)
        {
            if (TryGet(id, out BookmarkedUnit data))
                return data;

            throw new System.NullReferenceException();
        }

        public bool TryGet(int id, out BookmarkedUnit data)
        {
            foreach (var item in catched)
            {
                if (item.Id == id)
                {
                    data = item;
                    return true;
                }
            }

            data = default;
            return false;
        }

        public BookmarkedUnit[] GetAll() =>
            catched.ToArray();
    }
}
namespace Bookmard.Data
{
    public struct BookmarkedUnit
    {
        public BookmarkedUnit(int id, string name, string type, int floor, string price, int area)
        {
            Id = id;
            Name = name;
            Type = type;
            Floor = floor;
            Price = price;
            Area = area;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Floor { get; private set; }
        public string Price { get; private set; }
        public int Area { get; private set; }
    }
}