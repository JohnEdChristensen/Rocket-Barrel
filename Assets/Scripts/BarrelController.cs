using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour {

    public GameObject explosion;
    public GameObject character;
    public GameObject asteroid;
    GameObject currentAsteroid;

    public float min = -2f;
    public float max = 2f;
    public float rotMin = -30f;
    public float rotMax = 30f;
    public float rotSpeed = 10f;
    public float rotDelay = .5f;
    public float rotSmoothSpeed = .125f;
    public float speed = 2f;
    public float barrelDistance = 7.5f;
    public bool update = true;
    float startTime = 2f;
    //difficulty
    public bool randomPosition = true;
    public bool randomSpeed = true;
    public bool rotatingBarrel = false;
    public bool rotatingSliding = false;
    public bool activeBarrel = false;
    public bool middleObstacle = false;
    //manage
    bool rotate = false;
    GameObject pastExplosion;
 
    private void Start()
    {
        int currentLevel = character.GetComponent<LevelUp>().currentLevel;
        LevelUp.Levels currentLevelVars = character.GetComponent<LevelUp>().levels[currentLevel];

        randomSpeed = currentLevelVars.randomSpeed;
        rotatingBarrel = randomParamater(currentLevelVars.rotatingChance);
        rotatingSliding = randomParamater(currentLevelVars.slidingRotatingChance);
        middleObstacle = randomParamater(currentLevelVars.middleObstacleChance);

        if (randomPosition)
        {
            startTime = Random.Range(0, 8f);
        }
        if (randomSpeed)
        {
            speed = Random.Range(1.5f, 3f);
        }
        if (activeBarrel)
        {
            GetComponent<Animator>().SetTrigger("FlipTrigger");
            gameObject.GetComponent<Collider>().enabled = false;
        }
        if (middleObstacle)
        {
            Vector3 asteroidPosition = new Vector3(Random.Range(min, max), transform.position.y - (barrelDistance / 2), transform.position.z);
            currentAsteroid = Instantiate(asteroid, asteroidPosition, Random.rotation);
        }
        
    }
    void FixedUpdate()
    {
        if (update)
        {
            if (!rotatingBarrel || rotatingSliding || !activeBarrel)
            {
                transform.position = new Vector3(Mathf.PingPong(Time.time * speed + startTime, max - min) + min, transform.position.y, transform.position.z);
            }
            if (rotate)
            {
                Quaternion desiredPosition = Quaternion.Euler(0, 0, Mathf.PingPong(Time.time * rotSpeed, rotMax - rotMin) + rotMin);
                Quaternion smoothedPosition = Quaternion.Lerp(transform.rotation, desiredPosition, rotSmoothSpeed);
                transform.rotation = smoothedPosition;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            activeBarrel = true;
            gameObject.GetComponent<Collider>().enabled = false;
            GetComponent<Animator>().SetTrigger("FlipTrigger");
            if (rotatingBarrel)
            {
                GetComponent<Animator>().SetTrigger("RotateTrigger");
            }
        }
    }
    public void launched()
    {
        activeBarrel = false;
        pastExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(pastExplosion, .5f);
        gameObject.transform.position = new Vector3(Random.Range(min, max), transform.position.y + (barrelDistance*3), 0);

        GetComponent<Animator>().enabled = true;

        gameObject.GetComponent<Collider>().enabled = true;
        
        Instantiate(gameObject,transform.position, Quaternion.Euler(180f, 0, 0));
        if (middleObstacle)
        {
            Destroy(currentAsteroid);
        }
        Destroy(gameObject);
    }
    public void startRotating()
    {
        if (rotatingBarrel)
        {
            GetComponent<Animator>().enabled = false;
            rotate = true;
        }
    }
    public float getRotation()
    {
        float z = transform.rotation.eulerAngles.z;
        if (z > 180)
        {
            z = (z - 360f) +90f;
        }else
        {
            z = z +90f;
        }
        return z;
    }
    public bool randomParamater(float chance)
    {
        float randomNumber = Random.Range(0,1f);
        if(randomNumber <= chance)
        {
            return true;
        }
        return false;
    }
}
