using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public Image LoadingProgress;

    void Start()
    {
        StartCoroutine("LoadAsync");
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation LoadingOperation = SceneManager.LoadSceneAsync("MainGamplay");
        LoadingOperation.allowSceneActivation = false;

        while (!LoadingOperation.isDone)
        {
            LoadingProgress.fillAmount = LoadingOperation.progress * 100;

            if (LoadingOperation.progress >= .9f && !LoadingOperation.allowSceneActivation)
            {
                yield return new WaitForSeconds(2f);
                LoadingOperation.allowSceneActivation = true;
            }
            yield return null;
        }

    }


}
