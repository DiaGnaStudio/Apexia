using About;
using CustomerInfo;
using Exit;
using Login;
using ProfileMenu;
using ProjectInfo;
using SidePanel;
using UnityEngine;

public class ApplicationInitializer : MonoBehaviour
{
    private void Awake()
    {
        LoginSystem.Initialize(SetInfo, Initialize, SignOut);

        void SignOut()
        {
            LoginSystem.Show();
            AboutSystem.Hide();
            SidePanelSystem.Hide();
        }

        void SetInfo(string presenterName)
        {
            
            ProfileMenuSystem.SetData(null, presenterName);
        }
    }

    private void Start()
    {
        LoginSystem.Show();
    }

    private void Initialize()
    {
        ProjectInfoSystem.SetPresenter(LoginSystem.GetPresenter);
        AboutSystem.Initialize(CustomerInfoSystem.Show, ShowMenus, LoginSystem.SignOut, ExitSystem.Show);
        SidePanelSystem.Initialize(ChangeDayNight, ExitSystem.Show, ShowHome);
        ProfileMenuSystem.Initialize(null, null, LoginSystem.SignOut);

        void ChangeDayNight(float value)
        {
            //DayNightCycle.Instance.timeOfDay = value;
        }

        void ShowMenus()
        {
            ProjectInfoSystem.Show();
            SidePanelSystem.Show();
            AboutSystem.Hide();
        }

        void ShowHome()
        {
            ProjectInfoSystem.Hide();
            SidePanelSystem.Hide();
            AboutSystem.Show();
        }

        AboutSystem.Show();
    }
}
