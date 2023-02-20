using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Admob : MonoBehaviour
{
    private const string BANNER_ID = "ca-app-pub-1026512834381359/4716120269";
    private const string INTERSTITIA_ID = "ca-app-pub-1026512834381359/3403038597";

    private BannerView _banner;
    private InterstitialAd _interstitiaAd;

    private void Awake() => MobileAds.Initialize(initStatuc => { });

    private void OnEnable()
    {
        _banner = new BannerView(BANNER_ID, AdSize.Banner, AdPosition.Bottom);
        AdRequest adRequest = new AdRequest.Builder().Build();
        StartCoroutine(ShowBanner(adRequest));

        _interstitiaAd = new InterstitialAd(INTERSTITIA_ID);
        adRequest = new AdRequest.Builder().Build();
        _interstitiaAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        if (_interstitiaAd.IsLoaded())
            _interstitiaAd.Show();
    }

    private IEnumerator ShowBanner(AdRequest adRequest)
    {
        yield return new WaitForSeconds(3.0f);
        _banner.LoadAd(adRequest);
    }
}
