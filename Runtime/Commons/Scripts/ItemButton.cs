using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour
{
    public bool IsActive { protected set; get; }

    public Button Btn { private set; get; }
    private TextMeshProUGUI txt;

    private void Awake() =>
        Initialize();

    public void Initialize()
    {
        if (Btn) return;
        Btn = GetComponent<Button>();
        txt = GetComponentInChildren<TextMeshProUGUI>();

        if (IsActive)
            Active();
        else
            Disable();
    }

    public virtual void Disable()
    {
        Btn.image.color = HalfAlpha(Btn.image.color);
        if (txt) txt.color = HalfAlpha(txt.color);
        Color HalfAlpha(Color c)
        {
            c.a = .5f;
            return c;
        }

        IsActive = false;
    }

    public virtual void Active()
    {
        Btn.image.color = FullAlpha(Btn.image.color);
        if (txt) txt.color = FullAlpha(txt.color);

        Color FullAlpha(Color c)
        {
            c.a = 1;
            return c;
        }

        IsActive = true;
    }

    public void ChangeState() =>
        ChangeState(!IsActive);

    public void ChangeState(bool value)
    {
        if (IsActive == value)
            return;

        if (value)
            Active();
        else
            Disable();
    }
}
