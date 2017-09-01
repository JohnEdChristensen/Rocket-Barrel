using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpHeight = 8f;
    public GameManager gameManager;
    public GameObject activeBarrel;
    public GameObject loseTrigger;
    public bool insideBarrel;
    Rigidbody rb;
    bool launchCall = false;
    Vector3 launchForce;
    float YForce;



    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        YForce = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);
        launchForce = new Vector3(0, YForce , 0);
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (insideBarrel)
            {
                launchCall = true;
            }
        }
    }

    void FixedUpdate () {
        if (insideBarrel)
        {
            transform.position = activeBarrel.transform.position;
            if (launchCall)
            {
                launchCall = false;
                launch();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            insideBarrel = true;
            rb.useGravity = false;
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            activeBarrel = collision.gameObject;
            loseTrigger.transform.position += new Vector3(0, 7.5f, 0);
            gameManager.GetComponent<DifficultyManager>().levelCheck();
        }
        else if(collision.collider.tag == "Obstacle")
        {
            //gameObject.GetComponent<Rigidbody>().constraints = false;
        }
        
    }
    void launch()
    {
        
        if (activeBarrel.GetComponent<BarrelController>().rotatingBarrel == true)
        {
            float XVal = launchForce.y / Mathf.Tan(Mathf.Deg2Rad * activeBarrel.GetComponent<BarrelController>().getRotation());
            launchForce = new Vector3(XVal, launchForce.y, launchForce.z);
        }else
        {
            launchForce = new Vector3(0, YForce, 0);
        }
        insideBarrel = false;
        gameObject.GetComponentInChildren<Renderer>().enabled = true;
        rb.useGravity = true;
        rb.velocity = launchForce;
        FindObjectOfType<AudioManager>().Play("Explode");
        activeBarrel.GetComponent<BarrelController>().launched();
        float ZRotation = 0;
        if(activeBarrel.transform.rotation.eulerAngles.z != 180f)
        {
            ZRotation = activeBarrel.transform.rotation.eulerAngles.z;
        }
        transform.rotation = Quaternion.Euler(0, 0, ZRotation);

    }
    
    
}
