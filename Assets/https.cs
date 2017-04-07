using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


//받을 데이타
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

//smsSend
//1클래스
[System.Serializable]
public class sms_send{
    public string phone;
    public string cert_code;
    public string msg;
    public string code;
}

//signup
[System.Serializable]
public class sign_up
{
    public string mb_id;
    public string msg;
    public string code;

}

//roomList
[System.Serializable]
public class roomList
{
    public string seq;
    public string mb_id;
    public string mb_name;
    public string t_start;
    public string t_end;
    public string t_status;
}


//login
[System.Serializable]
public class userdata{
    public string name;
    public int hp;
    public int attackpower;
}

//sample
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

//보낼 데이타
[System.Serializable]
public class signupdata
{
    public string id;
    public string pass;
    public string phoneNum;
    public string age;
    public string sex;

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
    public sign_up sign_up_r = new sign_up();
    public signupdata sign_updata_r = new signupdata();
    public roomList[] roomList_r;
    public GameObject makebtn;
    public GameObject makebtn_parent;


    //함수부분
    //함수로 코루틴 호출.
    public void Login_Sms(string phonenum)
    {
        StartCoroutine(login_smscheck(phonenum));
    }

    public void Login_signup()
    {
        StartCoroutine(signup(sign_updata_r.id , sign_updata_r.pass, sign_updata_r.phoneNum, sign_updata_r.age, sign_updata_r.sex));
    }

    public void Login()
    {
        StartCoroutine(login(logindata_r.id, logindata_r.pass));
    }

    public void Roomlist()
    {
        StartCoroutine(roomlist());

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
                login[] logins = getJsonArray<login> (www.downloadHandler.text);
                login_r = logins [0];
                Debug.Log(www.downloadHandler.text);

                //result_data objects1 = JsonUtility.FromJson<result_data>(www.downloadHandler.text);

            }
        }
    
    }

    IEnumerator signup(string id, string pass, string hp, string age, string sex)
    {
        WWWForm form = new WWWForm();
        form.AddField("mb_id", id);
        form.AddField("mb_password", pass);
        form.AddField("mb_hp", hp);
        form.AddField("mb_age", age);
        form.AddField("mb_sex", sex);


        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=regist", form))
        {
            yield return www.Send();

            if (www.isError)
            {

            }
            else
            {
                sign_up[] s_signup = getJsonArray<sign_up>(www.downloadHandler.text);
                sign_up_r = s_signup[0];
                //Debug.Log(sign_up_r.code);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }


    IEnumerator roomlist()
    {
        WWWForm form = new WWWForm();
        form.AddField("section", "get_topic");

        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123", form))
        {
            yield return www.Send();

            if (www.isError)
            {

            }
            else
            {
                roomList[] s_roomList = getJsonArray<roomList>(www.downloadHandler.text);

                roomList_r = new roomList[s_roomList.Length];

                for (int i = 0; i < s_roomList.Length; i++)
                {
                    roomList_r[i] = s_roomList[i];

                    GameObject btn = Instantiate(makebtn);
                    btn.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    btn.gameObject.transform.parent = makebtn_parent.transform;

                    btn.transform.FindChild("contentbar").transform.FindChild("room_masterName").GetComponent<Text>().text = roomList_r[i].mb_name;

                    btn.transform.localScale = Vector3.one;
                }

                

                Debug.Log(www.downloadHandler.text);
                Debug.Log("roomList num : " + roomList_r.Length);

                
                //Debug.Log(sign_up_r.code);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }


}
