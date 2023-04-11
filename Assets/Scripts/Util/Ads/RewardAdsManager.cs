using GoogleMobileAds.Api;
using PFS.UI.Popup.gameOverPopup;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PFS.Util.Ads.rewardAdsManager
{
    public class RewardAdsManager : MonoBehaviour
    {
        public Action OnGameContinue;
        private RewardedAd _rewardedAd;

#if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

        public void LoadRewardedAd()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }

            Debug.Log("Loading the rewarded ad.");

            var adRequest = new AdRequest.Builder().Build();

            RewardedAd.Load(_adUnitId, adRequest,
                (RewardedAd ad, LoadAdError error) =>
                {
                    if (error != null || ad == null)
                    {
                        Debug.LogError("Rewarded ad failed to load an ad " + "with error : " + error);

                        return;
                    }

                    Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());

                    _rewardedAd = ad;

                    ShowRewardedAd();
                });
        }

        public void ShowRewardedAd()
        {
            const string rewardMsg = "Rewarded ad rewarded the user. Type : {0}, amount : {1}.";

            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    OnGameContinue();
                });
            }
        }
    }
}
