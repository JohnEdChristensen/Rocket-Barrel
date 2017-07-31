using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpHeight = 8f;
    public GameObject activeBarrel;
    public GameObject loseTrigger;
    public bool insideBarrel;
    Rigidbody rb;
    bool launchCall = false;
    Vector3 launchForce;



    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        float YForce = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);
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
        
        insideBarrel = true;
        rb.useGravity = false;
        gameObject.GetComponentInChildren<Renderer>().enabled = false;
        activeBarrel = collision.gameObject;
        loseTrigger.transform.position += new Vector3(0, 7.5f, 0);

        
    }
    void launch()
    {
        
        insideBarrel = false;
        gameObject.GetComponentInChildren<Renderer>().enabled = true;
        rb.useGravity = true;
        rb.velocity = launchForce;
        FindObjectOfType<AudioManager>().Play("Explode");
        activeBarrel.GetComponent<BarrelSlide>().launched();

    }
}
