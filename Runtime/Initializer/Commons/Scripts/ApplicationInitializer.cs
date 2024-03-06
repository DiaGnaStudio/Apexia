using About;
using Bookmard;
using Bookmard.Data;
using CustomerInfo;
using CustomerInfo.Data;
using Exit;
using Login;
using ProfileMenu;
using ProjectInfo;
using SidePanel;
using System.Linq;
using Unit;
using Unit.Data;
using UnityEngine;

public class ApplicationInitializer : MonoBehaviour
{
    private void Awake()
    {
        LoginSystem.Initialize(SetInfo, Initialize, SignOut, ExitSystem.Show);

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
        UnitSystem.Initialize(BookmarkUnit, GetClientId, IsBookmarked);

        ProjectInfoSystem.SetPresenter(LoginSystem.GetPresenter);
        ProjectInfoSystem.SetCustomer(GetClientName);
        AboutSystem.Initialize(CustomerInfoSystem.Show, ShowMenus, LoginSystem.SignOut, ExitSystem.Show);
        SidePanelSystem.Initialize(ChangeDayNight, ExitSystem.Show, ShowHome);
        ProfileMenuSystem.Initialize(null, null, LoginSystem.SignOut);
        CustomerInfoSystem.Initialzie(LoginSystem.SignOut, GetOrders, BookmarkSystem.RemoveBookmark, BookmarkSystem.RemoveAll);


        void BookmarkUnit(UnitData data, bool isBookmarked)
        {
            if (isBookmarked)
                BookmarkSystem.AddBookmark(Convert(data));
            else
                BookmarkSystem.RemoveBookmark(data.Id);

            BookmarkedUnit Convert(UnitData data)
            {
                return new(data.Id, data.Name, data.UnitTypeCard.Name, data.Floor, GetPrice(), data.Area);

                string GetPrice()
                {
                    return data.State switch
                    {
                        State.Saleable => data.Price.ToString(),
                        State.Negotiable => "Negotiable",
                        _ => string.Empty,
                    };
                }
            }
        }

        bool IsBookmarked(UnitData data) =>
            BookmarkSystem.HasBookmark(data.Id);

        int GetClientId() =>
            CustomerInfoSystem.GetClientInfo(false).Id;

        string GetClientName() =>
            CustomerInfoSystem.GetClientInfo(false).FullName;

        OrderInfo[] GetOrders() =>
            BookmarkSystem.GetAll().Select(info => new OrderInfo(info.Id, info.Name, info.Type, info.Floor, info.Price, info.Area)).ToArray(); ;


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
