using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public int playsWithoutAd;
    private void Start()
    {
        playsWithoutAd = PlayerPrefs.GetInt("PlaysWithoutAd", 0);
    }
    public void ShowRewardedAd()
    {
        if (playsWithoutAd >=2) {
            if (Advertisement.IsReady("rewardedVideo"))
            {
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
            }
        }else
        {
            Debug.Log("Not enough plays to show add");
            Increase();
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ad Showed");
                playsWithoutAd = 0;
                PlayerPrefs.SetInt("PlaysWithoutAd", 0);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                Increase();
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                Increase();
                break;
        }
    }
    void Increase()
    {
        
        PlayerPrefs.SetInt("PlaysWithoutAd", playsWithoutAd + 1);
    }
    public void checkIfSkipped()
    {
        if(playsWithoutAd >= 2 && Advertisement.IsReady("rewardedVideo"))
        {
            ShowRewardedAd();
        }
        else
        {
            GetComponent<GameManager>().StartGame();
        }
    }

}