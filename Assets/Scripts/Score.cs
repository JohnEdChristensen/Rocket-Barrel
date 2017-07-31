using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    float oldHeight;
    float height;

	void Start () {
        scoreText.text = "0";
        oldHeight = 0;
	}
	
	void Update () {
        height = gameObject.transform.position.y;
        if(height > oldHeight)
        {
            scoreText.text = Mathf.Round(height*1.3333333f).ToString();
        }
        oldHeight = height;

	}
}
