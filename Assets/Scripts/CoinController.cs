using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour {

    public Text walletValueText;
    public GameObject Get_Coin;
    GameObject pastGet_Coin;
    GameObject walletManager;
    private void Start()
    {
        walletManager = GameObject.Find("WalletManager");
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            walletManager.GetComponent<WalletManager>().incramentWallet();
            pastGet_Coin = Instantiate(Get_Coin, transform.position, transform.rotation);
            Destroy(pastGet_Coin, .5f);
            Destroy(gameObject);
        }
        
    }
}
