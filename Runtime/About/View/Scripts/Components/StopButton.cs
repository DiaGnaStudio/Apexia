using System;
using UnityEngine;
using UnityEngine.UI;

namespace About.View.Components
{
    [RequireComponent(typeof(Button))]
    internal class StopButton : MonoBehaviour
    {
        [Header("Sprite")]
        [SerializeField] private Image icon;
        [SerializeField] private Sprite stopSprite;
        [SerializeField] private Sprite resumeSprite;

        private bool isStop = false;
        private Action OnStop;
        private Action OnResume;

        private void Awake()
        {
            var button = GetComponent<Button>();
            button.onClick.AddListener(SwitchAction);

            void SwitchAction()
            {
                if (isStop)
                    Resume();
                else
                    Stop();
            }
        }

        public void SetAction(Action stopAction, Action resumeAction)
        {
            OnStop = stopAction;
            OnResume = resumeAction;
        }

        public void Stop()
        {
            isStop = true;
            icon.sprite = stopSprite;
            OnStop.Invoke();
        }

        public void Resume()
        {
            isStop = false;
            icon.sprite = resumeSprite;
            OnResume.Invoke();
        }
    }
}