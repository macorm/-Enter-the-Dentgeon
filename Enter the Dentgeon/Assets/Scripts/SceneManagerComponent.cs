using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class SceneManagerComponent : MonoBehaviour
{
    public void Game() => SceneManager.LoadScene("LoadingScreen");
    public void MainMenue() => SceneManager.LoadScene("GabMenu");
    public void Retry() => SceneManager.LoadScene("LoadingScreen");
    public void Quitter() => Application.Quit();

}