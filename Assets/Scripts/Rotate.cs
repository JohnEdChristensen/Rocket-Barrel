using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rotate : MonoBehaviour {

    public float speed = 10f;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    } 
}
