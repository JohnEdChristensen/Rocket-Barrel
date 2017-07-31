using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        FindObjectOfType<GameManager>().endGame();
    }
}
