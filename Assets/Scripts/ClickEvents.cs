using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickEvents : MonoBehaviour
{
     public GameObject adContainer;
    
    public void RestartClicked()
    {
        PlayerPrefs.DeleteKey("LastScore");
        PlayerPrefs.DeleteKey("LastScore");
        SceneManager.LoadScene("Game");
    }

    public void RespawnClicked()
    {
        if(adContainer.GetComponent<MobileAd>().isAdLoaded()){
            adContainer.GetComponent<MobileAd>().ShowRewardedVideo();
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}
