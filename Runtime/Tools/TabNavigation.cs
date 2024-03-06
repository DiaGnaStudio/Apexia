using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tools
{
    internal class TabNavigation : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Selectable next = EventSystem.current.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

                if (next != null)
                {
                    InputField inputField = next.GetComponent<InputField>();
                    if (inputField != null)
                    {
                        inputField.OnPointerClick(new PointerEventData(EventSystem.current));
                    }

                    next.Select();
                }
            }
        }
    }
}
