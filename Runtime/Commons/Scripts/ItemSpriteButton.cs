using UnityEngine;

public class ItemSpriteButton: ItemButton
{
    [SerializeField] private Sprite on;
    [SerializeField] private Sprite off;

    public override void Active()
    {
        Btn.image.sprite = on;
        IsActive = true;
    }

    public override void Disable()
    {
        Btn.image.sprite = off;
        IsActive = false;
    }
}
