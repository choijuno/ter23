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
    public string mb_age;
    public string mb_icon;
}

[System.Serializable]
public class signCheck
{
    public string user_id;
    public string mb_name;
    public string mb_birth;
    public string mb_sex;
    public string msg;
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
    public string topic;
    public string t_start;
    public string t_end;
    public string t_status;
}

//roomMake
[System.Serializable]
public class roomMake
{
    public string seq;
    public string mb_id;
    public string mb_name;
    public string t_start;
    public string t_end;
    public string t_status;
    public string msg;
    public string code;

}

//getCh
[System.Serializable]
public class getCh
{
    public string channel;
    public string condition;
}



//getMember
[System.Serializable]
public class getMember
{
    public string mb_id;
    public string mb_name;
    public string mb_age;
    public string mb_sex;
    public string mb_level;
    public string mb_xp;
    public string mb_point;
    public string mb_icon;
    public string area;
    public string pos_x;
    public string pos_y;
    public string msg;
    public string code;

}

//icon
[System.Serializable]
public class update_Icon
{
    public string mb_id;
    public string msg;
    public string code;

}

//ch_userGet
[System.Serializable]
public class chat_Member
{
    public string mb_id;
    public string mb_name;
    public string mb_icon;
    public string mb_xp;
    public string mb_point;
    public string mb_sex;
    public string mb_age;
}


//etc
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
public class signCheckdata
{
    public string checkNum;

}

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

[System.Serializable]
public class roommakedata
{
    public string id;
    public string roomname;
    public string t_start;
    public string t_end;
}

[System.Serializable]
public class getMemberdata
{
    public string id;
}

[System.Serializable]
public class update_icondata
{
    public string mb_id;
    public string mb_icon;
}

[System.Serializable]
public class getChdata
{
    public string seq;

}

//ch_userGet
[System.Serializable]
public class chat_Memberdata
{
    public string seq;
    public string channel;
}



public class https : MonoBehaviour {

    public login login_r = new login();
    public logindata logindata_r = new logindata();

    public sms_send smsCheck = new sms_send();

    public sign_up sign_up_r = new sign_up();
    public signupdata sign_updata_r = new signupdata();

    public GameObject[] m_roomlist;
    public roomList[] roomList_r;
    public GameObject make_roombtn;
    public GameObject make_roomplus;
    public GameObject make_roomParent;

    public GameObject[] m_chlist;
    public GameObject[] ch_list;
    public roomList[] ch_list_r;
    public GameObject ch_prefabs;
    public GameObject ch_parent;

    


    public roomMake roommake_r = new roomMake();
    public roommakedata roommakedata_r = new roommakedata();

    public getCh getCh_r = new getCh();
    public getChdata getChdata_r = new getChdata();


    public getMember getMember_r = new getMember();
    public getMemberdata getMemberdata_r = new getMemberdata();

    public update_Icon update_Icon_r = new update_Icon();
    public update_icondata update_icondata_r = new update_icondata();

    public chat_Member[] chat_Member_r;
    public chat_Memberdata chat_Memberdata_r = new chat_Memberdata();

    public signCheck signCheck_r = new signCheck();
    public signCheckdata signCheckdata_r = new signCheckdata();



    [Space]
    //obj
    public GameObject gameManager;
    public GameObject roomMake_doneBtn;
    public GameObject login_Btn;
    public GameObject signup_panel;

    [Space]
    public GameObject userlist_player;
    public GameObject[] m_userlist;
    public GameObject make_userParent;

    [Space]
    public GameObject mapUser_player;
    public GameObject[] mapUsers;

    //함수부분
    //함수로 코루틴 호출.

    public void Sign_check()
    {
        StartCoroutine(sign_check(signCheckdata_r.checkNum));
    }

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

    public void Roommake()
    {
        StartCoroutine(roommake(roommakedata_r.id, roommakedata_r.roomname, roommakedata_r.t_start, roommakedata_r.t_end));
    }

    public void Get_ch()
    {
        StartCoroutine(getch(getChdata_r.seq));
    }

    public void Getmember()
    {
        StartCoroutine(getmember(getMemberdata_r.id));
    }
    
    public void Update_icon()
    {
        StartCoroutine(update_icon(update_icondata_r.mb_id, update_icondata_r.mb_icon));
    }

    public void Chat_member()
    {
        StartCoroutine(chat_member());
    }


