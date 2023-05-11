using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public string targetSceneName;
    public string currentSceneName;

    private void Start() 
    {
        currentSceneName="HomeScene";
        targetSceneName=gameObject.name;
        // Debug.Log(gameObject.name);
    }


    public void SwichToTargetScene()
    {
        SceneManager.LoadSceneAsync(targetSceneName);
        // SceneManager.UnloadSceneAsync(currentSceneName);
    }
}
