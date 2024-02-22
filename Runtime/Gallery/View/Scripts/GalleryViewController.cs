using System;
using UnityEngine;
using UScreens;

namespace Gallery.View
{
    public class GalleryViewController : UScreenGeneric<GalleryViewController, GalleryView>
    {
        public override void InitializeState() { }

        public override void InitializeView()
        {
            View.Initialize();
        }

        public void SetSprites(Func<Sprite[]> sprites, Action<Sprite> onSelect,Func<int> getFirstIndex)
        {
            View.ScrollPanel.Initialize(sprites, OnSelect, getFirstIndex);
            View.PreviewPanel.SetImage(sprites()[getFirstIndex()]);

            void OnSelect(Sprite sprite)
            {
                View.PreviewPanel.SetImage(sprite);
                onSelect.Invoke(sprite);
            }
        }

        public void InitializeButtons(Func<Sprite> onNext, Func<Sprite> onPrev, Func<int> indexGetter)
        {
            View.GalleryButton.SetButtons(Next, Prev);

            void Next()
            {
                View.PreviewPanel.SetImage(onNext());
                View.ScrollPanel.SetOn(indexGetter());
            }

            void Prev()
            {
                View.PreviewPanel.SetImage(onPrev());
                View.ScrollPanel.SetOn(indexGetter());
            }
        }
    }
}