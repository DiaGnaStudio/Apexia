using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// modules about switching button panels.
public class SwitchButtonsPanel : MonoBehaviour
{
    public enum Type {Normal, Multiple, Order}

    public UnityEvent<int> OnChanged;
    public UnityEvent<int[]> OnChangedMultiple;
    [SerializeField] int[] indexStarter;
    [SerializeField] Type type;
    [SerializeField] ItemButton[] btns;
    public int CurrentIndex { private set; get; } = -1;

    public int[] SelectedIndex
    {
        get
        {
            List<int> items = new List<int>();

            for (int i = 0; i < btns.Length; i++)
                if (btns[i].IsActive)
                    items.Add(i);

            return items.ToArray();
        }
    }

    private void Start()
    {
        Initialize();

        switch(type)
        {
            case Type.Normal:
                if(indexStarter.Length > 0)
                    Select(indexStarter[0],true);
            break;
            case Type.Multiple:
                for(int i=0;i<indexStarter.Length;i++)
                    SelectMultiple(indexStarter[i]);
            break;
            case Type.Order:
                SelectByOrder(indexStarter[0]);
            break;
        }
    }

    private void Initialize() {

        for (int i = 0; i < btns.Length; i++)
        {
            int index = i;

            switch(type) {
                case Type.Normal:
                    btns[index].Btn.onClick.AddListener(() => Select(index));
                    break;
                    case Type.Multiple:
                    btns[index].Btn.onClick.AddListener(() => SelectMultiple(index));
                    break;
                    case Type.Order:
                    btns[index].Btn.onClick.AddListener(() => SelectByOrder(index));
                    break;
            }

            btns[index].Disable();
        }
    }

    private void Select(int index, bool force = false) 
    {
        if (!force && btns[CurrentIndex] == btns[index])
            return;

        if(CurrentIndex > -1 && CurrentIndex < btns.Length)
            btns[CurrentIndex]?.Disable();
            
        CurrentIndex = index;

        if(CurrentIndex > -1 && CurrentIndex < btns.Length)
            btns[CurrentIndex]?.Active();

        OnChanged?.Invoke(index);
    }

    private void SelectMultiple(int index) 
    {
        btns[index].ChangeState();
        OnChangedMultiple?.Invoke(SelectedIndex);
    }

    private void ChangeState(int index, bool value) =>
        btns[index].ChangeState(value);

    private void SelectByOrder(int index)
    {
        for (int i = 0; i < btns.Length; i++)
            ChangeState(i, i <= index);

        OnChangedMultiple?.Invoke(SelectedIndex);
    }

    public void SelectByOrderMax()
    {
        for (int i = 0; i < btns.Length; i++)
                    ChangeState(i, true);

        OnChangedMultiple?.Invoke(SelectedIndex);
    }
}