using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public GameObject character;

    public float max;
    public float min;

    float asteroidSpeed;
    float asteroidStartTime;

    bool notHit = true;
	void Start () {
        int currentLevel = character.GetComponent<LevelUp>().currentLevel;
        LevelUp.Levels currentLevelVars = character.GetComponent<LevelUp>().levels[currentLevel];

        asteroidSpeed = Random.Range(currentLevelVars.asteroidSpeedMin, currentLevelVars.asteroidSpeedMax);
        asteroidStartTime = Random.Range(0, max - min);
    }
	
	void Update () {
        if (notHit)
        {
            transform.position = new Vector3(Mathf.PingPong(Time.time * asteroidSpeed + asteroidStartTime, max - min) + min, transform.position.y, transform.position.z);

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
