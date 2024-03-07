using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
namespace ProfileMenu.Core.Modules
{
    public static class SpriteDownloader
    {
        private static readonly DownloaderBehaviour Downloader;

        static SpriteDownloader() =>
            Downloader = new GameObject("DownloaderBehaviour").AddComponent<DownloaderBehaviour>();

        public static void DownloadSprite(string url, Action<Sprite> onComplete, Action onStar = null, Action<(int statusCode, string error, string message)> onFail = null)
        {
            onStar?.Invoke();
            Downloader.StartCoroutine(Download());

            IEnumerator Download()
            {
                if (string.IsNullOrEmpty(url))
                {
                    Debug.LogWarning("Sprite URL is empty.");
                    yield break;
                }

                using UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError($"Failed to download image from {url}: {www.error}");
                    onFail?.Invoke(((int)www.responseCode, www.error, string.Empty));
                }
                else
                {
                    Texture2D texture = DownloadHandlerTexture.GetContent(www);
                    if (texture != null)
                    {
                        // Adjust texture format for better quality
                        Texture2D adjustedTexture = new(texture.width, texture.height, TextureFormat.RGBA32, false);
                        adjustedTexture.SetPixels(texture.GetPixels());
                        adjustedTexture.Apply();

                        // Increase resolution if available
                        // For example, if the source provides a higher resolution image
                        // texture = SomeMethodToIncreaseResolution(texture);

                        Sprite sprite = Sprite.Create(adjustedTexture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                        onComplete?.Invoke(sprite);
                    }
                    else
                    {
                        Debug.LogError($"Failed to create sprite from texture downloaded from {url}");
                        onFail?.Invoke(((int)www.responseCode, www.error, string.Empty));
                    }
                }
            }
        }

        internal class DownloaderBehaviour : MonoBehaviour
        {

        }
    }
}