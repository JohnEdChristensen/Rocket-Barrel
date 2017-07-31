using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 10f;
    public float smoothSpeed = .125f;
    public bool allowRotate = true;
    Quaternion startPos;
    private void Start()
    {
        startPos = transform.rotation;
    }
    void FixedUpdate () {
        if (allowRotate)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }else
        {
            Quaternion smoothedPosition = Quaternion.Lerp(transform.rotation, startPos, smoothSpeed);
            transform.rotation = smoothedPosition;
        }
	}
}
