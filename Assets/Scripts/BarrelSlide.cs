using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSlide : MonoBehaviour {

    public GameObject explosion;
    public float min = -2f;
    public float max = 2f;
    public float speed = 2f;
    public float barrelDistance = 7.5f;
    float startTime = 2f;
    public bool startRandom = true;
    public bool activeBarrel = false;
    GameObject pastExplosion;
    private void Awake()
    {

    }
    private void Start()
    {
        if (startRandom)
        {
            startTime = Random.Range(0, 4f);
        }
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed + startTime, max - min) + min, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        activeBarrel = true;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = true;
        
    }
    public void launched()
    {
        activeBarrel = false;
        pastExplosion = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(pastExplosion, .5f);
        gameObject.transform.position = new Vector3(Random.Range(min, max), transform.position.y + (barrelDistance*3), 0);
        
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Animator>().enabled = false;
        Instantiate(gameObject,transform.position, Quaternion.Euler(180f, 0, 0));
        Destroy(gameObject);
    }

}
