using GoogleMobileAds.Api;
using System;
using UnityEngine;

namespace PFS.Util.Ads.bannerAdsManager
{
    public class BannerAdsManager : MonoBehaviour
    {
        private BannerView _bannerView;
        private RewardedAd _rewardedAd;

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
                LoadBannerAd();
            });
        }

        public void CreateBannerView()
        {
            Debug.Log("Create Banner view");
            AdSize adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

            if (_bannerView != null)
            {
                DestroyAd();
            }

            _bannerView = new BannerView(_adUnitId, adSize, AdPosition.Top);
        }

        public void LoadBannerAd()
        {
            if (_bannerView == null)
            {
                CreateBannerView();
            }

            var adRequest = new AdRequest.Builder()
                .AddKeyword("Unity-admob-sample")
                .Build();

            Debug.Log("Loading banner ad");
            _bannerView.LoadAd(adRequest);
        }

        /// <summary>
        /// listen to events the banner may raise.
        /// </summary>
        private void ListenToAdEvents()
        {
            // Raised when an ad is loaded into the banner view.
            _bannerView.OnBannerAdLoaded += () =>
            {
                Debug.Log("Banner view loaded an ad with response : "
                    + _bannerView.GetResponseInfo());
            };
            // Raised when an ad fails to load into the banner view.
            _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
            {
                Debug.LogError("Banner view failed to load an ad with error : "
                    + error);
            };
            // Raised when the ad is estimated to have earned money.
            _bannerView.OnAdPaid += (AdValue adValue) =>
            {
                Debug.Log(String.Format("Banner view paid {0} {1}.",
                    adValue.Value,
                    adValue.CurrencyCode));
            };
            // Raised when an impression is recorded for an ad.
            _bannerView.OnAdImpressionRecorded += () =>
            {
                Debug.Log("Banner view recorded an impression.");
            };
            // Raised when a click is recorded for an ad.
            _bannerView.OnAdClicked += () =>
            {
                Debug.Log("Banner view was clicked.");
            };
            // Raised when an ad opened full screen content.
            _bannerView.OnAdFullScreenContentOpened += () =>
            {
                Debug.Log("Banner view full screen content opened.");
            };
            // Raised when the ad closed full screen content.
            _bannerView.OnAdFullScreenContentClosed += () =>
            {
                Debug.Log("Banner view full screen content closed.");
            };
        }

        public void DestroyAd()
        {
            if (_bannerView != null)
            {
                Debug.Log("Destroing banner ad");
                _bannerView.Destroy();
                _bannerView = null;
            }
        }

    }
}