    public void Send_voice()
    {
        StartCoroutine(send_voice());
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



    IEnumerator sign_check(string checkNum)
    {

        Debug.Log("signCheck!!!!!!!!!!===================");

        WWWForm form = new WWWForm();
        //3 ( API관리 홈페이지 ) 각각의 변수와 값 대입.
        form.AddField("user_id", checkNum);

        using (UnityWebRequest www = UnityWebRequest.Post("http://ter23api.viewlab.kr/cpc/?", form))
        {
            yield return www.Send();

            if (www.isError)
            {

            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                signCheck[] s_signCheck = getJsonArray<signCheck>(www.downloadHandler.text);

                signCheck_r = s_signCheck[0];

                if(signCheck_r.msg == "성공" && signCheck_r.code == "100")
                {
                    GameObject.Find("webviewManager").GetComponent<WebViewScript>().StopSignup();
                    signup_panel.SetActive(true);
                    



                } else
                {
                    yield return new WaitForSeconds(3f);
                    StartCoroutine(sign_check(checkNum));
                }
                
                
                
                

            }
        }
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
                string test_id;

                login[] logins = getJsonArray<login> (www.downloadHandler.text);
                login_r = logins [0];
                //Debug.Log(www.downloadHandler.text);

                //result_data objects1 = JsonUtility.FromJson<result_data>(www.downloadHandler.text);

                GameManager.idSave = login_r.mb_id;
                GameManager.nameSave = login_r.mb_name;
                GameManager.sexSave = login_r.mb_sex.ToString();
                GameManager.ageSave = login_r.mb_age;
                GameManager.iconSave = login_r.mb_icon;

                login_Btn.GetComponent<BtnController>()._0_login_wait();

                
                PlayerPrefs.SetString("idSave", login_r.mb_id.ToString());
                PlayerPrefs.SetString("passSave", pass.ToString());

                PlayerPrefs.SetString("nameSave", login_r.mb_name);
                PlayerPrefs.SetString("sexSave", login_r.mb_sex.ToString());
                PlayerPrefs.SetString("ageSave", login_r.mb_age);
                PlayerPrefs.SetString("iconSave", login_r.mb_icon);

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
                //Debug.Log(www.downloadHandler.text);

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


                if (m_roomlist.Length > 0)
                {
                    make_roomParent.GetComponent<RectTransform>().sizeDelta = new Vector2(720, 1189);
                    for (int i = 0; i < m_roomlist.Length; i++)
                    {
                        Destroy(m_roomlist[i]);
                    }
                      
                }

                roomList_r = new roomList[s_roomList.Length];
                m_roomlist = new GameObject[s_roomList.Length+1];



                for (int i = 0; i < s_roomList.Length; i++)
                {
                    roomList_r[i] = s_roomList[i];

                    GameObject btn = Instantiate(make_roombtn);
                    btn.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    btn.gameObject.transform.parent = make_roomParent.transform;
                    btn.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, 0);

                    btn.transform.FindChild("contentbar").transform.FindChild("room_masterName").GetComponent<Text>().text = "주최자 : " + roomList_r[i].mb_id;
                    btn.transform.FindChild("namebar").transform.FindChild("room_name").GetComponent<Text>().text = roomList_r[i].topic;
                    btn.transform.localScale = Vector3.one;
                    btn.gameObject.name = "room" + roomList_r[i].seq;
                    //btn.GetComponent<BtnController>().gameManager = GameObject.Find("GameManager");
                    btn.GetComponent<BtnController>().open_panel = GameObject.Find("GameManager").GetComponent<GameManager>()._3_channel;
                    btn.GetComponent<BtnController>().myAni_out = GameObject.Find("2_room_window");
                    btn.GetComponent<BtnController>().https = GameObject.Find("https");

                    m_roomlist[i] = btn;

                    if (i > 3)
                    {
                        Debug.Log("========1");
                        make_roomParent.GetComponent<RectTransform>().sizeDelta = new Vector2(make_roomParent.GetComponent<RectTransform>().rect.width, make_roomParent.GetComponent<RectTransform>().rect.height + 300);

                    }
                }


                

                GameObject plusbtn = Instantiate(make_roomplus);
                plusbtn.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                plusbtn.gameObject.transform.parent = make_roomParent.transform;
                plusbtn.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, 0);
                plusbtn.transform.localScale = Vector3.one;
                plusbtn.GetComponent<BtnController>().open_panel = GameObject.Find("createRoom_panel");
                m_roomlist[s_roomList.Length] = plusbtn;
                if (s_roomList.Length > 3)
                {
                    Debug.Log("========2");
                    make_roomParent.GetComponent<RectTransform>().sizeDelta = new Vector2(make_roomParent.GetComponent<RectTransform>().rect.width, make_roomParent.GetComponent<RectTransform>().rect.height + 300);
                }

