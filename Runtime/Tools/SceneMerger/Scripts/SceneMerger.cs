using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMerger : MonoBehaviour
{
    [SerializeField] private int[] sceneIndex;
    [SerializeField] private bool autoMerge = true;

    private void Start()
    {
        if (!autoMerge) return;
        LoadScenes(sceneIndex);
    }

    public void LoadScenes(int[] indexes) =>
        StartCoroutine(LoadScenesAsync(indexes));

    private IEnumerator LoadScenesAsync(int[] indexes)
    {
        foreach (var index in indexes)
        {
            if (SceneManager.GetActiveScene().buildIndex == index) continue;
            var loader = SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
            yield return loader;
        }
    }
}
