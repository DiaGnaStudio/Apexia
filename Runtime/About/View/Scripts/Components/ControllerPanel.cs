using System;
using UnityEngine;
using UnityEngine.UI;

namespace About.View.Components
{
    internal class ControllerPanel : MonoBehaviour
    {
        [SerializeField] private Button nextBtn;
        [SerializeField] private Button prevBtn;
        [SerializeField] private StopButton stopBtn;

        public void SetButton(Action nextAction, Action prevAction)
        {
            nextBtn.onClick.AddListener(() => OnClick(nextAction));
            prevBtn.onClick.AddListener(() => OnClick(prevAction));

            void OnClick(Action action)
            {
                action.Invoke();
                stopBtn.Stop();
            }
        }

        public void SetStopAction(Action stopAction, Action resumeAction) =>
            stopBtn.SetAction(stopAction, resumeAction);
    }
}