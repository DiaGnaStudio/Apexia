using Explore.Logic;
using UnityEngine;

namespace Explore
{
    public static class ExploreSystem
    {
        private static readonly ExploreController logic;

        static ExploreSystem()
        {
            logic = ExploreController.LoadInstance;
            logic.Initialize();
        }

        public static void Show(Transform parent = null)
        {
            logic.SetPoints();
        }
    }
}