
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DistanceButton : MonoBehaviour
{
    private Button button;

    [Header("Sprites")]
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

    private bool isActive;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetData(Action<DistanceButton> action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnClick);

        void OnClick()
        {
            if (isActive) return;
            action.Invoke(this);
        }
    }

    internal void Active(bool value)
    {
        isActive = value;
        button.image.sprite = value ? on : off;
    }
}
