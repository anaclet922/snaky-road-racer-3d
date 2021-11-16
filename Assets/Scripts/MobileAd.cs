using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class MobileAd : MonoBehaviour
{
    public static MobileAd inst;

    private RewardedAd rewardedAd; 
    public BannerView bannerView;

    public string rewardedAdsId = "ca-app-pub-9224321170501640/9691424741";

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestRewardedAd();
        RequestBanner();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void RequestRewardedAd()
    {
        rewardedAd = new RewardedAd(rewardedAdsId);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
    }
    public void ShowRewardedVideo()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
    }
    public bool isAdLoaded()
    {
        if (rewardedAd.IsLoaded())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {

    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        RequestRewardedAd();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        double amount = args.Amount;
        int newScore = (int)Math.Round(amount) + PlayerPrefs.GetInt("LastScore");
        PlayerPrefs.SetInt("LastScore", newScore);
        RequestRewardedAd();
        SceneManager.LoadScene("Game");
    }


    public void RequestBanner()
    {

        string adUnitId = "ca-app-pub-9224321170501640/8917291326";

        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Called when an ad request has successfully loaded.
        bannerView.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        bannerView.OnAdOpening += HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        bannerView.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        //bannerView.OnAdLeavingApplication  += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

        //StartCoroutine(RequestBanners());
    }

    //public void HandleOnAdLoaded(object sender, EventArgs args)
    //{
    //    MonoBehaviour.print("HandleAdLoaded event received");
    //}

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        RequestBanner();
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //RequestBanner();
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdClosed event received");
        RequestBanner();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    public void destroyBanner()
    {
        bannerView.Destroy();
    }

    //IEnumerator RequestBanners()
    //{
    //    while (true)
    //    {
    //        bannerView.Destroy();
    //        RequestBanner();
    //        yield return new WaitForSeconds(20.0f);
    //    }
    //}
}
