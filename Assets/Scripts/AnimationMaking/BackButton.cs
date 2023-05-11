using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    

    public void BackToHomeScene()
    {
        SceneManager.LoadSceneAsync("HomeScene");
        // SceneManager.UnloadSceneAsync("AnimationMakingScene");
    }
}
