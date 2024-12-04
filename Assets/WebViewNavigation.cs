using Normal.UI;
using System;
using TLab.Android.WebView;
using UnityEngine;
using static UnityEngine.AudioSettings;

public class WebViewNavigation : MonoBehaviour
{
    public TLabWebView webViewObject;
    private bool moveAndScaleEnabled = true;

    public void GoBack()
    {
        
        webViewObject.GoBack();
        
    }

    public void GoForward()
    {
       
        webViewObject.GoForward();
        
    }

    public void Reload()
    {

        if (webViewObject != null)
        {
            string currentUrl = webViewObject.GetUrl();
            if (!string.IsNullOrEmpty(currentUrl))
            {
                webViewObject.LoadUrl(currentUrl); // Reloads the current page
            }
        }

    }

    public void SetDesktopVersion()
    {
        String desktopUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36";
        webViewObject.SetUserAgent(desktopUserAgent, true);
    }

    public void SetMobileVersion()
    {
        String mobilrUserAgent = "Mozilla / 5.0(iPhone; CPU iPhone OS 15_0 like Mac OS X) AppleWebKit / 605.1.15(KHTML, like Gecko) Version / 15.0 Mobile / 15E148 Safari / 604.1";
        webViewObject.SetUserAgent(mobilrUserAgent, true);

    }

    public void DisEnableMoveAndScale()
    {
        MoveAndScaleOVR[] allMoveAndScales = FindObjectsOfType<MoveAndScaleOVR>();
        // get all components in scene that are move and scale, disable or enable them 
        if (moveAndScaleEnabled == true)
        {
            foreach (MoveAndScaleOVR moveAndScale in allMoveAndScales)
            {
                if (moveAndScale != null)
                {
                    moveAndScale.enabled = false;
                }
            }
            // disable
            moveAndScaleEnabled = false;

        }
        else
        {
            foreach (MoveAndScaleOVR moveAndScale in allMoveAndScales)
            {
                if (moveAndScale != null)
                {
                    moveAndScale.enabled = true;
                }
            }
            // enable 
            moveAndScaleEnabled = true;
        }
    }
}
