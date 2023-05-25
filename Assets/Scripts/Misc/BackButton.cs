using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public GameObject preScreen;
    public GameObject nowScreen;

    public void BackToHomeScene()
    {
        SceneManager.LoadSceneAsync("HomeScene");
        // SceneManager.UnloadSceneAsync("AnimationMakingScene");
    }

    public void BackToPre()
    {
        preScreen.SetActive(true);
        nowScreen.SetActive(false);
    }
}
