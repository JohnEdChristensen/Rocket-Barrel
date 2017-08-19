using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WalletManager : MonoBehaviour {
    [SerializeField]
    int walletValue;
   
    Text walletValueText;
    void Start()
    {
        walletValueText = GameObject.Find("WalletValueText").GetComponent<Text>();
        walletValue = PlayerPrefs.GetInt("WalletValue", 0);
        walletValueText.text = walletValue.ToString();
    }

    public void incramentWallet()
    {
        walletValue += 1;
        PlayerPrefs.SetInt("WalletValue", walletValue);
        Debug.Log(walletValue);
        walletValueText.text = walletValue.ToString();
    }
}
