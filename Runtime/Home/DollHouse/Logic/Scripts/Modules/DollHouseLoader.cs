using System;
using Unit.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DollHouse.Logic
{
    internal class DollHouseLoader
    {
        private const string SCENE_NAME = "DollHouseScene";
        private string previousSceneName;

        private UnitCard currentCard;

        private readonly Action<UnitCard> onCompleteLoad;

        public DollHouseLoader(Action<UnitCard> onCompleteLoad)
        {
            this.onCompleteLoad = onCompleteLoad;

            SceneManager.sceneLoaded += ChangeScene;
        }


        private void ChangeScene(Scene scene, LoadSceneMode mode)
        {
            if (!string.Equals(scene.name, SCENE_NAME)) return;

            onCompleteLoad.Invoke(currentCard);
        }

        public void Load(UnitCard card)
        {
            currentCard = card;
            previousSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SCENE_NAME);
        }

        public void UnLoad() => 
            SceneManager.LoadScene(previousSceneName);
    }
}