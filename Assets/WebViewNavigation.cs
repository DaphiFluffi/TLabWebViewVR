using TLab.Android.WebView;
using UnityEngine;

public class WebViewNavigation : MonoBehaviour
{
    public TLabWebView webViewObject;

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
}
