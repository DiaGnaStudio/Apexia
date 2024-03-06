using ProjectInfo.View;
using System;
using UScreens;

namespace ProjectInfo
{
    public static class ProjectInfoSystem
    {
        private static readonly ProjectInfoViewController view;

        static ProjectInfoSystem()
        {
            view = UScreenRepo.Get<ProjectInfoViewController>();
        }

        public static void SetPresenter(Func<string> presenterName) =>
            view.SetPresenterName(presenterName);

        public static void SetCustomer(Func<string> customerName) =>
            view.SetCustomerName(customerName);

        public static void ChangeCustomerName(string name) =>
            view.ChangeCustomerName(name);

        public static void Show() =>
            view.Show();

        public static void Hide() =>
            view.Hide();
    }
}