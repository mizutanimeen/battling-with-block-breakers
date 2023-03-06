using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdmobScript : MonoBehaviour
{
    private BannerView bannerAd;
    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-5892283405795410/7705550263";
        this.bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerAd.LoadAd(request);
    }
}