                //Debug.Log(www.downloadHandler.text);
                //Debug.Log("roomList num : " + roomList_r.Length);

                
                //Debug.Log(sign_up_r.code);
                //Debug.Log(www.downloadHandler.text);

                
            }
        }
    }


    IEnumerator roommake(string id, string roomname, string t_start, string t_end)
    {
        WWWForm form = new WWWForm();
        form.AddField("mb_id", id);
        form.AddField("topic", roomname);
        form.AddField("t_start", t_start);
        form.AddField("t_end", t_end);


        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=make_topic", form))
        {
            yield return www.Send();

            if (www.isError)
            {

            }
            else
            {
                roomMake[] s_roommake = getJsonArray<roomMake>(www.downloadHandler.text);
                roommake_r = s_roommake[0];
                //Debug.Log(sign_up_r.code);
                //Debug.Log(www.downloadHandler.text);

                //성공
                if(roommake_r.code == "100")
                {
                    //Debug.Log("Room Create!!===========");
                    roomMake_doneBtn.GetComponent<BtnController>().close_panel.SetActive(false);

                    Roomlist();

                    //성공

                    //방만들기 팝업닫는다.
                    //채널목록을 
                    //.GetComponent<GameManager>().roomInfo[GameManager.select_roomNum].roomMasterName.text = "주최자 : " + GameManager.player_id;
                    //gameManager.GetComponent<GameManager>().roomInfo[GameManager.select_roomNum].roomName.text = roomInput.text;
                    //gameManager.GetComponent<GameManager>().roomInfo[GameManager.select_roomNum].Create_btn.SetActive(false);

                    roomMake_doneBtn.GetComponent<BtnController>().roomInput.text = "";
                }
                
            }
        }
    }

    IEnumerator getch(string seq)
    {
        WWWForm form = new WWWForm();
        form.AddField("seq", seq);


        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=get_room", form))
        {
            yield return www.Send();
            if (www.isError)
            {
            }
            else
            {
                


                getCh[] s_getCh = getJsonArray<getCh>(www.downloadHandler.text);
                Debug.Log(www.downloadHandler.text);


                if (m_chlist.Length > 0)
                {
                    for (int i = 0; i < m_chlist.Length; i++)
                    {
                        Destroy(m_chlist[i]);
                    }

                }

                m_chlist = new GameObject[s_getCh.Length];


                for (int i = 0; i < s_getCh.Length; i++)
                {
                    string[] status = { "원활", "혼잡", "폭주" };
                    GameObject ch_obj = Instantiate(ch_prefabs);
                    ch_obj.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    ch_obj.gameObject.transform.parent = ch_parent.transform;
                    ch_obj.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, 0);
                    ch_obj.transform.localScale = Vector3.one;
                    ch_obj.transform.FindChild("ch_numBar").transform.FindChild("num").GetComponent<Text>().text = "" + (i+1)+"채널";
                    ch_obj.transform.FindChild("ch_statBar").transform.FindChild("chanel_stat").GetComponent<Text>().text = status[int.Parse(s_getCh[i].condition)-1];

                    ch_obj.gameObject.name = "channel_0" + s_getCh[i].channel;
                    if(i > 10)
                    {
                        ch_obj.gameObject.name = "channel_" + s_getCh[i].channel;
                    }
                    m_chlist[i] = ch_obj;
                }
            }
        }
    }





    IEnumerator getmember(string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("mb_id", id);


        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=get_member", form))
        {
            yield return www.Send();

            if (www.isError)
            {

            }
            else
            {
                getMember[] s_getMember = getJsonArray<getMember>(www.downloadHandler.text);
                getMember_r = s_getMember[0];
                //Debug.Log(sign_up_r.code);
                //Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerator update_icon(string id, string icon)
    {
        WWWForm form = new WWWForm();
        form.AddField("mb_id", id);
        form.AddField("mb_icon", icon);

        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=update_icon", form))
        {
            yield return www.Send();

            Debug.Log("=======>1");

            if (www.isError)
            {
                Debug.Log("=======>2");
            }
            else
            {
                Debug.Log("=======>3"+ www.downloadHandler.text);
                update_Icon[] s_update_Icon = getJsonArray<update_Icon>(www.downloadHandler.text);
                update_Icon_r = s_update_Icon[0];
                
                Debug.Log(update_Icon_r.code);
                //Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerator chat_member()
    {
        WWWForm form = new WWWForm();
        //form.AddField("seq", GameManager.seqSave);
        //form.AddField("channel", GameManager.channelSave);
        form.AddField("seq", "1");
        form.AddField("channel", "2");


        using (UnityWebRequest www = UnityWebRequest.Post("http://175.126.166.197:8081/api/?api_key=76a60f26663388643f8bfcad1e01e123&section=chat_member", form))
        {
            yield return www.Send();

            if (www.isError)
            {

            }
            else
            {

                Debug.Log("0==========chatmember");

                //보상
                gameManager.GetComponent<GameManager>().gameLoading();
                GameManager.talkCheck = false;


                chat_Member[] s_chat_Member = getJsonArray<chat_Member>(www.downloadHandler.text);

                chat_Member_r = new chat_Member[s_chat_Member.Length];
                //Debug.Log("chat_Member_r : " + chat_Member_r.Length);
                m_userlist = new GameObject[s_chat_Member.Length];
                mapUsers = new GameObject[s_chat_Member.Length];

                for (int i = 0; i < s_chat_Member.Length; i++)
                {
                    chat_Member_r[i] = s_chat_Member[i];

                    //userlist_player

                    GameObject btn = Instantiate(userlist_player);
                    btn.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                    btn.gameObject.transform.parent = make_userParent.transform;
                    btn.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, 0);

                    btn.transform.FindChild("name_txt").GetComponent<Text>().text = chat_Member_r[i].mb_id;
                    if(chat_Member_r[i].mb_icon != "")
                    {
                        btn.transform.FindChild("face").GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().avatarFace[int.Parse(chat_Member_r[i].mb_icon)];
                    }
                    

                    btn.transform.localScale = Vector3.one;
                    btn.transform.localRotation = Quaternion.identity;
                    btn.gameObject.name = "player_" + i;
                    //btn.GetComponent<BtnController>().gameManager = GameObject.Find("GameManager");
                    //btn.GetComponent<BtnController>().open_panel = GameObject.Find("GameManager").GetComponent<GameManager>()._3_channel;
                    //btn.GetComponent<BtnController>().myAni_out = GameObject.Find("2_room_window");
                    //btn.GetComponent<BtnController>().https = GameObject.Find("https");

                    m_userlist[i] = btn;
                }

                Debug.Log("2==========");


                //map에 유저 생성.
                if(Application.loadedLevelName == "1.Game")
                {
                    

                    for (int i = 0; i < s_chat_Member.Length; i++)
                    {
                        chat_Member_r[i] = s_chat_Member[i];

                        //userlist_player

                        GameObject btn = Instantiate(mapUser_player);
                        btn.gameObject.transform.localPosition = new Vector3(Random.Range(-7f,7f), 0, Random.Range(-7f, 7f));

                        if (chat_Member_r[i].mb_icon != "")
                        {

                            btn.transform.FindChild("avatar").transform.FindChild("avatar_face").GetComponent<SpriteRenderer>().sprite = gameManager.GetComponent<GameManager>().avatarFace[int.Parse(chat_Member_r[i].mb_icon)];
                        }
                        btn.transform.FindChild("avatar").transform.FindChild("avatar_face").transform.FindChild("col").name = i.ToString();
                        

                        //btn.transform.localScale = Vector3.one;
                        //btn.transform.localRotation = Quaternion.identity;
                        btn.gameObject.name = "player_" + i;
                        //btn.GetComponent<BtnController>().gameManager = GameObject.Find("GameManager");
                        //btn.GetComponent<BtnController>().open_panel = GameObject.Find("GameManager").GetComponent<GameManager>()._3_channel;
                        //btn.GetComponent<BtnController>().myAni_out = GameObject.Find("2_room_window");
                        //btn.GetComponent<BtnController>().https = GameObject.Find("https");

                        mapUsers[i] = btn;
                    }

                    string[] chat_id = new string[s_chat_Member.Length];
                    int[] chat_icon = new int[s_chat_Member.Length];


                    for (int i = 0; i < s_chat_Member.Length; i++)
                    {

                        //btn.transform.FindChild("avatar").transform.FindChild("avatar_face").GetComponent<SpriteRenderer>().sprite = gameManager.GetComponent<GameManager>().avatarFace[int.Parse(chat_Member_r[i].mb_icon)];
                        chat_id[i] = chat_Member_r[i].mb_id;
                        chat_icon[i] = int.Parse(chat_Member_r[i].mb_icon);

                    }

                    gameManager.GetComponent<HumanManager>().HumanEnter(s_chat_Member.Length, chat_id, chat_icon);

                    gameManager.GetComponent<HumanManager>().HumanEnter2(s_chat_Member.Length, chat_id, chat_icon);





                }











            }
        }
    }


    IEnumerator send_voice()
    {

        WWW fileLoad = new WWW("file://" + Application.persistentDataPath + "/Audio123.wav");
        WWWForm form = new WWWForm();

        form.AddBinaryData("sound", fileLoad.bytes, "Audio123.wav", "multipart/form-data");
        form.AddField("topic", GameManager.seqSave);
        form.AddField("channel", GameManager.channelSave);
        form.AddField("mb_id", GameManager.idSave);

        using (UnityWebRequest www = UnityWebRequest.Post("http://ter23api.viewlab.kr/api/sound.html", form))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log("========>error");

            }
            else
            {

                Debug.Log("========>success" + www.downloadHandler.text);

                //창닫아주기 


                //login[] objects = getJsonArray<login> (www.downloadHandler.text);
                // user = objects [0];
                // Debug.Log(user.mb_id);
                // result_data objects1 = JsonUtility.FromJson<result_data>(www.downloadHandler.text);

            }
        }

    }
}
