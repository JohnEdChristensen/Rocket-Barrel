using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour {
    public GameManager gameManager;

	void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<GameManager>().onLoseTrigger();
            gameManager.GetComponentInParent<Score>().setEndScore();
        }
    }
}
