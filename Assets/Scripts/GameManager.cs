using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public string sceneName;
    public float delay = 0.125f;
    public float adDelay = 1f;
    public GameObject character;
    public GameObject earth;
    public GameObject scoreScreen;

    private void Start()
    {
        scoreScreen.SetActive(false);
    }
    public void onLoseTrigger()
    {
        Destroy(character);
        earth.GetComponent<EarthController>().desiredPosition = earth.GetComponent<EarthController>().farPosition;
        scoreScreen.GetComponent<Animator>().Play("Fade_In");
        scoreScreen.SetActive(true);
        Invoke("showAd", adDelay);

    }
    public void resetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    public void StartGame() {
        earth.GetComponent<EarthController>().desiredPosition = earth.GetComponent<EarthController>().startPos;
        earth.GetComponent<EarthController>().allowRotate = false;
        scoreScreen.GetComponent<Animator>().Play("Fade_out");
        Invoke("LoadGame", delay);
    }
    void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadMenu()
    {
        earth.GetComponent<EarthController>().allowRotate = false;
        scoreScreen.GetComponent<Animator>().Play("Fade_out");
        Invoke("LoadMenuScene", delay);
    }
    void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void showAd()
    {
        gameObject.GetComponent<AdManager>().ShowRewardedAd();
    }
    
}
