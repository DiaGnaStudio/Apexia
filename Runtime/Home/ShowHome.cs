using About;
using ProjectInfo;
using SidePanel;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShowHome : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(Do);
    }

    private void Do()
    {
        ProjectInfoSystem.Hide();
        SidePanelSystem.Hide();
        AboutSystem.Show();
    }
}
