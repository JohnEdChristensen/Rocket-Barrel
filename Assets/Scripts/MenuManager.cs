using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public float delay = 0.125f;
    public GameObject earth;
    public GameObject MenuCanvas;
    public string gameSceneName;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
    }
    public void StartClick()
    {
       earth.GetComponent<EarthController>().desiredPosition = earth.GetComponent<EarthController>().startPos;
       earth.GetComponent<EarthController>().allowRotate = false;
       MenuCanvas.GetComponent<Animator>().Play("StartMenuFade");
       Invoke("LoadGame", delay);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

}
