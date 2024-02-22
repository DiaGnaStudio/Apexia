using System;
using TMPro;
using UWarning.Data;
using UWarning.View.Conponents;
using UnityEngine;
using UScreens;

namespace UWarning.View
{
    internal class Panel : UPanel
    {
        [SerializeField] private TMP_Text titleText;
        [SerializeField] private ButtonHandler buttonHandler;
        [SerializeField] private InfoHolder infoHolder;

        private void Awake() => 
            buttonHandler?.SetHideAction(Hide);

        public void SetData(WarningCard card, Action acceptAction, Action rejectAction, string description = null)
        {
            infoHolder.SetIcon(card.Icon);
            titleText.SetText(card.Title);
            infoHolder.SetDescription(string.IsNullOrEmpty(description) ? card.Description : description);

            buttonHandler?.SetAcceptInfo(card.AccecptButton.isActive, card.AccecptButton.text, acceptAction);
            buttonHandler?.SetRejectInfo(card.RejectButton.isActive, card.RejectButton.text, rejectAction);
        }
    }
}
