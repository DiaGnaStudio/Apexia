using About.Logic;
using About.View;
using System;
using UScreens;

namespace About
{
    public static class AboutSystem
    {
        private static readonly AboutController logic;
        private static readonly AboutViewController view;

        static AboutSystem()
        {
            logic = AboutController.LoadInstance;
            view = UScreenRepo.Get<AboutViewController>();

            view.SetCards(logic.Assets);
        }

        public static void Initialize(Action customerInfoAction, Action projectAction, Action signOutAction, Action closeAction)
        {
            view.SetCustomerInfoAction(customerInfoAction);
            view.SetProjectAction(projectAction);
            view.SetSignOutAction(signOutAction);
            view.SetCloseAction(closeAction);
        }

        public static void Show() =>
            view.Show();

        public static void Hide() =>
            view.Hide();

    }
}