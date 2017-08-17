using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FPSDisplayScript : MonoBehaviour
{
    float timeA;
    public int fps;
    public int lastFPS;
    public int lastLastFPS = 0;
    public Text textStyle;
    // Use this for initialization
    void Start()
    {

        timeA = Time.timeSinceLevelLoad;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.timeSinceLevelLoad+" "+timeA);
        if (Time.timeSinceLevelLoad - timeA <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeA = Time.timeSinceLevelLoad;
            fps = 0;
        }
        if (lastFPS != lastLastFPS)
        {
            textStyle.text = lastFPS.ToString();
        }
        lastLastFPS = lastFPS;
    }
    
}
