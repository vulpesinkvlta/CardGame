using System;
using UnityEngine;

namespace Core.Platform
{
    public class StubAdsService : IAdsService
    {
        public void ShowInterstitialAd()
        {
            Debug.Log("[StubAdsService] ShowInterstitialAd called");
        }

        public void ShowRewardedAd(string placementId, Action<bool> onCompleted)
        {
            Debug.Log($"[StubAdsService] ShowRewardedAd called with placementId: {placementId}");
            onCompleted?.Invoke(true);
        }
    }
}
