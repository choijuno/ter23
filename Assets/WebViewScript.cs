using UnityEngine;
using System.Collections;

public class WebViewScript : MonoBehaviour {

    private WebViewObject webViewObject;

    public int TopMargins;
    public int BotMargins;
    public int LeftMargins;
    public int RightMargins;

    public static bool destroyCheck;
    public static bool visibilityCheck;

    // Use this for initialization
    void Start () {
        //StartWebView();
    }

    // Update is called once per frame
    void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            
            if (destroyCheck)
            {
                Destroy(webViewObject);
                destroyCheck = false;
                return;
            }

            if (visibilityCheck)
            {
                
            } else
            {

            }

        }

    }

    public void StartWebView()
    {
        string strUrl = "http://ter23chat.viewlab.co.kr/chat?userId="+ GameManager.player_id +"&roomName=" + GameManager.channelNum;

        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg)=>{
            Debug.Log(string.Format("CallFromJS[{0}]", msg));
        });

        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(LeftMargins, TopMargins, RightMargins, BotMargins);
        webViewObject.CanGoBack();
    }

    public void StopWebView()
    {


    }

    public void visible(float time)
    {
        if(time == 0)
        {

        } else
        {

        }
    }

    IEnumerator visibleCheck(float time)
    {
        while (true)
        {
            time = time - Time.deltaTime;
            if (time <= 0)
            {
                Debug.Log(time);
                break;
            }
            yield return null;
        }
        
    }
}

