using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{

    SceneController sceneController;
    [SerializeField] float timeToLoadNextScene = 5f;

    private void Awake()
    {
        sceneController = GameObject.FindObjectOfType<SceneController>();
    }
    
    void Start()
    {
        Invoke(nameof(GoToNextScene), timeToLoadNextScene);
    }

    private void GoToNextScene()
    {
        sceneController.LoadMainMenu();
    }
}
