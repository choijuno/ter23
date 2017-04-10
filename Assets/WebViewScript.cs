using UnityEngine;
using System.Collections;

[System.Serializable]
public class Margins
{
    public string name;
    public int TopMargins;
    public int BotMargins;
    public int LeftMargins;
    public int RightMargins;
}


public class WebViewScript : MonoBehaviour {

    private WebViewObject signupViewObject;
    public long data;


    private WebViewObject webViewObject;
    private WebViewObject movieViewObject;
    public GameObject https;

    public int TopMargins;
    public int BotMargins;
    public int LeftMargins;
    public int RightMargins;


    public Margins[] myMagins;

    

    public static bool destroyCheck;
    public static bool visibilityCheck;


    public static string id_s;
    public static string topic_s;
    public static string chNum_s;



    int testbool;

    // Use this for initialization
    void Start () {
        id_s = "test";
        topic_s = "0";
        chNum_s = "1";
        //StartWebView();


    }

    public int check_view = 0;

    // Update is called once per frame
    void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            //BotMargins = GameManager.chatSizebot;

            //text1.text = "TouchScreenKeyboard.isSupported : " + GetKeyboardSize();
            if (GetKeyboardSize() != 0)
            {
                testbool = GetKeyboardSize();
            }
            else testbool = 0; 
            
        }




        switch (check_view)
        {
            case 1:
                signupViewObject.SetMargins(0, 0, 0, 0 + testbool);
            break;
            case 2:
                webViewObject.SetMargins(LeftMargins, TopMargins, RightMargins, BotMargins + testbool);
                break;
            case 3:
                movieViewObject.SetMargins(LeftMargins, TopMargins, RightMargins, BotMargins + testbool);
                break;
            case 4:
                webViewObject.SetMargins(myMagins[1].LeftMargins, myMagins[1].TopMargins, myMagins[1].RightMargins, myMagins[1].BotMargins);
                break;
            case 5:
                webViewObject.SetMargins(myMagins[2].LeftMargins, myMagins[2].TopMargins, myMagins[2].RightMargins, myMagins[2].BotMargins);
                break;

        }

    }

    public int GetKeyboardSize()
    {
        using (AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");

            using (AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
            {
                View.Call("getWindowVisibleDisplayFrame", Rct);

                return Screen.height - Rct.Call<int>("height");
            }
        }
    }

    public void StartSignup()
    {
        data = System.DateTime.Now.Ticks;



        string strUrl = "http://ter23api.viewlab.kr/cpc/checkplus_main.php?user_id=" + data;
        Debug.Log("webView = " + strUrl);
        signupViewObject = (new GameObject("signupViewObject")).AddComponent<WebViewObject>();
        signupViewObject.Init((msg) => {
            Debug.Log(string.Format("CallFromJS[{0}]", msg));

            
        });

        check_view = 1;

        signupViewObject.LoadURL(strUrl);
        signupViewObject.SetVisibility(true);
        signupViewObject.SetMargins(0, 0, 0, 0 + testbool);

        https.GetComponent<https>().signCheckdata_r.checkNum = data.ToString();
        https.GetComponent<https>().Sign_check();

    }

    public void StopSignup()
    {
        Destroy(signupViewObject);

    }



    public void StartWebView()
    {
        //https.GetComponent<https>()
        Debug.Log("webView!!!============");
        string strUrl = "http://ter23chat.viewlab.co.kr/chat?userId="+ GameManager.idSave +"&roomName=" + GameManager.seqSave + "_" + GameManager.channelSave;
        Debug.Log("webView = " + strUrl);
        //h ttp://ter23chat.viewlab.co.kr/chat?userId=유저아이디&roomName=주제시퀀스_채널번호
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg)=>{
            Debug.Log(string.Format("CallFromJS[{0}]", msg));
        });

        check_view = 2;

        webViewObject.LoadURL(strUrl);
        webViewObject.SetVisibility(true);
        webViewObject.SetMargins(LeftMargins, TopMargins, RightMargins, BotMargins);
        
    }

    public void StartmovieView()
    {
        Debug.Log("movieView!!!============");
        string strUrl = "http://ter23api.viewlab.kr/api/movie/?cidx=1";

        movieViewObject = (new GameObject("movieViewObject")).AddComponent<WebViewObject>();
        movieViewObject.Init((msg) => {
            Debug.Log(string.Format("CallFromJS[{0}]", msg));
        });

        check_view = 3;

        movieViewObject.LoadURL(strUrl);
        movieViewObject.SetVisibility(true);
        movieViewObject.SetMargins(LeftMargins, TopMargins, RightMargins, BotMargins);
    }

    public void StopWebView()
    {
        Destroy(webViewObject);

    }

    public void StopmovieView()
    {
        Destroy(movieViewObject);

    }

    public void OnWebView()
    {
        if(webViewObject)
            //webViewObject.SetMargins(0, 0, 0, 0);
        webViewObject.SetVisibility(true);
       // webViewObject.SetMargins(0, 0, 0, 0);

    }

    public void OffWebView()
    {
        if (webViewObject)
            webViewObject.SetVisibility(false);

    }

    public void setChat()
    {
        check_view = 4;
        webViewObject.SetMargins(myMagins[1].LeftMargins, myMagins[1].TopMargins, myMagins[1].RightMargins, myMagins[1].BotMargins);
    }
    public void setMovieChat()
    {
        check_view = 5;
        webViewObject.SetMargins(myMagins[2].LeftMargins, myMagins[2].TopMargins, myMagins[2].RightMargins, myMagins[2].BotMargins);
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

