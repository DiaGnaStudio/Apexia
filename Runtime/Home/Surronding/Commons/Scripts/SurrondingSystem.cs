using Surronding.Logic;
using Surronding.View;
using UnityEngine;
using UScreens;

namespace Surronding
{
    public class SurrondingSystem
    {
        private static readonly SurrondingController logic;
        private static readonly SurrondingViewController view;

        static SurrondingSystem()
        {
            logic = SurrondingController.LoadInstance;
            view = UScreenRepo.Get<SurrondingViewController>();

            logic.Initialize();

            view.InitializeFilter(logic.FilterController.Update);
            view.InitializeOptions(logic.GetItemsName(), logic.Select);
        }

        public static void Show(Transform parent = null)
        {
            if (parent != null)
                view.ChangeParent(parent);
            view.Show();
        }

        public static void Hide() =>
            view.Hide();
    }
}