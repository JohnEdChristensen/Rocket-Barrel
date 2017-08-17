using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour {
    public

	void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<GameManager>().onLoseTrigger();
            collider.GetComponentInParent<Score>().setEndScore();
        }
    }
}
