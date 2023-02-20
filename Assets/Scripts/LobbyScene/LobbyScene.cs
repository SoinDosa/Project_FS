using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System;

namespace PFS.LobbyScene.lobbyScene
{
    public class LobbyScene : MonoBehaviour
    {
        private BannerView bannerView;
#if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif
        void Start()
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                LoadAd();
            });
        }

        public void CreateBannerView()
        {
            Debug.Log("Create Banner view");
            AdSize adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

            if (bannerView != null)
            {
                DestroyAd();
            }

            bannerView = new BannerView(_adUnitId, adSize, AdPosition.Top);
        }

        public void LoadAd()
        {
            if (bannerView == null)
            {
                CreateBannerView();
            }

            var adRequest = new AdRequest.Builder()
                .AddKeyword("Unity-admob-sample")
                .Build();

            Debug.Log("Loading banner ad");
            bannerView.LoadAd(adRequest);
        }
        
        /// <summary>
        /// listen to events the banner may raise.
        /// </summary>
        private void ListenToAdEvents()
        {
            // Raised when an ad is loaded into the banner view.
            bannerView.OnBannerAdLoaded += () =>
            {
                Debug.Log("Banner view loaded an ad with response : "
                    + bannerView.GetResponseInfo());
            };
            // Raised when an ad fails to load into the banner view.
            bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
            {
                Debug.LogError("Banner view failed to load an ad with error : "
                    + error);
            };
            // Raised when the ad is estimated to have earned money.
            bannerView.OnAdPaid += (AdValue adValue) =>
            {
                Debug.Log(String.Format("Banner view paid {0} {1}.",
                    adValue.Value,
                    adValue.CurrencyCode));
            };
            // Raised when an impression is recorded for an ad.
            bannerView.OnAdImpressionRecorded += () =>
            {
                Debug.Log("Banner view recorded an impression.");
            };
            // Raised when a click is recorded for an ad.
            bannerView.OnAdClicked += () =>
            {
                Debug.Log("Banner view was clicked.");
            };
            // Raised when an ad opened full screen content.
            bannerView.OnAdFullScreenContentOpened += () =>
            {
                Debug.Log("Banner view full screen content opened.");
            };
            // Raised when the ad closed full screen content.
            bannerView.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Banner view full screen content closed.");
            };
        }

        public void DestroyAd()
        {
            if (bannerView != null)
            {
                Debug.Log("Destroing banner ad");
                bannerView.Destroy();
                bannerView = null;
            }
        }
    }
}
