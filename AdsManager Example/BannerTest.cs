using UnityEngine;
using UnityEngine.UI;

namespace Omnilatent.AdsMediation.Example
{
    public class BannerTest : MonoBehaviour
    {
        public void RequestTopBanner()
        {
            RequestBanner(AdPlacement.Banner_Common);
        }

        public void RequestBottomBanner()
        {
            RequestBanner(AdPlacement.Banner_Bottom);
        }

        public void RequestCollapsibleBottomBanner()
        {
            RequestBanner(AdPlacement.Banner_CollapsibleBottom);
        }

        public void RequestBanner(AdPlacement.Type type)
        {
            BannerTransform bannerTransform = null;

            if (type == AdPlacement.Banner_Common)
            {
                bannerTransform = new BannerTransform(AdPosition.Top);
            }
            else if (type == AdPlacement.Banner_Bottom)
            {
                bannerTransform = new BannerTransform(AdPosition.Bottom);
            }
            else if (type == AdPlacement.Banner_CollapsibleBottom)
            {
                bannerTransform = new BannerTransform(AdPosition.Bottom);
                bannerTransform.Collapsible = true;
            }

            AdsManager.Instance.RequestBanner(type, bannerTransform, (success, adObject) =>
            {
                Debug.Log($"Request: {success}, adObject state: {adObject.State}");
            });
        }

        public void ShowTopLegacy()
        {
            AdsManager.Instance.ShowBanner(AdPlacement.Banner_Common);
        }

        public void HideAllBanner()
        {
            AdsManager.Instance.HideBanner();
        }

        public void DestroyAllBanner()
        {
            AdsManager.Instance.DestroyBanner();
        }
    }
}