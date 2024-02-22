using CustomInfo.View;
using System;
using UScreens;

namespace CustomInfo
{
    public static class CustomInfoSystem
    {
        private static readonly CustomInfoViewController view;

        static CustomInfoSystem()
        {
            view = UScreenRepo.Get<CustomInfoViewController>();
        }

        public static void Show(string presenterName, string customerName)
        {
            view.SetPresenterName(presenterName);
            view.SetCustomerName(customerName);
            view.Show();
        }
    }
}