using System.Collections.Generic;
using UnityEngine;
using UPatterns;

public class ObjectRelativeActivator : Singleton<ObjectRelativeActivator>
{
    [SerializeField] private List<GameObject> ExploreObjects;
    [SerializeField] private List<GameObject> AmenetiesObjects;
    [SerializeField] private List<GameObject> SurrondingObjects;
    [SerializeField] private List<GameObject> UnitObjects;

    private TabType lastType = TabType.None;

    public enum TabType
    {
        None,
        Explore,
        Ameneties,
        Surronding,
        Unit
    }

    protected override void Awake()
    {
        base.Awake();

        SetActive(ExploreObjects, false);
        SetActive(AmenetiesObjects, false);
        SetActive(SurrondingObjects, false);
        SetActive(UnitObjects, false);
    }

    public static void Change(TabType type)
    {
        Instance.SetActivate(type);
    }

    public void SetActivate(TabType type)
    {
        if (type == lastType) return;

        if (lastType != TabType.None)
            SetActive(Get(lastType), false);

        lastType = type;

        SetActive(Get(lastType), true);



        List<GameObject> Get(TabType type)
        {
            switch (type)
            {
                case TabType.Explore:
                    return ExploreObjects;
                case TabType.Ameneties:
                    return AmenetiesObjects;
                case TabType.Surronding:
                    return SurrondingObjects;
                case TabType.Unit:
                    return UnitObjects;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }

    void SetActive(List<GameObject> objetcs, bool value)
    {
        foreach (var obj in objetcs)
        {
            obj.SetActive(value);
        }
    }
}
