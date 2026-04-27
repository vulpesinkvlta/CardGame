using System;

namespace Core.Platform
{
    public interface IAdsService
    {
        void ShowInterstitialAd();
        void ShowRewardedAd(string placementId, Action<bool> onCompleted);
    }
}
