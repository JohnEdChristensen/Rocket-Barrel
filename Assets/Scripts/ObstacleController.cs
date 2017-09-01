using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public GameObject character;

    public float max = 2;
    public float min = -2;
    public float rotateSpeed = 1;

    public float asteroidSpeed;
    float asteroidStartTime;

    Vector3 axis;

    bool notHit = true;
	void Start () {
        int currentLevel = character.GetComponent<DifficultyManager>().currentLevel;
        DifficultyManager.Levels currentLevelVars = character.GetComponent<DifficultyManager>().levels[currentLevel];

        asteroidSpeed = Random.Range(currentLevelVars.asteroidSpeedMin, currentLevelVars.asteroidSpeedMax);
        asteroidStartTime = Random.Range(0, max - min);
        
    }
	
	void Update () {
        if (notHit)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * asteroidSpeed + asteroidStartTime, max - min) + min, transform.position.y, transform.position.z);
            transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            notHit = false;
        }
    }
}
