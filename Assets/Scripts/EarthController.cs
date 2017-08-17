using UnityEngine;
public class EarthController : MonoBehaviour
{

    public float speed = 10f;
    public float smoothSpeed = .125f;
    public bool allowRotate = true;
    public Vector3 startPos;
    public Vector3 desiredPosition;
    public Vector3 farPosition;
    Quaternion startRot;
    private void Start()
    {
        startRot = transform.rotation;
    }

    void FixedUpdate()
    {
        if (allowRotate)
        {
            transform.Rotate(Vector3.forward, speed * Time.deltaTime);
        }
        else
        {
            Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, startRot, smoothSpeed);
            transform.rotation = smoothedRotation;
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(transform.position.x, smoothedPosition.y, smoothedPosition.z);
    }
}
