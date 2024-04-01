using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Omnilatent.AdsMediation;
using UnityEngine.UI;

namespace Omnilatent.AdsMediation.Example
{
    public class AdsTesterOmni : MonoBehaviour
    {
        [SerializeField] InputField debugTextField;

        private void Start()
        {
            SS.View.Manager.LoadingSceneName = DLoadingController.SCENE_NAME;
            Application.logMessageReceived += (condition, trace, type) =>
            {
                SetText(condition);
            };

            /*FirebaseManager.LogEvent("312a"); //test start with number
            FirebaseManager.LogEvent("a312a", "a a", 0); //test param contain space
            FirebaseManager.LogEvent("a312a", "0a", 0); //test param start with number
            FirebaseManager.LogEvent("a@312a"); //test contain special character
            FirebaseManager.LogEvent("a a"); //test space
            FirebaseManager.LogEvent("a#123456789123456789123456789123456789123456789"); //test 40 char limit

            FirebaseManager.LogEvent("a2a"); //test valid
            FirebaseManager.LogEvent("a_a"); //test valid
            FirebaseManager.LogEvent("AA_aA3a"); //test valid*/
        }

        public void RequestIntersitial()
        {
            AdsManager.Instance.RequestInterstitialNoShow(AdPlacement.Interstitial, (success) =>
            {
                if (success)
                {
                    AdsManager.Instance.ShowInterstitial(AdPlacement.Interstitial);
                }

                SetText($"Interstitial Request: {success}");
            });
        }

        public void RequestInterstitialRewarded()
        {
            AdsManager.Instance.RequestInterstitialRewardedNoShow(AdPlacement.RewardedInterstitial,
                (success) =>
                {
                    if (success.type == RewardResult.Type.Finished)
                    {
                        AdsManager.Instance.ShowInterstitialRewarded(AdPlacement.RewardedInterstitial,
                            (watched) =>
                            {
                                SetText($"Interstitial Rewarded show: {watched.type}");
                            });
                    }

                    SetText($"Interstitial Rewarded: {success}");
                });
        }

        public void TestReward1()
        {
            AdsManager.Reward(AdPlacement.Reward, (result) =>
            {
                SetText($"Reward result: {result.type}");
            });
        }

        public void TestReward2()
        {
            AdsManager.Reward(AdPlacement.Reward2, (result) =>
            {
                SetText($"Reward 2 result: {result.type}");
            });
        }

        public void ShowTopBanner()
        {
            AdsManager.Instance.ShowBanner(AdPlacement.Banner_Common, new BannerTransform(AdPosition.Top));
        }

        public void ShowBottomBanner()
        {
            AdsManager.Instance.ShowBanner(AdPlacement.Banner_Bottom, new BannerTransform(AdPosition.Bottom));
        }

        public void ShowCollapsibleBottomBanner()
        {
            AdsManager.Instance.ShowBanner(AdPlacement.Banner_CollapsibleBottom, new BannerTransform(AdPosition.Bottom)
            {
                Collapsible = true
            });
        }

        public void HideBanner()
        {
            AdsManager.Instance.HideBanner();
        }

        public void HideTopBanner()
        {
            AdsManager.Instance.HideBanner(AdPlacement.Banner_Common);
        }

        public void HideBottomBanner()
        {
            AdsManager.Instance.HideBanner(AdPlacement.Banner_Bottom);
        }

        public void HideCollapsibleBottomBanner()
        {
            AdsManager.Instance.HideBanner(AdPlacement.Banner_CollapsibleBottom);
        }

        public void DestroyBanner()
        {
            AdsManager.Instance.DestroyBanner();
        }

        public void DestroyTopBanner()
        {
            AdsManager.Instance.DestroyBanner(AdPlacement.Banner_Common);
        }

        public void DestroyBottomBanner()
        {
            AdsManager.Instance.DestroyBanner(AdPlacement.Banner_Bottom);
        }

        public void DestroyCollapsibleBottomBanner()
        {
            AdsManager.Instance.DestroyBanner(AdPlacement.Banner_CollapsibleBottom);
        }

        public void TestOpenAd()
        {
            AdsManager.Instance.RequestAppOpenAd(AdPlacement.App_Open_Ad, (success) =>
            {
                if (success)
                    AdsManager.Instance.ShowAppOpenAd(AdPlacement.App_Open_Ad,
                        (isClosed) =>
                        {
                            SetText("App open ad closed");
                        });
            });
        }

        void SetText(string text)
        {
            debugTextField.text = text;
        }
    }
}