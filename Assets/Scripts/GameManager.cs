using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public float delay = 2f;
    public GameObject character;
    public GameObject earth;
    

    public void endGame()
    {

        character.transform.position = new Vector3(0, -30f, -65f);
        character.GetComponentInChildren<Renderer>().enabled = false;
        earth.GetComponent<Rotate>().allowRotate = false;
        Invoke("restart", delay);
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
