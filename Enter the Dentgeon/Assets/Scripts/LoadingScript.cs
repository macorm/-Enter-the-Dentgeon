using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    float timer = 0;
    public Image progressBar;
    void Awake()
    {
        StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync("DemoGame2.0");
        gameLevel.allowSceneActivation = true;

        while (timer <= 5)
        {
            timer = timer + Time.deltaTime;
            progressBar.fillAmount = timer / 5.0f;
            yield return new WaitForEndOfFrame();
        }
        gameLevel.allowSceneActivation = true;
    }
}
