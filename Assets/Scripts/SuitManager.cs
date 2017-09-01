using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitManager : MonoBehaviour {

    public Suits[] suits;
    public string currentSuit;
    MeshRenderer meshRenderer;
    [System.Serializable]
    public struct Suits
    {
        public string name;
        public Material[] materials;
    }
    public void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        currentSuit = PlayerPrefs.GetString("PlayerSuit");
        if (currentSuit.Equals(""))
        {
            currentSuit = "Default";
        }
        for (int i = 0; i < suits.Length; i++)
        {
            if(suits[i].name == currentSuit)
            {
                setMaterials(i);
                break;
            }
        }


    }
    public void setMaterials(int index)
    {
        meshRenderer.materials = suits[index].materials;
    }
    public void setSuitColor()
    {
        PlayerPrefs.SetString("PlayerSuit","Mars");

    }
}
