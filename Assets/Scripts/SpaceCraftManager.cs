using UnityEngine;

public class SpaceCraftManager : MonoBehaviour {
    public GameObject LunarLander;
    public GameObject LunarRover;
    public GameObject MarsRover;
    public GameObject Juno;
    public GameObject Cassini;
    public GameObject Voyager;

    public void Awake()
    {
        PlayerPrefs.SetInt("CassiniEnabled", 1);
    }
    public void Start()
    {
        LunarLander.SetActive(1 == PlayerPrefs.GetInt("LunarLanderEnabled", 0));
        LunarRover.SetActive(1 == PlayerPrefs.GetInt("LunarRoverEnabled", 0));
        MarsRover.SetActive(1 == PlayerPrefs.GetInt("MarsRoverEnabled", 0));
        Juno.SetActive(1 == PlayerPrefs.GetInt("JunoEnabled", 0));
        Cassini.SetActive(1 == PlayerPrefs.GetInt("CassiniEnabled", 0));
        Voyager.SetActive(1 == PlayerPrefs.GetInt("VoyagerEnabled", 0));
    }
}
