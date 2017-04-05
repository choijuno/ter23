using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class login{
    public string mb_id; 
    public string mb_name;    
    public int mb_sex;     
    public int mb_level;    
    public int mb_point;
    public string msg;
    public string msg2;
    public string code; 
}

//1클래스
[System.Serializable]
public class sms_send{
    public string phone;
    public string cert_code;
    public string msg;
    public string code;
}

[System.Serializable]
public class userdata{
    public string name;
    public int hp;
    public int attackpower;
}

[System.Serializable]
public class mdata{
    public string typename;
}

//제이슨 안의 배열.
[System.Serializable]
public class result_data{

    public userdata[] data;
    public mdata meta;

}

[System.Serializable]
public class logindata{
    public string id;
    public string pass;

}



public class https : MonoBehaviour {

    public login login_r = new login();
    public logindata logindata_r = new logindata();

    public sms_send smsCheck = new sms_send();

    //함수로 코루틴 호출.
    public void Login_Sms(string phonenum)
    {
        StartCoroutine(login_smscheck(phonenum));
    }
    public void Login()
    {
        Debug.Log("void Login");
        StartCoroutine(login(logindata_r.id, logindata_r.pass));
    }






    void Start() {
        //StartCoroutine(login_smscheck());
    }

    //Form
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"result\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
        return wrapper.result;
    }
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] result;
    }



    //2코루틴.
    IEnumerator login_smscheck(string phonenum) {
        WWWForm form = new WWWForm();
        //3 ( API관리 홈페이지 ) 각각의 변수와 값 대입.
        form.AddField("phone", phonenum);

        using(UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=sms", form)) {
            yield return www.Send();

            if (www.isError) {

            } else {
                //송신값 확인.
                Debug.Log(www.downloadHandler.text);
                //제이슨이 배열일 때 클래스생성.
                sms_send[] s_login = getJsonArray<sms_send> (www.downloadHandler.text);

                //s_login[]클래스에서 cert_code값 빼내기.
                smsCheck = s_login[0];
                Debug.Log(s_login[0].cert_code);

                //제이슨이 배열x일 때 클래스생성.
                //result_data objects1 = JsonUtility.FromJson<result_data>(www.downloadHandler.text);

            }
        }

    }

    IEnumerator login(string id, string pass) {
        WWWForm form = new WWWForm();
        form.AddField("mb_id", id);
        form.AddField("mb_password", pass);

        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=login", form)) {
            yield return www.Send();

            if (www.isError) {
                 
            } else {
                Debug.Log("!!!");
                login[] logins = getJsonArray<login> (www.downloadHandler.text);
                login_r = logins [0];
                Debug.Log(login_r.mb_id);
                //result_data objects1 = JsonUtility.FromJson<result_data>(www.downloadHandler.text);

            }
        }
    
    }
}
